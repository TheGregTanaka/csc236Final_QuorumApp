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
    public partial class frmTeam : Form
    {
        public Team updateTeam = new Team();
        public List<Member> teamMembers = new List<Member>();
        public List<Member> nonTeamMembers = new List<Member>();
        public bool isNewTeam;

        public frmTeam()
        {
            InitializeComponent();
        }

        /**
         * Close this form on cancel
         */
        private void btnCancelTeam_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /**
         * loads this forms data when it opens. if it was supplied Team data in the
         * tag, Edit, if not new
         */
        private void frmTeam_Load(object sender, EventArgs e)
        {
            // load team data if a team was passed
            if (this.Tag != null)
            {
                // if there is data in the tag, we are editing
                isNewTeam = false;
                // tmp is declared as a generic Team to accept whatever type is in the 
                // tag. Based on my research, when adding a child object to a parent type (list, var, param, etc), 
                // it retains it's child type 'under the hood', however, casting it will
                // remove the child type. Because of this, I have cast the tag data to a 
                // generic Team, which is fed into the copy constructor for the child classes.
                // This allows us to treat updateTeam as the appropriate type, while having
                // a general cast for the tag, allowing us to access member data
                Team tmp = (Team)this.Tag;
                // use switch to set team type
                switch (tmp.TeamTypeID)
                {
                    case 1:
                        updateTeam = new WorkTeam(tmp);
                        break;
                    case 2:
                        updateTeam = new EventTeam(tmp);
                        break;
                    case 3:
                        updateTeam = new ExtracurricularTeam(tmp);
                        break;
                }
                // display this teams name
                txtTeamName.Text = updateTeam.Name;
                // indicies start at 0, but the types start at 1
                int teamIndex = updateTeam.TeamTypeID - 1;
                // display this teams type
                cmbTeamType.SelectedIndex = teamIndex;
                // find the members of this team
                teamMembers = updateTeam.FindMembers();
                // display the current absentee tolerance value in the number up/down selector
                nudAbsentee.Value = updateTeam.AbsenteeTolerance;
            }
            else
            {
                isNewTeam = true;
            }
            // find everyone not on this team
            FindNonTeamMembers();

            //Reload both list boxes with all the members on and off the team
            LoadListBox(lstMembersOn, teamMembers);
            LoadListBox(lstMembersOff, nonTeamMembers);
        }

        //https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.except?redirectedfrom=MSDN&view=netframework-4.7.2#System_Linq_Enumerable_Except__1_System_Collections_Generic_IEnumerable___0__System_Collections_Generic_IEnumerable___0__
        /**
         * Finds all the team members associated with the currently viewed team
         */
        private void FindNonTeamMembers()
        {
            nonTeamMembers = Member.LoadMembersFromDB();
            List<Member> tmp = Member.LoadMembersFromDB();
            foreach (Member nonMember in tmp)
            {
                foreach (Member m in teamMembers)
                {
                    if (nonMember.Equals(m))
                    {
                        nonTeamMembers.Remove(nonMember);
                    }
                }
            }
        }

        /**
         * Loads the specified list box, with the members in the specified team
         */
        private void LoadListBox(ListBox lb, List<Member> memberList)
        {
            // clears the list box
            lb.Items.Clear();
            // adds each Member in the supplied list to the supplied list box
            foreach (Member m in memberList)
            {
                lb.Items.Add(m);
            }
            // highlights the first index if there are any items in the box
            if (lb.Items.Count > 0)
            {
                lb.SelectedIndex = 0;
            }
        }

        /**
         * Moves the selected Member from the non-team-members list box, to the 
         * team-members list box
         */
        private void btnMoveOn_Click(object sender, EventArgs e)
        {
            // take the member from the box on the left
            int left = lstMembersOff.SelectedIndex;
            Member m = nonTeamMembers[left];
            // add member to team
            teamMembers.Add(m);
            // remove from box on left
            nonTeamMembers.RemoveAt(left);
            // And reload both list boxes
            LoadListBox(lstMembersOn, teamMembers);
            LoadListBox(lstMembersOff, nonTeamMembers);
        }

        /**
         * Moves the selected Member from the team-members list box to the
         * non-team-members list box
         */
        private void btnMoveOff_Click(object sender, EventArgs e)
        {
            // take the member from the box on the left
            int right = lstMembersOn.SelectedIndex;
            Member m = teamMembers[right];
            // add member to non-team member list
            nonTeamMembers.Add(m);
            // remove from box on right
            teamMembers.RemoveAt(right);
            // And reload both list boxes
            LoadListBox(lstMembersOn, teamMembers);
            LoadListBox(lstMembersOff, nonTeamMembers);
        }

        /**
         * Runs the ApplyChanges function, store the team in the tag, and then 
         * returns an OK DialogResult
         */
        private void btnSaveTeam_Click(object sender, EventArgs e)
        {
            ApplyChanges();
            this.Tag = updateTeam;
            this.DialogResult = DialogResult.OK;
        }

        /**
         * Updates any changes to the database
         */
        private void ApplyChanges()
        {
            // if the type has been changed, ensure the object type is changed, not just the property
            int selectedType = cmbTeamType.SelectedIndex + 1;
            if (updateTeam.TeamTypeID != selectedType)
            {
                updateTeam.TeamTypeID = selectedType;
                switch (updateTeam.TeamTypeID)
                {
                    case 1:
                        updateTeam = new WorkTeam(updateTeam);
                        break;
                    case 2:
                        updateTeam = new EventTeam(updateTeam);
                        break;
                    case 3:
                        updateTeam = new ExtracurricularTeam(updateTeam);
                        break;
                }
            }
            // update name
            updateTeam.Name = txtTeamName.Text;
            // update absentee tolerance
            updateTeam.AbsenteeTolerance = (int)nudAbsentee.Value;
            try
            {
                // update/insert the team
                if (isNewTeam)
                {
                    updateTeam.InsertNew();
                }
                else
                {
                    updateTeam.UpdateSelf();
                }
                // update the members of the team
                if (!(updateTeam.UpdateTeamsMembers(teamMembers)))
                {
                    MessageBox.Show("Error updating data");
                }
            }
            catch (SqlException ex)
            {
                string errMessage = "Unable to update database!";
                MessageBox.Show(errMessage, "ERROR");
                LoggingUtils.LogErrors(errMessage + "\n" + ex.ToString());
            }
        }

        /**
         * Opens the Add member form to allow creating members for a team
         */
        private void btnAddMember_Click(object sender, EventArgs e)
        {
            Form addMember = new frmMember();
            DialogResult button = addMember.ShowDialog();
            if (button == DialogResult.OK)
            {
                // Cast the contents of the Tag to a member and add to member list
                nonTeamMembers.Add((Member)addMember.Tag);
                // reload the list box
                FindNonTeamMembers();
                LoadListBox(lstMembersOff, nonTeamMembers);
            }
        }

        /**
         * Open's the availability table form with this team in the tag
         */
        private void btnViewTeam_Click(object sender, EventArgs e)
        {
            Form availability = new frmAvailability();
            availability.Tag = updateTeam.Clone();
            availability.ShowDialog();
        }
    }
}
