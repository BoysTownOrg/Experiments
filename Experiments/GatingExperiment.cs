using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Audio;
using GenericCalibration;



namespace Experiments
{
    public partial class GatingExperiment : Form
    {
        
        Subject cSubject;
        double CalDb = 100;
        GatingControlPanel gc;
        public GatingExperiment()
        {
            InitializeComponent();
        }
       
        private void btnStart_Click(object sender, EventArgs e)
        {
           
            if (!ValidateControls()) return;
            
            //construct subject
            cSubject = new Subject();
            cSubject.SubjectID = txtSubjectID.Text;
            cSubject.GroupID = txtGroupID.Text;

            //Construct Test
            GateUnit GateTest = new GateUnit();
            GateTest.feedbackfiles = new string[lstFeedback.Items.Count];
            this.lstFeedback.Items.CopyTo(GateTest.feedbackfiles,0);
            GateTest.strDirPath = this.txtStimDirPath.Text;

            string destinationFolder = GateTest.strDirPath + "\\" + cSubject.SubjectID;

            if (Directory.Exists(destinationFolder))
            {
                GateTest.strDirPath = destinationFolder;
                gc = new GatingControlPanel(cSubject, GateTest, true);
            }
            else
            {
                gc = new GatingControlPanel(cSubject, GateTest, false);
            }
            GateTest.Level = int.Parse(txtSignalLevel.Text) - (int)this.CalDb;
            //construct Test Control panel 
            //setup visual
            gc.Show();

        
         
           
           
        }
        public bool ValidateControls()
        {
            StringBuilder sb = new StringBuilder();
            if (CalDb == 0) sb.AppendLine("Please Calibrate");
            try
            {
                int.Parse(txtSignalLevel.Text);
            }
            catch (Exception)
            {
                sb.AppendLine("Please Enter proper value for Signal Level");
            }
            if (!Directory.Exists(txtStimDirPath.Text))
            {
                MessageBox.Show("Stim directory not found.");
                return false;
            }
            if (sb.ToString().Trim().Length == 0)
                return true;
            else
            {
                MessageBox.Show(sb.ToString());
                return false;
            }
           
            
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtStimDirPath.Text = fd.SelectedPath;
            }
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                lstFeedback.Items.AddRange(fd.FileNames);
            }
            
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstFeedback.SelectedIndex < 0) return;
            lstFeedback.Items.RemoveAt(lstFeedback.SelectedIndex);
        }

        private void mnuCalibrate_Click(object sender, EventArgs e)
        {
            SoundCard sc = new SoundCard();
            bool b = sc.OpenSoundCard();
            GenericCalibration.Calibrate dlg = new Calibrate(sc);
            dlg.CalDb = this.CalDb;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CalDb = dlg.CalDb;
            }
            if (sc.Open) sc.CloseSoundCard();
        }

        private void GatingExperiment_Load(object sender, EventArgs e)
        {
           this.Location =  Screen.PrimaryScreen.Bounds.Location;
        }

   
    }
}
