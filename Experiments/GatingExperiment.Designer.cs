namespace Experiments
{
    partial class GatingExperiment
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtStimDirPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowseFile = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.grpSubjectDetails = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGroupID = new System.Windows.Forms.TextBox();
            this.txtSubjectID = new System.Windows.Forms.TextBox();
            this.lstFeedback = new System.Windows.Forms.ListBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuCalibrate = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSignalLevel = new System.Windows.Forms.TextBox();
            this.grpSubjectDetails.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stimulli Location:";
            // 
            // txtStimDirPath
            // 
            this.txtStimDirPath.Location = new System.Drawing.Point(102, 125);
            this.txtStimDirPath.Name = "txtStimDirPath";
            this.txtStimDirPath.Size = new System.Drawing.Size(388, 20);
            this.txtStimDirPath.TabIndex = 1;
            this.txtStimDirPath.Text = "H:\\Gated LPand HP sent";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(496, 125);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(57, 20);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Feedback Files:";
            // 
            // btnBrowseFile
            // 
            this.btnBrowseFile.Location = new System.Drawing.Point(496, 148);
            this.btnBrowseFile.Name = "btnBrowseFile";
            this.btnBrowseFile.Size = new System.Drawing.Size(57, 20);
            this.btnBrowseFile.TabIndex = 5;
            this.btnBrowseFile.Text = "Add...";
            this.btnBrowseFile.UseVisualStyleBackColor = true;
            this.btnBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(575, 125);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(93, 61);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // grpSubjectDetails
            // 
            this.grpSubjectDetails.Controls.Add(this.label3);
            this.grpSubjectDetails.Controls.Add(this.label5);
            this.grpSubjectDetails.Controls.Add(this.txtGroupID);
            this.grpSubjectDetails.Controls.Add(this.txtSubjectID);
            this.grpSubjectDetails.Location = new System.Drawing.Point(23, 27);
            this.grpSubjectDetails.Name = "grpSubjectDetails";
            this.grpSubjectDetails.Size = new System.Drawing.Size(290, 84);
            this.grpSubjectDetails.TabIndex = 7;
            this.grpSubjectDetails.TabStop = false;
            this.grpSubjectDetails.Text = "Subject Details";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "GroupID: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "SubjectID: ";
            // 
            // txtGroupID
            // 
            this.txtGroupID.Location = new System.Drawing.Point(94, 53);
            this.txtGroupID.Name = "txtGroupID";
            this.txtGroupID.Size = new System.Drawing.Size(166, 20);
            this.txtGroupID.TabIndex = 24;
            this.txtGroupID.Text = "a";
            // 
            // txtSubjectID
            // 
            this.txtSubjectID.Location = new System.Drawing.Point(94, 27);
            this.txtSubjectID.Name = "txtSubjectID";
            this.txtSubjectID.Size = new System.Drawing.Size(166, 20);
            this.txtSubjectID.TabIndex = 23;
            this.txtSubjectID.Text = "a";
            // 
            // lstFeedback
            // 
            this.lstFeedback.FormattingEnabled = true;
            this.lstFeedback.HorizontalScrollbar = true;
            this.lstFeedback.Items.AddRange(new object[] {
            "X:\\Res_Progs\\HAL\\gamepics\\d2d_sub_24.txt"});
            this.lstFeedback.Location = new System.Drawing.Point(102, 151);
            this.lstFeedback.Name = "lstFeedback";
            this.lstFeedback.Size = new System.Drawing.Size(388, 43);
            this.lstFeedback.TabIndex = 8;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(496, 174);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(57, 23);
            this.btnRemove.TabIndex = 9;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCalibrate});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(680, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuCalibrate
            // 
            this.mnuCalibrate.Name = "mnuCalibrate";
            this.mnuCalibrate.Size = new System.Drawing.Size(66, 20);
            this.mnuCalibrate.Text = "Calibrate";
            this.mnuCalibrate.Click += new System.EventHandler(this.mnuCalibrate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Signal Level:";
            // 
            // txtSignalLevel
            // 
            this.txtSignalLevel.Location = new System.Drawing.Point(102, 208);
            this.txtSignalLevel.Name = "txtSignalLevel";
            this.txtSignalLevel.Size = new System.Drawing.Size(47, 20);
            this.txtSignalLevel.TabIndex = 12;
            this.txtSignalLevel.Text = "60";
            // 
            // GatingExperiment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 320);
            this.Controls.Add(this.txtSignalLevel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lstFeedback);
            this.Controls.Add(this.grpSubjectDetails);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnBrowseFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtStimDirPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GatingExperiment";
            this.Text = "Gating Experiment Settings";
            this.Load += new System.EventHandler(this.GatingExperiment_Load);
            this.grpSubjectDetails.ResumeLayout(false);
            this.grpSubjectDetails.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStimDirPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowseFile;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox grpSubjectDetails;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGroupID;
        private System.Windows.Forms.TextBox txtSubjectID;
        private System.Windows.Forms.ListBox lstFeedback;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuCalibrate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSignalLevel;
    }
}

