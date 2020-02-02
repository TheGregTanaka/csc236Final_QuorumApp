namespace Scheduler
{
    partial class frmTeamMgmt
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
            this.lstTeams = new System.Windows.Forms.ListBox();
            this.btnAddNewTeam = new System.Windows.Forms.Button();
            this.btnEditSelectedTeam = new System.Windows.Forms.Button();
            this.btnCancelTeamMgmt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstTeams
            // 
            this.lstTeams.FormattingEnabled = true;
            this.lstTeams.Location = new System.Drawing.Point(32, 50);
            this.lstTeams.Name = "lstTeams";
            this.lstTeams.Size = new System.Drawing.Size(137, 160);
            this.lstTeams.TabIndex = 0;
            // 
            // btnAddNewTeam
            // 
            this.btnAddNewTeam.Location = new System.Drawing.Point(217, 63);
            this.btnAddNewTeam.Name = "btnAddNewTeam";
            this.btnAddNewTeam.Size = new System.Drawing.Size(75, 23);
            this.btnAddNewTeam.TabIndex = 1;
            this.btnAddNewTeam.Text = "Add";
            this.btnAddNewTeam.UseVisualStyleBackColor = true;
            this.btnAddNewTeam.Click += new System.EventHandler(this.btnAddNewTeam_Click);
            // 
            // btnEditSelectedTeam
            // 
            this.btnEditSelectedTeam.Location = new System.Drawing.Point(217, 119);
            this.btnEditSelectedTeam.Name = "btnEditSelectedTeam";
            this.btnEditSelectedTeam.Size = new System.Drawing.Size(75, 23);
            this.btnEditSelectedTeam.TabIndex = 2;
            this.btnEditSelectedTeam.Text = "Edit";
            this.btnEditSelectedTeam.UseVisualStyleBackColor = true;
            this.btnEditSelectedTeam.Click += new System.EventHandler(this.btnEditSelectedTeam_Click);
            // 
            // btnCancelTeamMgmt
            // 
            this.btnCancelTeamMgmt.Location = new System.Drawing.Point(217, 176);
            this.btnCancelTeamMgmt.Name = "btnCancelTeamMgmt";
            this.btnCancelTeamMgmt.Size = new System.Drawing.Size(75, 23);
            this.btnCancelTeamMgmt.TabIndex = 3;
            this.btnCancelTeamMgmt.Text = "Cancel";
            this.btnCancelTeamMgmt.UseVisualStyleBackColor = true;
            this.btnCancelTeamMgmt.Click += new System.EventHandler(this.btnCancelTeamMgmt_Click);
            // 
            // frmTeamMgmt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 253);
            this.Controls.Add(this.btnCancelTeamMgmt);
            this.Controls.Add(this.btnEditSelectedTeam);
            this.Controls.Add(this.btnAddNewTeam);
            this.Controls.Add(this.lstTeams);
            this.Name = "frmTeamMgmt";
            this.Text = "Team Management";
            this.Load += new System.EventHandler(this.frmTeamMgmt_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstTeams;
        private System.Windows.Forms.Button btnAddNewTeam;
        private System.Windows.Forms.Button btnEditSelectedTeam;
        private System.Windows.Forms.Button btnCancelTeamMgmt;
    }
}