using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class frmAvailability : Form
    {
        // declare member variables
        const int DAYS = 7; // in a week
        const int HOURS = 24; // in a day
        Team team;
        List<Team> allTeams = new List<Team>();
        int memberCount;
        int allowedAbsentees;

        public frmAvailability()
        {
            InitializeComponent();
        }

        /**
         * Loads the form data when this opens. If being called from the
         * team form, then the tag will be suplied with the team to load
         */
        private void frmAvailability_Load(object sender, EventArgs e)
        {
            // fill data in combo box
            allTeams = Team.LoadTeamsFromDB();
            foreach (Team t in allTeams)
            {
                cmbViewTeam.Items.Add(t);
            }

            // potential exceptions could occur while loading data, so make
            // sure they get handled
            try
            {
                // if there is data in the tag, we should use it, otherwise
                // do nothing
                if (this.Tag != null)
                {
                    Team tmp = (Team)this.Tag;
                    // use switch to set team type
                    switch (tmp.TeamTypeID)
                    {
                        case 1:
                            team = new WorkTeam(tmp);
                            break;
                        case 2:
                            team = new EventTeam(tmp);
                            break;
                        case 3:
                            team = new ExtracurricularTeam(tmp);
                            break;
                    }
                    // Set the combo box to show this team
                    cmbViewTeam.SelectedIndex = cmbViewTeam.FindString(team.ToString());
                    // Load the data grid view which displays availability
                    loadAvailabilityTable();
                }
            }
            catch (InvalidCastException ex)// potentially thrown from the converts in loadAvailabilityTable
            {
                string errMessage = "Unable to generate availability table!";
                MessageBox.Show(errMessage, "ERROR");
                LoggingUtils.LogErrors(errMessage + "\n" + ex.ToString());
            }
        }

        /**
         * When a different team is selected, reload this page
         */
        private void cmbCurrentTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // update the local team to match the selection
                this.team = allTeams[cmbViewTeam.SelectedIndex];
                // reload the datagridview
                loadAvailabilityTable();
            }
            catch (IndexOutOfRangeException ex) // potentially thrown if selected index is not valid for allTeams
            {
                string errMessage = "Error changing the selected team!";
                MessageBox.Show(errMessage, "ERROR");
                LoggingUtils.LogErrors(errMessage + "\n" + ex.ToString());
            }
            catch (InvalidCastException ex) // potentially thrown from the converts in loadAvailabilityTable
            {
                string errMessage = "Unable to generate availability table!";
                MessageBox.Show(errMessage, "ERROR");
                LoggingUtils.LogErrors(errMessage + "\n" + ex.ToString());
            }
        }

        /**
         * Gets the team's availability and populates the datagridview with it
         */
        private void loadAvailabilityTable()
        {
            // update the member count and allowed absentees
            memberCount = team.CountMembers();
            allowedAbsentees = team.AbsenteeTolerance;
            // declare varaibles
            // blocks are each unit of time within a given day
            int blocks = HOURS * (int)this.team.Granularity;
            // 2d array represents a week - each day is an array of blocks
            int[,] week = new int[DAYS, blocks];
            // Get the availability of the team. Because arrays are passed by reference,
            // this works like an out parameter. Blocks must be passed so we know the
            // length of each row
            this.team.GenerateAvailabilityTable(week, blocks);

            // temp variable to store a calculation in durring loop
            double tmp;
            // because week array is Day x Block, it must be turned "sideways" so block is the row
            for (int b = 0; b < blocks; b++)
            {
                // fill the DataGridView one row at a time
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvAvailability);
                // Fill each row with the corresponding time from each day- i.e. 9Am Sun, 9Am Mon, 9Am Tues...
                for (int d = 0; d < DAYS; d++)
                {
                    row.Cells[d].Value = week[d, b];
                }
                dgvAvailability.Rows.Add(row);
                // convert the block into a time for the cell header
                tmp = b / (double)team.Granularity;
                // use that time as the row header
                dgvAvailability.Rows[b].HeaderCell.Value = tmp.ToString();
            }

            // color cells
            int quorum = memberCount - allowedAbsentees; // the minimum number of people who must be present
            // for each row in the datagrid view...
            foreach (DataGridViewRow row in dgvAvailability.Rows)
            { // check each column.....
                for (int i = 0; i < DAYS; i++)
                { // color each one depending on if it meets the required "quorum"
                    if (Convert.ToInt32(row.Cells[i].Value) >= memberCount)
                    {
                        // color green if everyone is available
                        row.Cells[i].Style.BackColor = Color.Green;
                    }
                    else if (Convert.ToInt32(row.Cells[i].Value) >= quorum)
                    {
                        //collor yellow if an allowed number of absentees
                        row.Cells[i].Style.BackColor = Color.Yellow;
                    }
                    else
                    {
                        // color red if there are too many absentees
                        row.Cells[i].Style.BackColor = Color.Red;
                    }
                }
            }
        }
    }
}
