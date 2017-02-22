namespace Experiments
{
    partial class GatingControlPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GatingControlPanel));
            this.dgResults = new System.Windows.Forms.DataGridView();
            this.btnKnock = new System.Windows.Forms.Button();
            this.lblSubjectName = new System.Windows.Forms.Label();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.dgSummary = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrintReport = new System.Windows.Forms.Button();
            this.btnPrintSummary = new System.Windows.Forms.Button();
            this.btnExportExcelSummary = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.m_print = new System.Drawing.Printing.PrintDocument();
            this.axAgent1 = new AxAgentObjects.AxAgent();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRobby = new System.Windows.Forms.Button();
            this.btnPeedy = new System.Windows.Forms.Button();
            this.btnMerlin = new System.Windows.Forms.Button();
            this.btnGenie = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnIncorrect = new System.Windows.Forms.Button();
            this.btnCorrect = new System.Windows.Forms.Button();
            this.tbuserResonse = new System.Windows.Forms.TextBox();
            this.lbluserResonse = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axAgent1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgResults
            // 
            this.dgResults.AllowUserToAddRows = false;
            this.dgResults.AllowUserToDeleteRows = false;
            this.dgResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgResults.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgResults.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResults.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgResults.EnableHeadersVisualStyles = false;
            this.dgResults.Location = new System.Drawing.Point(12, 64);
            this.dgResults.MultiSelect = false;
            this.dgResults.Name = "dgResults";
            this.dgResults.RowHeadersVisible = false;
            this.dgResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgResults.Size = new System.Drawing.Size(867, 310);
            this.dgResults.TabIndex = 0;
            this.dgResults.Tag = "Reports";
            this.dgResults.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgResults_RowsAdded);
            // 
            // btnKnock
            // 
            this.btnKnock.Location = new System.Drawing.Point(230, 530);
            this.btnKnock.Name = "btnKnock";
            this.btnKnock.Size = new System.Drawing.Size(60, 32);
            this.btnKnock.TabIndex = 1;
            this.btnKnock.Text = "Knock";
            this.btnKnock.UseVisualStyleBackColor = true;
            this.btnKnock.Visible = false;
            this.btnKnock.Click += new System.EventHandler(this.btnKnock_Click);
            // 
            // lblSubjectName
            // 
            this.lblSubjectName.AutoSize = true;
            this.lblSubjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubjectName.Location = new System.Drawing.Point(16, 31);
            this.lblSubjectName.Name = "lblSubjectName";
            this.lblSubjectName.Size = new System.Drawing.Size(117, 16);
            this.lblSubjectName.TabIndex = 4;
            this.lblSubjectName.Text = "Subject Details:";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.Location = new System.Drawing.Point(706, 38);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(101, 20);
            this.btnExportExcel.TabIndex = 6;
            this.btnExportExcel.Text = "Export To Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // dgSummary
            // 
            this.dgSummary.AllowUserToAddRows = false;
            this.dgSummary.AllowUserToDeleteRows = false;
            this.dgSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dgSummary.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSummary.Location = new System.Drawing.Point(428, 404);
            this.dgSummary.MultiSelect = false;
            this.dgSummary.Name = "dgSummary";
            this.dgSummary.ReadOnly = true;
            this.dgSummary.RowHeadersVisible = false;
            this.dgSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSummary.Size = new System.Drawing.Size(451, 158);
            this.dgSummary.TabIndex = 7;
            this.dgSummary.Tag = "Summary";
            this.dgSummary.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgSummary_RowsAdded);
            this.dgSummary.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSummary_CellContentClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(425, 388);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Summary:";
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintReport.Location = new System.Drawing.Point(813, 38);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(66, 20);
            this.btnPrintReport.TabIndex = 9;
            this.btnPrintReport.Text = "Print";
            this.btnPrintReport.UseVisualStyleBackColor = true;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // btnPrintSummary
            // 
            this.btnPrintSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintSummary.Location = new System.Drawing.Point(831, 381);
            this.btnPrintSummary.Name = "btnPrintSummary";
            this.btnPrintSummary.Size = new System.Drawing.Size(48, 20);
            this.btnPrintSummary.TabIndex = 10;
            this.btnPrintSummary.Text = "Print";
            this.btnPrintSummary.UseVisualStyleBackColor = true;
            this.btnPrintSummary.Click += new System.EventHandler(this.btnPrintSummary_Click);
            // 
            // btnExportExcelSummary
            // 
            this.btnExportExcelSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcelSummary.Location = new System.Drawing.Point(725, 381);
            this.btnExportExcelSummary.Name = "btnExportExcelSummary";
            this.btnExportExcelSummary.Size = new System.Drawing.Size(100, 20);
            this.btnExportExcelSummary.TabIndex = 11;
            this.btnExportExcelSummary.Text = "Export To Excel";
            this.btnExportExcelSummary.UseVisualStyleBackColor = true;
            this.btnExportExcelSummary.Click += new System.EventHandler(this.btnExportExcelSummary_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Run Time Report:";
            // 
            // m_print
            // 
            this.m_print.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_print_PrintPage);
            // 
            // axAgent1
            // 
            this.axAgent1.Enabled = true;
            this.axAgent1.Location = new System.Drawing.Point(371, 530);
            this.axAgent1.Name = "axAgent1";
            this.axAgent1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAgent1.OcxState")));
            this.axAgent1.Size = new System.Drawing.Size(32, 32);
            this.axAgent1.TabIndex = 13;
            this.axAgent1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnRobby);
            this.groupBox1.Controls.Add(this.btnPeedy);
            this.groupBox1.Controls.Add(this.btnMerlin);
            this.groupBox1.Controls.Add(this.btnGenie);
            this.groupBox1.Location = new System.Drawing.Point(19, 520);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 50);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Feedback Characters";
            this.groupBox1.Visible = false;
            // 
            // btnRobby
            // 
            this.btnRobby.BackgroundImage = global::Experiments.Properties.Resources.robby;
            this.btnRobby.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRobby.Location = new System.Drawing.Point(137, 13);
            this.btnRobby.Name = "btnRobby";
            this.btnRobby.Size = new System.Drawing.Size(37, 31);
            this.btnRobby.TabIndex = 3;
            this.btnRobby.Tag = "3";
            this.btnRobby.UseVisualStyleBackColor = true;
            this.btnRobby.Click += new System.EventHandler(this.btnGenie_Click);
            // 
            // btnPeedy
            // 
            this.btnPeedy.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPeedy.BackgroundImage = global::Experiments.Properties.Resources.peedy;
            this.btnPeedy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPeedy.Location = new System.Drawing.Point(94, 13);
            this.btnPeedy.Name = "btnPeedy";
            this.btnPeedy.Size = new System.Drawing.Size(32, 32);
            this.btnPeedy.TabIndex = 2;
            this.btnPeedy.Tag = "2";
            this.btnPeedy.UseVisualStyleBackColor = true;
            this.btnPeedy.Click += new System.EventHandler(this.btnGenie_Click);
            // 
            // btnMerlin
            // 
            this.btnMerlin.BackgroundImage = global::Experiments.Properties.Resources.merlin;
            this.btnMerlin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMerlin.Location = new System.Drawing.Point(51, 13);
            this.btnMerlin.Name = "btnMerlin";
            this.btnMerlin.Size = new System.Drawing.Size(37, 31);
            this.btnMerlin.TabIndex = 1;
            this.btnMerlin.Tag = "1";
            this.btnMerlin.UseVisualStyleBackColor = true;
            this.btnMerlin.Click += new System.EventHandler(this.btnGenie_Click);
            // 
            // btnGenie
            // 
            this.btnGenie.BackgroundImage = global::Experiments.Properties.Resources.genie;
            this.btnGenie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenie.Location = new System.Drawing.Point(6, 13);
            this.btnGenie.Name = "btnGenie";
            this.btnGenie.Size = new System.Drawing.Size(37, 31);
            this.btnGenie.TabIndex = 0;
            this.btnGenie.Tag = "0";
            this.btnGenie.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGenie.UseVisualStyleBackColor = true;
            this.btnGenie.Click += new System.EventHandler(this.btnGenie_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPlay.Image = global::Experiments.Properties.Resources.Play1;
            this.btnPlay.Location = new System.Drawing.Point(16, 395);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(113, 107);
            this.btnPlay.TabIndex = 5;
            this.btnPlay.Text = "Play";
            this.btnPlay.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPlay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnIncorrect
            // 
            this.btnIncorrect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIncorrect.Image = global::Experiments.Properties.Resources.wrong;
            this.btnIncorrect.Location = new System.Drawing.Point(135, 395);
            this.btnIncorrect.Name = "btnIncorrect";
            this.btnIncorrect.Size = new System.Drawing.Size(114, 107);
            this.btnIncorrect.TabIndex = 3;
            this.btnIncorrect.Text = "Incorrect";
            this.btnIncorrect.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnIncorrect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnIncorrect.UseVisualStyleBackColor = true;
            this.btnIncorrect.Click += new System.EventHandler(this.btnIncorrect_Click);
            // 
            // btnCorrect
            // 
            this.btnCorrect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCorrect.Image = global::Experiments.Properties.Resources.tick1;
            this.btnCorrect.Location = new System.Drawing.Point(265, 395);
            this.btnCorrect.Name = "btnCorrect";
            this.btnCorrect.Size = new System.Drawing.Size(113, 107);
            this.btnCorrect.TabIndex = 2;
            this.btnCorrect.Text = "Correct";
            this.btnCorrect.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCorrect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCorrect.UseVisualStyleBackColor = true;
            this.btnCorrect.Click += new System.EventHandler(this.btnCorrect_Click);
            // 
            // tbuserResonse
            // 
            this.tbuserResonse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbuserResonse.Enabled = false;
            this.tbuserResonse.Location = new System.Drawing.Point(275, 508);
            this.tbuserResonse.Name = "tbuserResonse";
            this.tbuserResonse.Size = new System.Drawing.Size(82, 20);
            this.tbuserResonse.TabIndex = 15;
           
            // 
            // lbluserResonse
            // 
            this.lbluserResonse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbluserResonse.AutoSize = true;
            this.lbluserResonse.Location = new System.Drawing.Point(183, 511);
            this.lbluserResonse.Name = "lbluserResonse";
            this.lbluserResonse.Size = new System.Drawing.Size(80, 13);
            this.lbluserResonse.TabIndex = 16;
            this.lbluserResonse.Text = "User Response";
            // 
            // GatingControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 574);
            this.Controls.Add(this.lbluserResonse);
            this.Controls.Add(this.tbuserResonse);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.axAgent1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExportExcelSummary);
            this.Controls.Add(this.btnPrintSummary);
            this.Controls.Add(this.btnPrintReport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgSummary);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.lblSubjectName);
            this.Controls.Add(this.btnIncorrect);
            this.Controls.Add(this.btnCorrect);
            this.Controls.Add(this.btnKnock);
            this.Controls.Add(this.dgResults);
            this.Name = "GatingControlPanel";
            this.Text = "GatingControlPanel";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GatingControlPanel_MouseClick);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GatingControlPanel_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axAgent1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgResults;
        private System.Windows.Forms.Button btnKnock;
        private System.Windows.Forms.Button btnCorrect;
        private System.Windows.Forms.Button btnIncorrect;
        private System.Windows.Forms.Label lblSubjectName;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.DataGridView dgSummary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrintReport;
        private System.Windows.Forms.Button btnPrintSummary;
        private System.Windows.Forms.Button btnExportExcelSummary;
        private System.Windows.Forms.Label label2;
        private System.Drawing.Printing.PrintDocument m_print;
        private AxAgentObjects.AxAgent axAgent1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRobby;
        private System.Windows.Forms.Button btnPeedy;
        private System.Windows.Forms.Button btnMerlin;
        private System.Windows.Forms.Button btnGenie;
        private System.Windows.Forms.TextBox tbuserResonse;
        private System.Windows.Forms.Label lbluserResonse;
    }
}