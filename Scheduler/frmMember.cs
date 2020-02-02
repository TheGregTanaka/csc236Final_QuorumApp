using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class frmMember : Form
    {
        public Member updateMember = new Member();
        public bool isNewMember;
        public const int DAYS = 7; //in a week
        //public const int BLOCKS = 96; // (24*4) quarter-hours in a day
        public const int BLOCKS = 48; // 15 minute intervals was a little insane in the checked listbox. 
        // A custom ui that allowed click and drag might allow this to be changed back to 96 for 15 min.

        public frmMember()
        {
            InitializeComponent();
        }

        /**
         * Close the form on Cancel
         */
        private void btnCancelMember_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /**
         * Loads the form when it opens, if a Member is supplied in
         * the tag, it will load this Mebmer's data to the appropriate
         * fields.
         */
        private void frmMember_Load(object sender, EventArgs e)
        {
            // load Member data if a member was passed
            if (this.Tag != null)
            {
                // if there is a member in the tag, we are editing, not adding
                isNewMember = false;
                updateMember = (Member)this.Tag;
                txtFirstName.Text = updateMember.FirstName;
                txtLastName.Text = updateMember.LastName;
                // get the member's availability and mark the apropriate checkboxes
                bool[,] availability = updateMember.GetAvailability();
                bool chk;
                // loop through one day at a time
                for (int d = 0; d < DAYS; d++)
                {
                    for (int b = 0; b < BLOCKS; b++)
                    {
                        // apply checks to the list box based on which day
                        switch (d)
                        {
                        case 0:
                            // match the bool with this array element
                            chk = availability[d, b];
                            // set item checked sets the check box at index b = chk
                            clstSunday.SetItemChecked(b, chk);
                            break;
                        case 1:
                            chk = availability[d, b];
                            clstMonday.SetItemChecked(b, chk);
                            break;
                        case 2:
                            chk = availability[d, b];
                            clstTuesday.SetItemChecked(b, chk);
                            break;
                        case 3:
                            chk = availability[d, b];
                            clstWednesday.SetItemChecked(b, chk);
                            break;
                        case 4:
                            chk = availability[d, b];
                            clstThursday.SetItemChecked(b, chk);
                            break;
                        case 5:
                            chk = availability[d, b];
                            clstFriday.SetItemChecked(b, chk);
                            break;
                        case 6:
                            chk = availability[d, b];
                            clstSaturday.SetItemChecked(b, chk);
                            break;
                        }
                    }
                }
            } // if no Member was passed in the tag, we are adding a new member
            else
            {
                isNewMember = true;
                updateMember = new Member();
            }
            // allows single click selection in boxes instead of doubleclick
            clstSunday.CheckOnClick = true;
            clstMonday.CheckOnClick = true;
            clstTuesday.CheckOnClick = true;
            clstWednesday.CheckOnClick = true;
            clstThursday.CheckOnClick = true;
            clstFriday.CheckOnClick = true;
            clstSaturday.CheckOnClick = true;
        }

        /**
         * Saves the member to the database and closes this form.
         * Is able to recognize if it needs to update an existing member
         * or add a new one based on the isNewMember bool
         */
        private void btnSaveMember_Click(object sender, EventArgs e)
        {
            updateMember.FirstName = txtFirstName.Text;
            updateMember.LastName = txtLastName.Text;
            // if the member is new, we will first need to insert them into the db
            // this is because members and memberAvailability are stored separately, and
            // memberID is a foreign key for memberAvailability
            try
            {
                if (isNewMember)
                {
                    updateMember.InsertNew();
                }
                else
                {
                    updateMember.UpdateSelf();
                }
            }
            catch (SqlException ex)
            {
                string errMessage = "Error updating the database!";
                MessageBox.Show(errMessage, "ERROR");
                LoggingUtils.LogErrors(errMessage + "\n" + ex.ToString());
            }

            bool[,] availability = new bool[DAYS, BLOCKS];
            // this bool is used so that we don't try to run an update without any values
            bool needsUpdate = false;
            // determine which boxes are checked - each list is a new day in the array
            // CheckedIndices will return only the indicis checked, this corresponding
            // column in the corresponding day row will be set to true
            foreach (int i in clstSunday.CheckedIndices)
            {
                availability[0, i] = true;
                needsUpdate = true;
            }
            foreach (int i in clstMonday.CheckedIndices)
            {
                availability[1, i] = true;
                needsUpdate = true;
            }
            foreach (int i in clstTuesday.CheckedIndices)
            {
                availability[2, i] = true;
                needsUpdate = true;
            }
            foreach (int i in clstWednesday.CheckedIndices)
            {
                availability[3, i] = true;
                needsUpdate = true;
            }
            foreach (int i in clstThursday.CheckedIndices)
            {
                availability[4, i] = true;
                needsUpdate = true;
            }
            foreach (int i in clstFriday.CheckedIndices)
            {
                availability[5, i] = true;
                needsUpdate = true;
            }
            foreach (int i in clstSaturday.CheckedIndices)
            {
                availability[6, i] = true;
                needsUpdate = true;
            }

            // pass the availiability table to the member for updating in the db
            if (needsUpdate)
            {
                try
                {
                    updateMember.UpdateAvailability(availability);
                }
                catch (SqlException ex) // catch and log any sql errors
                {
                    string errMessage = "Unable to update database!";
                    MessageBox.Show(errMessage, "ERROR");
                    LoggingUtils.LogErrors(errMessage + "\n" + ex.ToString());
                }
            }

            this.Tag = updateMember;
            this.DialogResult = DialogResult.OK;
        }
    }
}
