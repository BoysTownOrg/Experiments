using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Audio;

namespace GenericCalibration
{
    public partial class Calibrate : Form
    {
        Audio.SoundCard sc;
        private double _caldb;
        public double CalDb { get { return _caldb; } set { _caldb = value; txtRef.Text = value.ToString(); } }
        public Calibrate(Audio.SoundCard card)
        {
            InitializeComponent();
            sc = card;
            sc.OpenSoundCard();
            cmbWavAmp.SelectedIndex = 0;
            txtRef.Text = CalDb.ToString();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            MemoryStream ms;
            int nFreq = int.Parse(txtFreq.Text);
            bool b = Generator.PureTone(ARSC.SCALE_32BIT, nFreq, 4000, 20, 20, out ms);

            //Write ms to the end of ms to add the second channel
            ms.Seek(0, SeekOrigin.End);
            ms.Write(ms.ToArray(), 0, (int)ms.Length);
            int[] nSize = new int[2];
            FileInfo f = new FileInfo(@"\cal.wav");//(@"C:\cal.wav");
            nSize[0] = (int)(ms.Length / 2) / 4;
            nSize[1] = 0;
            btnStop.Focus();
            sc.PlayMemoryStream(ms, nSize, 1);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            sc.Stop();
        }

        private void btnAtVolume_Click(object sender, EventArgs e)
        {
            double Cal = double.Parse(txtRef.Text);
            double Level = double.Parse(txtLevel.Text);
            int nFreq = int.Parse(txtFreq.Text);
            bool bPeak = true;
            if (rdRms.Checked == true)
                bPeak = false;
            MemoryStream ms;
           Audio.Generator.PureTone(Audio.ARSC.SCALE_32BIT, nFreq, 4000, 20, 20, out ms);
            //Write ms to the end of ms to add the second channel
            ms.Seek(0, SeekOrigin.End);
            ms.Write(ms.ToArray(), 0, (int)ms.Length);
            //get int representation of the level
            //Cal is for SCALE_32Bit
            Level -= Cal;
            int BigInt = (int)(Audio.ARSC.SCALE_32BIT * (Math.Pow(10, Level / 20.0)));
            if (bPeak)
                ms = Audio.Generator.SetPeakLevel(ms, BigInt);
            else
                ms = Audio.Generator.SetRmsLevel(ms, BigInt);
            btnStop2.Focus();
            int[] nSize = new int[2];
            nSize[0] = (int)(ms.Length / 2) / 4;
            nSize[1] = 0;
            sc.PlayMemoryStream(ms, nSize, 1);
        }

        private void btnStop2_Click(object sender, EventArgs e)
        {
            sc.Stop();
        }

        private void btnWaveBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Wave file (*.wav)|*.wav";
            dlg.Filter += "|All files|*.*";
            dlg.Multiselect = false;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtWave.Text = dlg.FileName;
            }
        }

        private void btnWave_Click(object sender, EventArgs e)
        {
            double Cal = double.Parse(txtRef.Text);
            double Level = double.Parse(txtWavLevel.Text);
           // bool bPeak = true;

            
            //if (this.cmbWavAmp.Text == "RMS")
            //    bPeak = false;
            FileInfo f = new FileInfo(txtWave.Text);
            if (f.Exists == false)
                return;
            Level -= Cal;
            int BigInt = (int)(Audio.ARSC.SCALE_32BIT * (Math.Pow(10, Level / 20.0)));
            MemoryStream ms = sc.LoadWave(f.FullName);
            if (this.cmbWavAmp.Text  == "Peak")
                ms = Audio.Generator.SetPeakLevel(ms, BigInt);
            else if (this.cmbWavAmp.Text == "RMS")
                ms = Audio.Generator.SetRmsLevel(ms, BigInt);
            
            int[] nSize = new int[2];
            nSize[0] = (int)(ms.Length / 2) / 4;
            nSize[1] = 0;
            sc.PlayMemoryStream(ms, nSize, 1);
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            MemoryStream msLeft, msRight;
            int nSeconds = int.Parse(txtRecordms.Text);
            this.btnStopRecord.Focus();
            sc.Record(out msLeft, out msRight, nSeconds);
            FileInfo f = new FileInfo(@"\cal.wav");//(@"C:\cal.wav");
            //Btnrh.ARSCLib.Generator.WriteWaveFile(f,msLeft,msRight,24);
            Audio.Generator.WriteWaveFile(f, msLeft, msRight, 32);
            MessageBox.Show(@"Data Written to C:\cal.wav", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Stop);
	
        }

        private void btnStopRecord_Click(object sender, EventArgs e)
        {
            sc.Stop();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                CalDb = double.Parse(txtRef.Text);
            }
            catch (Exception err)
            {
                MessageBox.Show("Please enter numeric values only for Reference dB!");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Calibrate_FormClosing(object sender, FormClosingEventArgs e)
        {
            sc.CloseSoundCard();
        }
    }
}
