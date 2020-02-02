namespace Scheduler
{
    partial class frmAvailability
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
            this.components = new System.ComponentModel.Container();
            this.cmbViewTeam = new System.Windows.Forms.ComboBox();
            this.dgvAvailability = new System.Windows.Forms.DataGridView();
            this.Sunday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tuesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wednesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thursday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Friday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saturday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.availabilityDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.availabilityDataSet = new Scheduler.availabilityDataSet();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailability)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.availabilityDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.availabilityDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbViewTeam
            // 
            this.cmbViewTeam.FormattingEnabled = true;
            this.cmbViewTeam.Location = new System.Drawing.Point(194, 13);
            this.cmbViewTeam.Name = "cmbViewTeam";
            this.cmbViewTeam.Size = new System.Drawing.Size(121, 21);
            this.cmbViewTeam.TabIndex = 0;
            this.cmbViewTeam.SelectedIndexChanged += new System.EventHandler(this.cmbCurrentTeam_SelectedIndexChanged);
            // 
            // dgvAvailability
            // 
            this.dgvAvailability.AllowUserToAddRows = false;
            this.dgvAvailability.AllowUserToDeleteRows = false;
            this.dgvAvailability.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailability.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sunday,
            this.Monday,
            this.Tuesday,
            this.Wednesday,
            this.Thursday,
            this.Friday,
            this.Saturday});
            this.dgvAvailability.Location = new System.Drawing.Point(27, 138);
            this.dgvAvailability.Name = "dgvAvailability";
            this.dgvAvailability.ReadOnly = true;
            this.dgvAvailability.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvAvailability.Size = new System.Drawing.Size(749, 195);
            this.dgvAvailability.TabIndex = 1;
            // 
            // Sunday
            // 
            this.Sunday.HeaderText = "Sunday";
            this.Sunday.Name = "Sunday";
            this.Sunday.ReadOnly = true;
            // 
            // Monday
            // 
            this.Monday.HeaderText = "Monday";
            this.Monday.Name = "Monday";
            this.Monday.ReadOnly = true;
            // 
            // Tuesday
            // 
            this.Tuesday.HeaderText = "Tuesday";
            this.Tuesday.Name = "Tuesday";
            this.Tuesday.ReadOnly = true;
            // 
            // Wednesday
            // 
            this.Wednesday.HeaderText = "Wednesday";
            this.Wednesday.Name = "Wednesday";
            this.Wednesday.ReadOnly = true;
            // 
            // Thursday
            // 
            this.Thursday.HeaderText = "Thursday";
            this.Thursday.Name = "Thursday";
            this.Thursday.ReadOnly = true;
            // 
            // Friday
            // 
            this.Friday.HeaderText = "Friday";
            this.Friday.Name = "Friday";
            this.Friday.ReadOnly = true;
            // 
            // Saturday
            // 
            this.Saturday.HeaderText = "Saturday";
            this.Saturday.Name = "Saturday";
            this.Saturday.ReadOnly = true;
            // 
            // availabilityDataSetBindingSource
            // 
            this.availabilityDataSetBindingSource.DataSource = this.availabilityDataSet;
            this.availabilityDataSetBindingSource.Position = 0;
            // 
            // availabilityDataSet
            // 
            this.availabilityDataSet.DataSetName = "availabilityDataSet";
            this.availabilityDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "View Team:";
            // 
            // frmAvailability
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvAvailability);
            this.Controls.Add(this.cmbViewTeam);
            this.Name = "frmAvailability";
            this.Text = "frmAvailability";
            this.Load += new System.EventHandler(this.frmAvailability_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailability)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.availabilityDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.availabilityDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbViewTeam;
        private System.Windows.Forms.DataGridView dgvAvailability;
        private System.Windows.Forms.BindingSource availabilityDataSetBindingSource;
        private availabilityDataSet availabilityDataSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sunday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tuesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wednesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thursday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Friday;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saturday;
        private System.Windows.Forms.Label label1;
    }
}