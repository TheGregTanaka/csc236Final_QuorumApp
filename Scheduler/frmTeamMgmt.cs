using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.Linq;
using System.Data.SqlClient;

namespace Scheduler
{
    public partial class frmTeamMgmt : Form
    {
        // list to store teams
        public List<Team> teams = new List<Team>();
        

        public frmTeamMgmt()
        {
            InitializeComponent();
        }

        /**
         * Loads data when this form opens - gets teams from database
         * and calls the LoadListBox function
         */
        private void frmTeamMgmt_Load(object sender, EventArgs e)
        {
            // load the teams
            teams = Team.LoadTeamsFromDB();
            // load the box
            LoadListBox();
        }

        /**
         * Closes this form on Cancel
         */
        private void btnCancelTeamMgmt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /**
         * Opens the form to Add a new team - passes no data
         */
        private void btnAddNewTeam_Click(object sender, EventArgs e)
        {
            Form addTeam = new frmTeam();
            DialogResult button = addTeam.ShowDialog();
            if (button == DialogResult.OK)
            {
                // Cast the contents of the Tag to a member and add to member list
                teams.Add((Team)addTeam.Tag);
                // reload the list box
                LoadListBox();
            }
        }

        /**
         * Loads the list box with Teams in the teams list
         */
        private void LoadListBox()
        {
            // clear existing items
            lstTeams.Items.Clear();
            // for every team in the teams list add it to the box
            foreach (Team t in teams)
            {
                lstTeams.Items.Add(t);
            }
            // if there is anything in the box, select the first one
            if (lstTeams.Items.Count > 0)
            {
                lstTeams.SelectedIndex = 0;
            }
        }

        /**
         * Opens the Edit teams form with the currently highlighted team in the tag
         * for editing
         */
        private void btnEditSelectedTeam_Click(object sender, EventArgs e)
        {
            var selectedTeam = teams[lstTeams.SelectedIndex];
            Form editTeam = new frmTeam();
            editTeam.Tag = selectedTeam.Clone();
            DialogResult button = editTeam.ShowDialog();
            if (button == DialogResult.OK)
            {
                // Cast the contents of the Tag to a team and add to team list
                teams.Insert(lstTeams.SelectedIndex, (Team)editTeam.Tag);
                // remove the old team
                teams.RemoveAt(lstTeams.SelectedIndex + 1);
                // reload the list box
                LoadListBox();
            }
        }
    }
}
