namespace GenericCalibration
{
    partial class Calibrate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calibrate));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbWavAmp = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtWavLevel = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtWave = new System.Windows.Forms.TextBox();
            this.btnWaveBrowse = new System.Windows.Forms.Button();
            this.btnWave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAtVolume = new System.Windows.Forms.Button();
            this.rdPeak = new System.Windows.Forms.RadioButton();
            this.rdRms = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLevel = new System.Windows.Forms.TextBox();
            this.btnStop2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.txtBits = new System.Windows.Forms.TextBox();
            this.txtRef = new System.Windows.Forms.TextBox();
            this.txtFreq = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRecord = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRecordms = new System.Windows.Forms.TextBox();
            this.btnStopRecord = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.cmbWavAmp);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.txtWavLevel);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txtWave);
            this.groupBox4.Controls.Add(this.btnWaveBrowse);
            this.groupBox4.Controls.Add(this.btnWave);
            this.groupBox4.Location = new System.Drawing.Point(8, 225);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(688, 104);
            this.groupBox4.TabIndex = 47;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Play Wave File";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(16, 72);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(104, 23);
            this.label14.TabIndex = 36;
            this.label14.Text = "Level:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbWavAmp
            // 
            this.cmbWavAmp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWavAmp.Items.AddRange(new object[] {
            "RMS",
            "Peak",
            "None"});
            this.cmbWavAmp.Location = new System.Drawing.Point(120, 48);
            this.cmbWavAmp.Name = "cmbWavAmp";
            this.cmbWavAmp.Size = new System.Drawing.Size(104, 21);
            this.cmbWavAmp.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(16, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 23);
            this.label11.TabIndex = 34;
            this.label11.Text = "Amplification Type:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtWavLevel
            // 
            this.txtWavLevel.Location = new System.Drawing.Point(120, 72);
            this.txtWavLevel.Name = "txtWavLevel";
            this.txtWavLevel.Size = new System.Drawing.Size(104, 20);
            this.txtWavLevel.TabIndex = 18;
            this.txtWavLevel.Text = "80";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(56, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 23);
            this.label8.TabIndex = 32;
            this.label8.Text = "Wave File:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtWave
            // 
            this.txtWave.Location = new System.Drawing.Point(120, 24);
            this.txtWave.Name = "txtWave";
            this.txtWave.Size = new System.Drawing.Size(472, 20);
            this.txtWave.TabIndex = 16;
            // 
            // btnWaveBrowse
            // 
            this.btnWaveBrowse.Location = new System.Drawing.Point(600, 23);
            this.btnWaveBrowse.Name = "btnWaveBrowse";
            this.btnWaveBrowse.Size = new System.Drawing.Size(80, 23);
            this.btnWaveBrowse.TabIndex = 15;
            this.btnWaveBrowse.Text = "Browse";
            this.btnWaveBrowse.Click += new System.EventHandler(this.btnWaveBrowse_Click);
            // 
            // btnWave
            // 
            this.btnWave.Image = ((System.Drawing.Image)(resources.GetObject("btnWave.Image")));
            this.btnWave.Location = new System.Drawing.Point(248, 48);
            this.btnWave.Name = "btnWave";
            this.btnWave.Size = new System.Drawing.Size(80, 48);
            this.btnWave.TabIndex = 19;
            this.btnWave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnWave.Click += new System.EventHandler(this.btnWave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.btnAtVolume);
            this.groupBox2.Controls.Add(this.rdPeak);
            this.groupBox2.Controls.Add(this.rdRms);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtLevel);
            this.groupBox2.Controls.Add(this.btnStop2);
            this.groupBox2.Location = new System.Drawing.Point(8, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(376, 104);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Test Calibration";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(8, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 23);
            this.label9.TabIndex = 35;
            this.label9.Text = "Attenuation Mode:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAtVolume
            // 
            this.btnAtVolume.Image = ((System.Drawing.Image)(resources.GetObject("btnAtVolume.Image")));
            this.btnAtVolume.Location = new System.Drawing.Point(224, 25);
            this.btnAtVolume.Name = "btnAtVolume";
            this.btnAtVolume.Size = new System.Drawing.Size(80, 23);
            this.btnAtVolume.TabIndex = 7;
            this.btnAtVolume.Click += new System.EventHandler(this.btnAtVolume_Click);
            // 
            // rdPeak
            // 
            this.rdPeak.Checked = true;
            this.rdPeak.Location = new System.Drawing.Point(112, 24);
            this.rdPeak.Name = "rdPeak";
            this.rdPeak.Size = new System.Drawing.Size(56, 24);
            this.rdPeak.TabIndex = 33;
            this.rdPeak.TabStop = true;
            this.rdPeak.Text = "Peak";
            // 
            // rdRms
            // 
            this.rdRms.Location = new System.Drawing.Point(168, 24);
            this.rdRms.Name = "rdRms";
            this.rdRms.Size = new System.Drawing.Size(56, 24);
            this.rdRms.TabIndex = 34;
            this.rdRms.Text = "RMS";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(32, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 26;
            this.label2.Text = "Target dB:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLevel
            // 
            this.txtLevel.Location = new System.Drawing.Point(112, 48);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Size = new System.Drawing.Size(100, 20);
            this.txtLevel.TabIndex = 6;
            this.txtLevel.Text = "80";
            // 
            // btnStop2
            // 
            this.btnStop2.Image = ((System.Drawing.Image)(resources.GetObject("btnStop2.Image")));
            this.btnStop2.Location = new System.Drawing.Point(224, 72);
            this.btnStop2.Name = "btnStop2";
            this.btnStop2.Size = new System.Drawing.Size(80, 23);
            this.btnStop2.TabIndex = 8;
            this.btnStop2.Click += new System.EventHandler(this.btnStop2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnPlay);
            this.groupBox1.Controls.Add(this.txtBits);
            this.groupBox1.Controls.Add(this.txtRef);
            this.groupBox1.Controls.Add(this.txtFreq);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Location = new System.Drawing.Point(8, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 100);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set Calibration Level";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ref dB Level:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPlay
            // 
            this.btnPlay.Image = ((System.Drawing.Image)(resources.GetObject("btnPlay.Image")));
            this.btnPlay.Location = new System.Drawing.Point(224, 23);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(80, 23);
            this.btnPlay.TabIndex = 4;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // txtBits
            // 
            this.txtBits.Location = new System.Drawing.Point(96, 48);
            this.txtBits.Name = "txtBits";
            this.txtBits.Size = new System.Drawing.Size(100, 20);
            this.txtBits.TabIndex = 2;
            this.txtBits.Text = "24";
            // 
            // txtRef
            // 
            this.txtRef.Location = new System.Drawing.Point(96, 72);
            this.txtRef.Name = "txtRef";
            this.txtRef.Size = new System.Drawing.Size(100, 20);
            this.txtRef.TabIndex = 3;
            this.txtRef.Text = "110";
            // 
            // txtFreq
            // 
            this.txtFreq.Location = new System.Drawing.Point(96, 24);
            this.txtFreq.Name = "txtFreq";
            this.txtFreq.Size = new System.Drawing.Size(100, 20);
            this.txtFreq.TabIndex = 1;
            this.txtFreq.Text = "1000";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(24, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Test Freq:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bit Resolution:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnStop
            // 
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.Location = new System.Drawing.Point(224, 71);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(80, 23);
            this.btnStop.TabIndex = 5;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(608, 33);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 23);
            this.btnOK.TabIndex = 43;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnRecord);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtRecordms);
            this.groupBox3.Controls.Add(this.btnStopRecord);
            this.groupBox3.Location = new System.Drawing.Point(8, 335);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(376, 104);
            this.groupBox3.TabIndex = 46;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Record";
            // 
            // btnRecord
            // 
            this.btnRecord.Image = ((System.Drawing.Image)(resources.GetObject("btnRecord.Image")));
            this.btnRecord.Location = new System.Drawing.Point(224, 25);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(80, 23);
            this.btnRecord.TabIndex = 7;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(24, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 23);
            this.label6.TabIndex = 26;
            this.label6.Text = "Milliseconds:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRecordms
            // 
            this.txtRecordms.Location = new System.Drawing.Point(112, 24);
            this.txtRecordms.Name = "txtRecordms";
            this.txtRecordms.Size = new System.Drawing.Size(100, 20);
            this.txtRecordms.TabIndex = 6;
            this.txtRecordms.Text = "1000";
            // 
            // btnStopRecord
            // 
            this.btnStopRecord.Image = ((System.Drawing.Image)(resources.GetObject("btnStopRecord.Image")));
            this.btnStopRecord.Location = new System.Drawing.Point(224, 72);
            this.btnStopRecord.Name = "btnStopRecord";
            this.btnStopRecord.Size = new System.Drawing.Size(80, 23);
            this.btnStopRecord.TabIndex = 8;
            this.btnStopRecord.Click += new System.EventHandler(this.btnStopRecord_Click);
            // 
            // Calibrate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 462);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Calibrate";
            this.Text = "Calibrate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Calibrate_FormClosing);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbWavAmp;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtWavLevel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtWave;
        private System.Windows.Forms.Button btnWaveBrowse;
        private System.Windows.Forms.Button btnWave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnAtVolume;
        private System.Windows.Forms.RadioButton rdPeak;
        private System.Windows.Forms.RadioButton rdRms;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLevel;
        private System.Windows.Forms.Button btnStop2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.TextBox txtBits;
        private System.Windows.Forms.TextBox txtRef;
        private System.Windows.Forms.TextBox txtFreq;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRecordms;
        private System.Windows.Forms.Button btnStopRecord;
    }
}