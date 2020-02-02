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
    public partial class frmMemberMgmt : Form
    {
        // a list to store the users
        public List<Member> members = new List<Member>();

        public frmMemberMgmt()
        {
            InitializeComponent();
        }

        /**
         * Closes the form on Cancel
         */
        private void btnCancelMemberMgmt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /**
         * Opens the Member Add/Edit form, but passes no data so it will create
         * a new Member
         */
        private void btnAddNewMember_Click(object sender, EventArgs e)
        {
            Form addMember = new frmMember();
            DialogResult button = addMember.ShowDialog();
            if (button == DialogResult.OK)
            {
                // Cast the contents of the Tag to a member and add to member list
                members.Add((Member)addMember.Tag);
                // reload the list box
                LoadListBox();
            }
        }

        /**
         * Reload list box with the data in the members list
         */
        private void LoadListBox()
        {
            // Load members from database
            members = Member.LoadMembersFromDB();
            // clear curent items 
            lstMembers.Items.Clear();
            // Adds each member in the list
            foreach (Member m in members)
            {
                lstMembers.Items.Add(m);
            }
            // if the box is populated, highlight the first one
            if (lstMembers.Items.Count > 0)
            {
                lstMembers.SelectedIndex = 0;
            }
        }

        /**
         * Loads this form's data when it opens - just runs LoadListBox function
         */
        private void frmMemberMgmt_Load(object sender, EventArgs e)
        {            
            // load list box
            LoadListBox();
        }

        /**
         * Opens the Add/Edit member form with the currently selected Member's data
         * for editing
         */
        private void btnEditSelectedMember_Click(object sender, EventArgs e)
        {
            if (members.Count > 0)
            {
                Member m = (Member)lstMembers.SelectedItem;
                // the syntax below is how Visual Studio sugested I structure this,
                // rather than the typical `...new frmMember(); update.Tag = m.Clone();`
                Form update = new frmMember
                {
                    // Clone the student so the object on this form is only 
                    // updated if the DialogResult is OK
                    Tag = m.Clone()
                };
                DialogResult button = update.ShowDialog();
                if (button == DialogResult.OK)
                {
                    LoadListBox();
                }
            }
        }
    }
}
