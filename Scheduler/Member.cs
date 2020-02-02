using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    enum Day { Sun, Mon, Tue, Wed, Thu, Fri, Sat };
    public class Member : ICloneable, IDBUpdatable
    {
        // fields
        private int id;
        static SqlConnection connection;
        static string connectionString = ConfigurationManager.ConnectionStrings["Scheduler.Properties.Settings.availabilityConnectionString"].ConnectionString;

        // properties
        public int Id
        {
            get
            {
                return id;
            }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // constructor
        public Member() {}

        public Member(int i, string fn, string ln)
        {
            this.id = i;
            this.FirstName = fn;
            this.LastName = ln;
        }

        // methods
        /**
         * Static method to load all members from the database
         */
        public static List<Member> LoadMembersFromDB()
        {
            // create list to return
            List<Member> members = new List<Member>();

            // https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqldatareader?redirectedfrom=MSDN&view=netframework-4.7.2
            string query = "SELECT * FROM members";

            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();
                // Call Read before accessing data.
                while (reader.Read())
                {
                    IDataRecord record = (IDataRecord)reader;
                    int id = Convert.ToInt32(record[0]);
                    string fn = record[1].ToString();
                    string ln = record[2].ToString();
                    Member m = new Member(id, fn, ln);
                    members.Add(m);
                }

                // Call Close when done reading.
                reader.Close();
            }

            return members;
        }

        /**
         * Returns this Member's full name
         */
        public override string ToString() => this.FirstName + " " + this.LastName;

        /**
         * Compares two objects
         */
        public override bool Equals(object obj)
        {
            if ((obj != null) && this.GetType().Equals(obj.GetType()))
            {
                Member m = (Member)obj;
                if (m.Id == this.Id && m.FirstName.Equals(this.FirstName) && m.LastName.Equals(this.LastName))
                    return true;
            }
            return false;
        }

        /**
         * This was the code generated for me by Visual Studio when I used ctrl+. on the class name
         * when a green underline complained that I overrode Equals but not GetHashCode()
         * I have not made any changes to it, and make no claim that this is my code. I just wanted
         * Visual Studio to stop complaining
         */
        public override int GetHashCode()
        {
            var hashCode = -1116689700;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            return hashCode;
        }

        /**
         * removes any existing memberAvailability links to this member,  then
         * inserts new records for a supplied 2d array
         */
        public bool UpdateAvailability(bool[,] availability)
        {
            // if this member has rows in the memberAvailability table already remove 
            // them to avoid duplicates
            bool addComma = false;
            int days = 7; // in a week
            int blocks = 48; // if the ui changes to 15 min, change to 96
            //int blocks = 96; // 96 = 24 * 4
            // find contiguous spans of time
            double start = 0;
            double end = 0;
            bool prev;
            string query = "INSERT INTO memberAvailability (memberID, dayID, startTime, endTime)" +
                " VALUES ";
            // itterate through each block
            for (int d = 0; d < days; d++)
            {
                // reset on each new day
                prev = false;
                for (int b = 0; b < blocks; b++)
                {
                    // check if it is true
                    if (availability[d, b])
                    {
                        // if the previous block was false, start a new period
                        if (!prev)
                        {
                            start = b;
                        }
                    }
                    // if it's not, but the previous one was, end this block of time
                    else if (prev)
                    {
                        end = b;
                        // we should now have a complete chunk of time. Convert to a time double
                        // representing 15 min chunks and create a record to add to the query string
                        start *= .5; //change back to .25 for 15 min
                        end = (end * .5) + .5;
                        //start *= 0.25;
                        //end *= 0.25 + 0.25;
                        if (addComma) //after the first time, there will need to be a comma beteewn records
                            query += ",";
                        query += " (" + this.Id.ToString() + ", " + d.ToString() + ", " +
                            start.ToString() + ", " + end.ToString() + ")";
                        addComma = true;
                    }
                    // store the state to compare in next block
                    prev = availability[d, b];
                }
            }
            if (!InsertUpdateDelete(query))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /**
         * Returns the availability for this member. The data is pulled from the DB
         * then convered into a 2d array representing 96 fifteen minute blocks 7 days a week
         */
        public bool[,] GetAvailability()
        {
            double start; // start time in db record
            double end; // end time in db record
            double blockStart;
            double blockEnd;
            int day;
            int blocks = 48;
            //int blocks = 96; // 96 = 24 * 4 : the number of 15 minute increments in a day
            string query = "SELECT startTime, endTime, dayID" +
                " FROM memberAvailability" +
                " WHERE memberID = " + this.Id + ";";

            bool[,] availability = new bool[7, blocks];

            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();
                // the methodology here is essentially identical to how it is done in the Team.
                // perhaps a database utility class could be written to DRY up this code
                // Call Read before accessing data - The while here acts like a 'for each record'
                while (reader.Read())
                {
                    IDataRecord record = (IDataRecord)reader;
                    start = Convert.ToDouble(record[0]);
                    end = Convert.ToDouble(record[1]);
                    day = Convert.ToInt32(record[2]);
                    // check each array element to see if it represents a time within this record's time...
                    //members use the finest granularity - 15 min
                    for (int h = 0; h < blocks; h++)
                    {
                        blockStart = h / 2.0;
                        blockEnd = blockStart + 0.5;
                        //blockStart = h / 4.0;
                        //blockEnd = blockStart + 0.25;
                        // ...and if it does, set it to true
                        if (blockStart >= start && blockEnd < end)
                        {
                            availability[day, h] = true;
                        }
                    }
                }
                // Call Close when done reading.
                reader.Close();
            }

            return availability;
        }

        // IDBUpdatable implementation
        /**
         * updates the database record with the matching ID, with this object's
         * first and last name
         */
        public bool UpdateSelf()
        {
            string query = "UPDATE members " +
                "SET firstName = N'" + this.FirstName + "'" +
                ", lastName = N'" + this.LastName + "'" +
                " WHERE id = " + this.Id.ToString();

            return InsertUpdateDelete(query);
        }

        /**
         * runs a supplied query to make a change in the database
         */
        public bool InsertUpdateDelete(string query)
        {
            bool isSuccess = true;
            int exitCode;

            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                exitCode = command.ExecuteNonQuery();
            }
            if (exitCode <= 0)
                isSuccess = false;

            return isSuccess;
        }

        /** 
         * inserts a new record for this object, then sets this objects id to
         * match the inserted record
         */
        public bool InsertNew()
        {
            string query = "INSERT into members (firstName, lastName) " +
                "VALUES ( N'" + this.FirstName + "', N'" + this.LastName + "');";

            if (!InsertUpdateDelete(query))
                return false;
            else
            {
                // get the newly inserted id
                string idQuery = "SELECT TOP(1) id FROM teams ORDER BY id desc;";
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(idQuery, connection))
                {
                    connection.Open();

                    // cannot use using for SqlData Reader, because connection must be opened first
                    SqlDataReader reader = command.ExecuteReader();
                    // Call Read before accessing data.
                    while (reader.Read())
                    {
                        IDataRecord record = (IDataRecord)reader;
                        // set the id of this object to match the auto-incremented id from the db
                        this.id = Convert.ToInt32(record[0]);
                    }
                    // Call Close when done reading.
                    reader.Close();
                }
            }
            return true;
        }

        // IClonable implementation
        public object Clone()
        {
            Member m = new Member(this.Id, this.FirstName, this.LastName);
            return m;

        }
    }
}
