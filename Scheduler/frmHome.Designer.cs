namespace Scheduler
{
    partial class frmHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.btnViewAvailability = new System.Windows.Forms.Button();
            this.btnTeamMgmt = new System.Windows.Forms.Button();
            this.btnMemberMgmt = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnViewAvailability
            // 
            this.btnViewAvailability.Location = new System.Drawing.Point(124, 43);
            this.btnViewAvailability.Name = "btnViewAvailability";
            this.btnViewAvailability.Size = new System.Drawing.Size(113, 49);
            this.btnViewAvailability.TabIndex = 0;
            this.btnViewAvailability.Text = "View Availability";
            this.btnViewAvailability.UseVisualStyleBackColor = true;
            this.btnViewAvailability.Click += new System.EventHandler(this.btnViewAvailability_Click);
            // 
            // btnTeamMgmt
            // 
            this.btnTeamMgmt.Location = new System.Drawing.Point(124, 140);
            this.btnTeamMgmt.Name = "btnTeamMgmt";
            this.btnTeamMgmt.Size = new System.Drawing.Size(113, 49);
            this.btnTeamMgmt.TabIndex = 1;
            this.btnTeamMgmt.Text = "Team Management";
            this.btnTeamMgmt.UseVisualStyleBackColor = true;
            this.btnTeamMgmt.Click += new System.EventHandler(this.btnTeamMgmt_Click);
            // 
            // btnMemberMgmt
            // 
            this.btnMemberMgmt.Location = new System.Drawing.Point(124, 232);
            this.btnMemberMgmt.Name = "btnMemberMgmt";
            this.btnMemberMgmt.Size = new System.Drawing.Size(113, 49);
            this.btnMemberMgmt.TabIndex = 2;
            this.btnMemberMgmt.Text = "Member  Managment";
            this.btnMemberMgmt.UseVisualStyleBackColor = true;
            this.btnMemberMgmt.Click += new System.EventHandler(this.btnMemberMgmt_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(124, 328);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(113, 49);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 461);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnMemberMgmt);
            this.Controls.Add(this.btnTeamMgmt);
            this.Controls.Add(this.btnViewAvailability);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHome";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Button btnViewAvailability;
        private System.Windows.Forms.Button btnTeamMgmt;
        private System.Windows.Forms.Button btnMemberMgmt;
        private System.Windows.Forms.Button btnExit;
    }
}