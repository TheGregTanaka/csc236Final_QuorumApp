namespace Scheduler
{
    partial class frmMemberMgmt
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
            this.btnCancelMemberMgmt = new System.Windows.Forms.Button();
            this.btnEditSelectedMember = new System.Windows.Forms.Button();
            this.btnAddNewMember = new System.Windows.Forms.Button();
            this.lstMembers = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnCancelMemberMgmt
            // 
            this.btnCancelMemberMgmt.Location = new System.Drawing.Point(218, 175);
            this.btnCancelMemberMgmt.Name = "btnCancelMemberMgmt";
            this.btnCancelMemberMgmt.Size = new System.Drawing.Size(75, 23);
            this.btnCancelMemberMgmt.TabIndex = 7;
            this.btnCancelMemberMgmt.Text = "Cancel";
            this.btnCancelMemberMgmt.UseVisualStyleBackColor = true;
            this.btnCancelMemberMgmt.Click += new System.EventHandler(this.btnCancelMemberMgmt_Click);
            // 
            // btnEditSelectedMember
            // 
            this.btnEditSelectedMember.Location = new System.Drawing.Point(218, 118);
            this.btnEditSelectedMember.Name = "btnEditSelectedMember";
            this.btnEditSelectedMember.Size = new System.Drawing.Size(75, 23);
            this.btnEditSelectedMember.TabIndex = 6;
            this.btnEditSelectedMember.Text = "Edit";
            this.btnEditSelectedMember.UseVisualStyleBackColor = true;
            this.btnEditSelectedMember.Click += new System.EventHandler(this.btnEditSelectedMember_Click);
            // 
            // btnAddNewMember
            // 
            this.btnAddNewMember.Location = new System.Drawing.Point(218, 62);
            this.btnAddNewMember.Name = "btnAddNewMember";
            this.btnAddNewMember.Size = new System.Drawing.Size(75, 23);
            this.btnAddNewMember.TabIndex = 5;
            this.btnAddNewMember.Text = "Add";
            this.btnAddNewMember.UseVisualStyleBackColor = true;
            this.btnAddNewMember.Click += new System.EventHandler(this.btnAddNewMember_Click);
            // 
            // lstMembers
            // 
            this.lstMembers.FormattingEnabled = true;
            this.lstMembers.Location = new System.Drawing.Point(33, 49);
            this.lstMembers.Name = "lstMembers";
            this.lstMembers.Size = new System.Drawing.Size(137, 160);
            this.lstMembers.TabIndex = 4;
            // 
            // frmMemberMgmt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 253);
            this.Controls.Add(this.btnCancelMemberMgmt);
            this.Controls.Add(this.btnEditSelectedMember);
            this.Controls.Add(this.btnAddNewMember);
            this.Controls.Add(this.lstMembers);
            this.Name = "frmMemberMgmt";
            this.Text = "Member Management";
            this.Load += new System.EventHandler(this.frmMemberMgmt_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelMemberMgmt;
        private System.Windows.Forms.Button btnEditSelectedMember;
        private System.Windows.Forms.Button btnAddNewMember;
        private System.Windows.Forms.ListBox lstMembers;
    }
}