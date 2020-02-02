// GregoryTanaka
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Scheduler
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            // definining a timespan is suggested by the Microsoft docs on the Thread.Sleep method
            TimeSpan threeSec = new TimeSpan(0, 0, 4);
            // This is the methodology to show a splash screen in the video you shared. I'm not sure why but it seems
            // to then open this form minimized.
            Thread t = new Thread(new ThreadStart(SplashStart));
            t.Start();
            Thread.Sleep(threeSec);
            InitializeComponent();
            t.Abort();
        }

        /**
         * Displays the splash screen
         */
        public void SplashStart()
        {
            Application.Run(new frmSplash());
        }

        /**
         * Closes the form, resulting in the application exiting
         */
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /**
         * Opens the availability form
         */
        private void btnViewAvailability_Click(object sender, EventArgs e)
        {
            Form availability = new frmAvailability();
            availability.ShowDialog();
        }

        /**
         * Opens Team Management form
         */
        private void btnTeamMgmt_Click(object sender, EventArgs e)
        {
            Form teamMgmt = new frmTeamMgmt();
            teamMgmt.ShowDialog();
        }

        /**
         * Opens Member Management form
         */
        private void btnMemberMgmt_Click(object sender, EventArgs e)
        {
            Form memberMgmt = new frmMemberMgmt();
            memberMgmt.ShowDialog();
        }
    }
}
