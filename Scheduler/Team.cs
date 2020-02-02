using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Scheduler
{
    public class Team : ICloneable, IDBUpdatable
    {
        public enum TypeTeam
        {
            WorkT = 1,
            EventT,
            ExtracurricularT
        };

        // to determine the blocks of time in a day, multiply 24 by the granularity value
        public enum TypeGranularity
        {
            Hour = 1,
            HalfHour = 2,
            FifteenMin = 4
        };

        // fields
        private int id;
        protected string name;
        protected int teamTypeID;
        protected int absenteeTolerance;
        protected TypeGranularity granularity;
        static SqlConnection connection;
        static string connectionString = ConfigurationManager.ConnectionStrings["Scheduler.Properties.Settings.availabilityConnectionString"].ConnectionString;

        // properties
        public int Id // read-only
        {
            get
            {
                return id;
            }
        }
        
        public string Name { get; set; }
        public int AbsenteeTolerance { get; set; }

        // although the type properties are a bit redundant with the subclasses, it is used
        // for type detection. Additionally, the granularity is determined by the team type
        // this keeps the definitions for these all in one place
        public int TeamTypeID
        {
            get
            {
                return teamTypeID;
            }
            set
            {
                if (value < 0 || value > 3)
                {
                    // throw some error
                }
                else
                {
                    teamTypeID = value;
                    switch(value)
                    {
                        case (int)TypeTeam.WorkT:
                            granularity = TypeGranularity.FifteenMin;
                            break;
                        case (int)TypeTeam.EventT:
                            granularity = TypeGranularity.HalfHour;
                            break;
                        case (int)TypeTeam.ExtracurricularT:
                            granularity = TypeGranularity.Hour;
                            break;
                    }
                }
            }
        }
        public TypeTeam TeamType
        {
            get
            {
                // the id should always be the authority, this is just an easy
                // way to get the type in a different form.
                return (TypeTeam)this.TeamTypeID;
            }
        }
        public TypeGranularity Granularity
        {
            get
            {
                return granularity;
            }
        }

        // constructors
        public Team() { }

        public Team(int i, string n, int at)
        {
            this.id = i;
            this.Name = n;
            this.AbsenteeTolerance = at;
        }

        // copy constructor
        public Team(Team t)
        {
            this.id = t.Id;
            this.Name = t.Name;
            this.AbsenteeTolerance = t.AbsenteeTolerance;
            this.TeamTypeID = t.TeamTypeID;
        }

        // methods
        // Return a human friendly name
        public override string ToString() => this.Name;

        /**
         * Returns the number of members for this team
         */
        public int CountMembers()
        {
            // int to return count
            int count = 0;
            string query =
                "SELECT count(distinct(memberID))" +
                " FROM teamsMembers" +
                " WHERE teamID = " + this.Id + ";";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                // cannot use using for SqlData Reader, because connection must be opened first
                SqlDataReader reader = command.ExecuteReader();
                // Call Read before accessing data.
                while (reader.Read())
                {
                    IDataRecord record = (IDataRecord)reader;
                    count = Convert.ToInt32(record[0]);
                }
                // Call Close when done reading.
                reader.Close();
            }
            return count;
        }

        /**
         * Returns a list of this Teams mebmbers as member objects
         */
        public List<Member> FindMembers()
        {
            // create list to return
            List<Member> membersOfThisTeam = new List<Member>();

            string query =
                "SELECT m.id, firstName, lastName" +
                " FROM teamsMembers tm" +
                " INNER JOIN teams t ON tm.teamID = t.id" +
                " INNER JOIN members m ON tm.memberID = m.id" +
                " WHERE teamID = " + this.Id + ";";

            //per the microsoft docs, because these extend iDisposable, the using syntax
            // can be utilized to ensure they are closed and removed for me
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                
                // cannot use using for SqlData Reader, because connection must be opened first
                SqlDataReader reader = command.ExecuteReader();
                // Call Read before accessing data.
                while (reader.Read())
                {
                    IDataRecord record = (IDataRecord)reader;
                    int id = Convert.ToInt32(record[0]);
                    string fn = record[1].ToString();
                    string ln = record[2].ToString();
                    Member m = new Member(id, fn, ln);
                    membersOfThisTeam.Add(m);
                }
                // Call Close when done reading.
                reader.Close();
            }

            return membersOfThisTeam;
        }

        /**
         * Removes all existing links to this team in teamsMembers table
         * then inserts links for all members in the supllied list
         */
        public bool UpdateTeamsMembers(List<Member> members)
        {
            // Remove links
            if (!(this.RemoveMemberLinks()))
            {
                //throw new Exception();
            }
            
            string query = "INSERT INTO teamsMembers (memberID, teamID) VALUES";
            bool first = true;
            foreach(Member m in members)
            {
                query += (first ? "" : ","); // after the first iteration, add commas
                query += " (" + m.Id.ToString() + ", " + this.Id.ToString() + ")";
                first = false;
            }
            query += ";";

            return InsertUpdateDelete(query);
        }

        /**
         * Remove all member links to this team - This is private because it's potentially dangerous
         */
        private bool RemoveMemberLinks()
        {
            string query = "DELETE FROM teamsMembers WHERE teamID = " + this.Id.ToString();

            return InsertUpdateDelete(query);
        }

        // Static method to load all teams from the database. The type can optionally be passed to only load specific types of teams
        public static List<Team> LoadTeamsFromDB(int typeID = 0)
        {
            // create list to return
            List<Team> teams = new List<Team>();

            // https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqldatareader?redirectedfrom=MSDN&view=netframework-4.7.2
            string query = "SELECT * FROM teams";
            if (typeID != 0)
            {
                // TODO: Sanitize this input
                query = query + " WHERE teamTypeID = " + typeID.ToString();
            }
            query += ";";

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
                    string name = record[1].ToString();
                    int absenteeTol = Convert.ToInt32(record[2]);
                    int type = Convert.ToInt32(record[3]);
                    switch (type)
                    {
                        case 1:
                            WorkTeam wt = new WorkTeam(id, name, absenteeTol);
                            teams.Add(wt);
                            break;
                        case 2:
                            EventTeam et = new EventTeam(id, name, absenteeTol);
                            teams.Add(et);
                            break;
                        case 3:
                            ExtracurricularTeam xt = new ExtracurricularTeam(id, name, absenteeTol);
                            teams.Add(xt);
                            break;
                    }
                }
                // Call Close when done reading.
                reader.Close();
            }
            return teams;
        }

        // week acts like out parameter because arrays are passed by reference
        // blocks defaults to hours. for finer granularity, change the blocks parameter - 1/2 hour = 48 blocks, 1/4 hour = 96
        public void GenerateAvailabilityTable(int[,] week, int blocks = 24)
        {
            // declare variables
            double start; // start time in db record
            double end; // end time in db record
            int day; // dayID from record - used to access correct row in array
            double blockStart;
            double blockEnd;
            double span = (double)this.Granularity;
            /* the blockStart/End and span are used to compare different granularities of time
                i.e. if the granularity is hours, there will be 24 columns in each array row.
                [0] is midnight, [1] is 1am. So any given block correlates directly with hours - 
                the start remains the same (divide by 1), and the end is just 1 hour later (+ 1)
                if the granularity is half hours, there are 48 columns. [0] is midnight, [1] is 12:30
                and [2] is 1am. Start is index divided by 2, end is + 1/2*/

            string query = "SELECT a.startTime, a.endTime, a.dayID" +
                " FROM teamsMembers tm" +
                " LEFT JOIN teams t on tm.teamID = t.id" +
                " LEFT JOIN members m on tm.memberId = m.id" +
                " LEFT JOIN memberAvailability a on m.id = a.memberID" +
                " WHERE teamID = " + this.Id +
                " AND startTime IS NOT NULL" +
                " ORDER BY a.startTime;";

            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();
                // Call Read before accessing data - The while here acts like a 'for each record'
                while (reader.Read())
                {
                    IDataRecord record = (IDataRecord)reader;
                    start = Convert.ToDouble(record[0]);
                    end = Convert.ToDouble(record[1]);
                    day = Convert.ToInt32(record[2]);
                    // check each array element to see if it represents a time within this record's time...
                    for (int h = 0; h < blocks; h++)
                    {
                        // (see comment below span's declaration for clarification on these calculations)
                        blockStart = h / span;
                        blockEnd = blockStart + (1.0 / span);
                        // ...and if it does, increment it
                        if (blockStart > start && blockEnd < end)
                        {
                            week[day, h]++;
                        }
                    }
                }
                // Call Close when done reading.
                reader.Close();
            }
        }

        // ICloneable implementation
        public object Clone()
        {
            Team t = new Team(this.id, this.Name, this.AbsenteeTolerance);
            t.TeamTypeID = this.TeamTypeID;
            return t;
        }

        // IDBUpdatable implementation
        public bool UpdateSelf()
        {
            string query = "UPDATE teams " +
                "SET name = N'" + this.Name + "'" +
                ", absenteeTolerance = " + this.AbsenteeTolerance.ToString() +
                ", teamTypeID = " + this.TeamTypeID.ToString() +
                " WHERE id = " + this.Id.ToString() + ";";

            return InsertUpdateDelete(query);
        }

        public bool InsertNew()
        {
            string query = "INSERT into teams (name, absenteeTolerance, teamTypeID) " +
                "VALUES ( N'" + this.Name + "', " + this.AbsenteeTolerance.ToString() +
                ", " + this.TeamTypeID.ToString() + ");";

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
    }
}
