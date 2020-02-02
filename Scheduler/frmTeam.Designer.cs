namespace Scheduler
{
    partial class frmTeam
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
            this.lstMembersOff = new System.Windows.Forms.ListBox();
            this.lstMembersOn = new System.Windows.Forms.ListBox();
            this.btnMoveOn = new System.Windows.Forms.Button();
            this.btnMoveOff = new System.Windows.Forms.Button();
            this.txtTeamName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTeamType = new System.Windows.Forms.ComboBox();
            this.btnAddMember = new System.Windows.Forms.Button();
            this.btnCancelTeam = new System.Windows.Forms.Button();
            this.btnViewTeam = new System.Windows.Forms.Button();
            this.btnSaveTeam = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudAbsentee = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudAbsentee)).BeginInit();
            this.SuspendLayout();
            // 
            // lstMembersOff
            // 
            this.lstMembersOff.FormattingEnabled = true;
            this.lstMembersOff.Location = new System.Drawing.Point(43, 84);
            this.lstMembersOff.Name = "lstMembersOff";
            this.lstMembersOff.Size = new System.Drawing.Size(131, 173);
            this.lstMembersOff.TabIndex = 0;
            // 
            // lstMembersOn
            // 
            this.lstMembersOn.FormattingEnabled = true;
            this.lstMembersOn.Location = new System.Drawing.Point(261, 84);
            this.lstMembersOn.Name = "lstMembersOn";
            this.lstMembersOn.Size = new System.Drawing.Size(131, 173);
            this.lstMembersOn.TabIndex = 1;
            // 
            // btnMoveOn
            // 
            this.btnMoveOn.Location = new System.Drawing.Point(180, 123);
            this.btnMoveOn.Name = "btnMoveOn";
            this.btnMoveOn.Size = new System.Drawing.Size(75, 23);
            this.btnMoveOn.TabIndex = 2;
            this.btnMoveOn.Text = ">>";
            this.btnMoveOn.UseVisualStyleBackColor = true;
            this.btnMoveOn.Click += new System.EventHandler(this.btnMoveOn_Click);
            // 
            // btnMoveOff
            // 
            this.btnMoveOff.Location = new System.Drawing.Point(180, 175);
            this.btnMoveOff.Name = "btnMoveOff";
            this.btnMoveOff.Size = new System.Drawing.Size(75, 23);
            this.btnMoveOff.TabIndex = 3;
            this.btnMoveOff.Text = "<<";
            this.btnMoveOff.UseVisualStyleBackColor = true;
            this.btnMoveOff.Click += new System.EventHandler(this.btnMoveOff_Click);
            // 
            // txtTeamName
            // 
            this.txtTeamName.Location = new System.Drawing.Point(43, 24);
            this.txtTeamName.Name = "txtTeamName";
            this.txtTeamName.Size = new System.Drawing.Size(115, 20);
            this.txtTeamName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Members Not on Team";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Members on Team";
            // 
            // cmbTeamType
            // 
            this.cmbTeamType.FormattingEnabled = true;
            this.cmbTeamType.Items.AddRange(new object[] {
            "Work Team",
            "Event Team",
            "Extracurricular Team"});
            this.cmbTeamType.Location = new System.Drawing.Point(264, 24);
            this.cmbTeamType.Name = "cmbTeamType";
            this.cmbTeamType.Size = new System.Drawing.Size(121, 21);
            this.cmbTeamType.TabIndex = 7;
            // 
            // btnAddMember
            // 
            this.btnAddMember.Location = new System.Drawing.Point(43, 263);
            this.btnAddMember.Name = "btnAddMember";
            this.btnAddMember.Size = new System.Drawing.Size(75, 23);
            this.btnAddMember.TabIndex = 8;
            this.btnAddMember.Text = "New Member";
            this.btnAddMember.UseVisualStyleBackColor = true;
            this.btnAddMember.Click += new System.EventHandler(this.btnAddMember_Click);
            // 
            // btnCancelTeam
            // 
            this.btnCancelTeam.Location = new System.Drawing.Point(68, 331);
            this.btnCancelTeam.Name = "btnCancelTeam";
            this.btnCancelTeam.Size = new System.Drawing.Size(75, 23);
            this.btnCancelTeam.TabIndex = 9;
            this.btnCancelTeam.Text = "Cancel";
            this.btnCancelTeam.UseVisualStyleBackColor = true;
            this.btnCancelTeam.Click += new System.EventHandler(this.btnCancelTeam_Click);
            // 
            // btnViewTeam
            // 
            this.btnViewTeam.Location = new System.Drawing.Point(180, 315);
            this.btnViewTeam.Name = "btnViewTeam";
            this.btnViewTeam.Size = new System.Drawing.Size(75, 39);
            this.btnViewTeam.TabIndex = 10;
            this.btnViewTeam.Text = "View Availability";
            this.btnViewTeam.UseVisualStyleBackColor = true;
            this.btnViewTeam.Click += new System.EventHandler(this.btnViewTeam_Click);
            // 
            // btnSaveTeam
            // 
            this.btnSaveTeam.Location = new System.Drawing.Point(296, 331);
            this.btnSaveTeam.Name = "btnSaveTeam";
            this.btnSaveTeam.Size = new System.Drawing.Size(75, 23);
            this.btnSaveTeam.TabIndex = 11;
            this.btnSaveTeam.Text = "Save";
            this.btnSaveTeam.UseVisualStyleBackColor = true;
            this.btnSaveTeam.Click += new System.EventHandler(this.btnSaveTeam_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Type of Team:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Team Name:";
            // 
            // nudAbsentee
            // 
            this.nudAbsentee.Location = new System.Drawing.Point(272, 283);
            this.nudAbsentee.Name = "nudAbsentee";
            this.nudAbsentee.Size = new System.Drawing.Size(120, 20);
            this.nudAbsentee.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(272, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Absentee Tolerance";
            // 
            // frmTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 379);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudAbsentee);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSaveTeam);
            this.Controls.Add(this.btnViewTeam);
            this.Controls.Add(this.btnCancelTeam);
            this.Controls.Add(this.btnAddMember);
            this.Controls.Add(this.cmbTeamType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTeamName);
            this.Controls.Add(this.btnMoveOff);
            this.Controls.Add(this.btnMoveOn);
            this.Controls.Add(this.lstMembersOn);
            this.Controls.Add(this.lstMembersOff);
            this.Name = "frmTeam";
            this.Text = "frmTeam";
            this.Load += new System.EventHandler(this.frmTeam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudAbsentee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstMembersOff;
        private System.Windows.Forms.ListBox lstMembersOn;
        private System.Windows.Forms.Button btnMoveOn;
        private System.Windows.Forms.Button btnMoveOff;
        private System.Windows.Forms.TextBox txtTeamName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTeamType;
        private System.Windows.Forms.Button btnAddMember;
        private System.Windows.Forms.Button btnCancelTeam;
        private System.Windows.Forms.Button btnViewTeam;
        private System.Windows.Forms.Button btnSaveTeam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudAbsentee;
        private System.Windows.Forms.Label label5;
    }
}