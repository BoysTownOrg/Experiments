using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using Audio;
using Experiments.Properties;
using FeedbackVisual;

namespace Experiments
{
    public partial class GatingControlPanel : Form
    {
        Random r;
        public GameForm FeedbackGame;
        public Response FeedbackResponse;
        private BindingList<GateReporter> Reports = new BindingList<GateReporter>(); //
        AgentController []myAgents;
        AgentController CurrentAgent;
        private Subject subject;
        private GateUnit gateTest;
        private Color[] colors = new Color[3];
        string[] Animations = { "Dance", "Jump", "Process", "Magic","GetAttention" };
        Settings appsetting = new Settings();
        private Nullable <bool> lastCorrect = null;
        private Nullable<int> Score = null;
        private Nullable<bool> previouscorrect;
        private Nullable<int> previousscore;
        private bool BreakTakenBefore = false;
        
        
        public GatingControlPanel( Subject s , GateUnit gu)
        {
            InitializeComponent();
            subject = s;
            gateTest = gu;
            
            //setup audio       
            string[] allFiles = Directory.GetFiles(gateTest.strDirPath, "*BW*.wav", SearchOption.TopDirectoryOnly);
            gateTest.SetupGame(allFiles);
            Reports.Clear();
            dgResults.DataSource = Reports;

            dgSummary.DataSource = gateTest.WordSummary;
            //setup visual
            FeedbackGame = new GameForm();
            FeedbackGame.SetupGame(gu.feedbackfiles, gu.NumOfWords * 10);//assuming 10 gates per word
             if (appsetting.DisplayGames)
            {
                FeedbackGame.Move += new EventHandler(FeedbackGame_Move);                
                FeedbackGame.Show();
            
            }
            else
            {
                if (appsetting.UserInputDisplay)
                {
                    FeedbackResponse = new Response();
                    FeedbackResponse.Show();
                    FeedbackResponse.UserResponded += new Response.ButtonClicked(FeedbackResponse_UserResponded);
                }
            }

            lblSubjectName.Text = "SubjectID: "+subject.SubjectID + " GroupID: " + subject.GroupID;
            
            colors[0] = Color.White; //normal
            colors[1] = Color.FromArgb(192, 192, 255); //for correct entries
            colors[2] = Color.FromArgb(192, 255, 192);//for first stim of this word
            Step(false);
            //column populated by Step() above. Now manage width.
            dgResults.Columns[0].Width = 80;
            dgResults.Columns[1].Width = 80;
            dgResults.Columns[2].Width = 80;
            //Column[3] takes up rest of the space
            dgResults.Columns[4].Width =80;
            dgResults.Columns[5].Width = 80;
            dgResults.Columns[6].Width = 80;
            //create animation agent
            myAgents = new AgentController[4];
            myAgents[0] = new AgentController(axAgent1, "genie.acs");
            myAgents[1] = new AgentController(axAgent1, "merlin.acs");
            myAgents[2] = new AgentController(axAgent1, "peedy.acs");
            myAgents[3] = new AgentController(axAgent1, "robby.acs");
            CurrentAgent = myAgents[0];
            SetAgentsHome();//set home positions to agents
            r = new Random();

            this.Location = Screen.PrimaryScreen.Bounds.Location;
           
        }

        public GatingControlPanel(Subject s, GateUnit gu, bool breakTaken):
            this(s,gu)
        {
            BreakTakenBefore = breakTaken;
        }

        void FeedbackResponse_UserResponded(int number)
        {
            tbuserResonse.Text = number.ToString();  
            ManageInputAndButtonPlayState();
            UpdateScore(tbuserResonse.Text);
        
        }

        void FeedbackGame_Move(object sender, EventArgs e)
        {
            SetAgentsHome();
        }
        /// <summary>
        /// Sets home position to Agents.
        /// </summary>
        private void SetAgentsHome()
        {
            myAgents[0].HomeX = FeedbackGame.Location.X +(int)(.87 * FeedbackGame.Width);
            myAgents[1].HomeX = FeedbackGame.Location.X+(int)(.87 * FeedbackGame.Width);
            myAgents[2].HomeX = FeedbackGame.Location.X+(int)(.87 * FeedbackGame.Width)-15;//peedy has large body
            myAgents[3].HomeX = FeedbackGame.Location.X+(int)(.87 * FeedbackGame.Width);

            myAgents[0].HomeY = 30;
            myAgents[1].HomeY = myAgents[0].HomeY + 130;
            myAgents[2].HomeY = myAgents[1].HomeY + 130;
            myAgents[3].HomeY = myAgents[2].HomeY + 130;
        }
        /// <summary>
        /// Moves one step in experiment
        /// </summary>
        /// <param name="prevResult">Did subject give correct response in previous step?</param>

     

        private bool Step(bool prevResult)
        {
            bool newWord;
            newWord = gateTest.Step(ref Reports, prevResult);
            dgResults.DataSource = Reports;
            dgResults.Refresh();
            FeedbackGame.Step(gateTest.CurrentWordIndex * 10 + gateTest.CurrentGateIndex);//assuming 10 gates per word
            return newWord;
        }
        
        private void GatingControlPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (null != FeedbackGame)
            {
                FeedbackGame.Dispose();
   
                FeedbackGame = null;
            }
            if (null != FeedbackResponse)
            {
                FeedbackResponse.Dispose();
                FeedbackResponse = null;
            }

            for (int i = 0; i < 4; i++)
                myAgents[i].Dispose();

            //
          
        }
        
        private void btnCorrect_Click(object sender, EventArgs e)
        {
              
                lastCorrect = true; 
           
                MoveTestForward();
                
            
        }
        private void btnIncorrect_Click(object sender, EventArgs e)
        {          
             lastCorrect = false; 
             MoveTestForward();
        }

        private void MoveTestForward()
        {

            
            if (dgResults.SelectedRows.Count <= 0) return;
            //if new file hasn't been played, don't mark anything
            if (!string.IsNullOrEmpty(gateTest.CurrentFileToPlay)) return;
            int i = dgResults.SelectedRows[0].Index;
            bool IsCorrect;
            string thisScore;
            if (!lastCorrect.HasValue || !Score.HasValue)
            {
                return;
            }

             IsCorrect = Convert.ToBoolean(lastCorrect);
             thisScore = Convert.ToString(Score);   

            if (IsCorrect)
            {
                Reports.ElementAt<GateReporter>(i).Result = "Correct";
                Reports.ElementAt<GateReporter>(i).Score = thisScore;
                dgResults.Rows[i].DefaultCellStyle.BackColor = colors[1];
            }
            else
            {
                Reports.ElementAt<GateReporter>(i).Result = "Incorrect";
                Reports.ElementAt<GateReporter>(i).Score = thisScore;
                if (Reports.ElementAt<GateReporter>(i).Sequence == 1)
                    dgResults.Rows[i].DefaultCellStyle.BackColor = colors[2];

            }
           
            NewStep(IsCorrect, thisScore); 
            dgResults.Refresh();
            ManageInputAndButtonPlayState();
            btnPlay.Focus();
            GiveFeedback();
            CheckAndTakeBreak();
        }

      
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (gateTest.Play())
            {
                btnPlay.Enabled = false;
                ManageInputAndButtonPlayState();
            }
              
            
        }
        private void NewStep(bool thisResult, string thisScore)
        {
            // If the answer if incorrect do as is was done
            // If the answer if Correct do additional checking to move forward 
            //  additional checking are two previous score of five and two correct inclding this..
            int i = dgResults.SelectedRows[0].Index;
            bool newResults;

            if (thisResult && thisScore == "5" && Convert.ToBoolean(previouscorrect)== true && Convert.ToInt32(previousscore)==5 )
            {  
              newResults=  Step(true);
              
            }
            else
            {
             newResults =   Step(false);
            }
            if (newResults)
            {
                previouscorrect = null;
                previousscore = null;
            }
            else
            {
                previouscorrect = lastCorrect;
                previousscore = Score;
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            SaveToExcel(dgResults);
        }
        /// <summary>
        /// Save grid contents to excel
        /// </summary>
        /// <param name="dgrid">Grid whose content to save</param>
        private void SaveToExcel(DataGridView dgrid)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Comma Seperated Values (*.csv)|*.csv";
            dlg.RestoreDirectory = true;
            if (dlg.ShowDialog() != DialogResult.OK )
            {
                return;
            }
            StreamWriter sw = new StreamWriter(dlg.FileName, false);
            sw.WriteLine("Subjectid: " + subject.SubjectID);
            sw.WriteLine(string.Empty);
            sw.WriteLine("Groupid: " + subject.GroupID);
            sw.WriteLine(string.Empty);
            foreach (DataGridViewColumn c in dgrid.Columns)
            {
                sw.Write(c.HeaderText + ",");
            }
            sw.WriteLine(string.Empty);
            string strGroup = string.Empty;
            foreach (DataGridViewRow row in dgrid.Rows)
            {
                for (int x = 0; x < row.Cells.Count; x++)
                {
                   
                    if (row.Cells[x].Value != null)
                        sw.Write("\"" + row.Cells[x].Value.ToString() + "\",");
                    
                }
                sw.WriteLine(string.Empty);
            }
            sw.Flush();
            sw.Close();
            MessageBox.Show(dlg.FileName + " Saved");
        }
        /// <summary>
        /// Prints datagrid
        /// </summary>
        /// <param name="dgrid">Dataviewgrid to print</param>
        /// <param name="e"></param>
        private void PrintGrid(DataGridView dgrid,PrintPageEventArgs e)
        {
            System.Drawing.Printing.PrinterResolution res = e.PageSettings.PrinterResolution;
            e.Graphics.PageUnit = GraphicsUnit.Display;
            
            SolidBrush brush = new SolidBrush(Color.Black);
            SolidBrush graybrush1 = new SolidBrush(Color.LightGray);
            SolidBrush graybrush2 = new SolidBrush(Color.FromArgb(100, 100, 100));

            Pen pen = new Pen(brush, 1);
            Pen pen2 = new Pen(brush, 2);

            Graphics g = e.Graphics;
            Font fontLarge = new Font("Arial", 14, FontStyle.Bold);
            Font fontBold = new Font("Arial", 9, FontStyle.Bold);
            Font fontNorm = dgrid.DefaultCellStyle.Font;//new Font("Arial", 9);
            int nLine = 5;
            int nS = dgrid.Rows[0].Height;
            int X = 10;
            nLine += nS + nS;
            DataGridViewRow row;
            //print headers
            g.DrawString("Gating Experiment "+dgrid.Tag, fontLarge, brush, 5, nLine);
            nLine += nS+nS;
            g.DrawString(lblSubjectName.Text, fontBold, brush, 5, nLine);
            nLine += nS+nS;

            if (dgrid.ColumnHeadersVisible)
            { 
                g.FillRectangle(graybrush2, 5, nLine, dgrid.Width, dgrid.Rows[0].Height);
                X = 10;
                DataGridViewColumn dc;
                for(int i=0;i<dgrid.Columns.Count;i++)
                {
                    dc = dgrid.Columns[i];
                    g.DrawString(dc.HeaderText, fontBold, brush, X , nLine);
                    X += dc.Width;
                }
            }
            nLine += nS;
            for (int x = 0; x < dgrid.Rows.Count; x++)
            {
                row = dgrid.Rows[x];
                //for first stim of a word and correct entries
                if (row.DefaultCellStyle.BackColor == colors[1] || row.DefaultCellStyle.BackColor == colors[2])
                    g.FillRectangle(graybrush1, 5, nLine, dgrid.Width, row.Height);
               
                X = 10;            
                for (int y = 0; y < dgrid.Columns.Count; y++)
                {
                    try
                    {
                        g.DrawString(row.Cells[y].Value.ToString(), fontNorm, brush, X, nLine);
                    }
                    catch (Exception)
                    { }
                      X += row.Cells[y].Size.Width;
                     
                 }
                nLine += nS;
            }
        }
        private void dgResults_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dgResults.Rows.Count > 0)
            {
                dgResults.FirstDisplayedScrollingRowIndex = dgResults.Rows.Count - 1;
                dgResults.Rows[dgResults.Rows.Count - 1].Selected = true;
            }
        }

        private void dgSummary_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dgSummary.Rows.Count > 0)
            {
                dgSummary.FirstDisplayedScrollingRowIndex = dgSummary.Rows.Count - 1;
                dgSummary.Rows[dgSummary.Rows.Count - 1].Selected = true;
            }
        }

        private void btnExportExcelSummary_Click(object sender, EventArgs e)
        {
            SaveToExcel(dgSummary);
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            PrintDialog dlg = new PrintDialog();
            dlg.Document = this.m_print;
          //  bool b = dlg.PrinterSettings.CanDuplex;
           
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                m_print.DocumentName = "Report";
                m_print.Print();
            }
           
        }

        private void m_print_PrintPage(object sender, PrintPageEventArgs e)
        {
            switch (m_print.DocumentName)
            {
                case "Report": PrintGrid(dgResults, e);
                    break;
                case "Summary": PrintGrid(dgSummary, e);
                    break;
                default: break;
            }
        }

        private void btnPrintSummary_Click(object sender, EventArgs e)
        {
            PrintDialog dlg = new PrintDialog();
            dlg.Document = this.m_print;
            bool b = dlg.PrinterSettings.CanDuplex;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                m_print.DocumentName = "Summary";
                m_print.Print();
            }

        }

        private void dgSummary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GatingControlPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (new Settings().DisplayGames)
            {
                CurrentAgent.Show();
                CurrentAgent.MoveTo((short)(FeedbackGame.Location.X + e.X), (short)e.Y, true);
                CurrentAgent.Dance();
                CurrentAgent.MoveTo(CurrentAgent.HomeX, CurrentAgent.HomeY, false);
            }
        }


        //All feedback character buttons' click handler
        private void btnGenie_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            SetCharacter(b.Tag.ToString());
        }

        /// <summary>
        /// Selects character for current animation
        /// </summary>
        /// <param name="character">Index of character array</param>
        private void SetCharacter(string character)
        {
            CurrentAgent = myAgents[int.Parse(character)];          
        }

        private void btnKnock_Click(object sender, EventArgs e)
        {
            GiveFeedback();
        }

        /// <summary>
        /// Display character and perform animation
        /// </summary>
        private new void GiveFeedback()
        {
            if (new Settings().DisplayGames)
            {
                CurrentAgent = myAgents[r.Next(4)];
                if (!CurrentAgent.IsVisible())
                {
                    CurrentAgent.MoveTo(FeedbackGame.Location.X + 20, FeedbackGame.Location.Y + 20, true);
                    CurrentAgent.Show();
                    System.Threading.Thread.Sleep(500);
                }
                CurrentAgent.MoveTo(FeedbackGame.Location.X + 400, FeedbackGame.Location.Y + 400, true);
                CurrentAgent.Animate(Animations[r.Next(5)], false);
                CurrentAgent.MoveTo(CurrentAgent.HomeX, CurrentAgent.HomeY, false);
            }
        }

        private void ManageInputAndButtonPlayState()
        {
            if (lastCorrect.HasValue && Score.HasValue)
            {
                btnPlay.Enabled = true;
            }
            else
            {
                btnPlay.Enabled = false;
            }
            if (btnPlay.Enabled)
            {
                FeedbackResponse.DisableAllButtons();
                lastCorrect = null;
                Score = null;
                tbuserResonse.Enabled = false;
            }
            else
            {
                FeedbackResponse.EnableAllButtons();
                tbuserResonse.Enabled = true;

            }

            
            
            
        }

        
        private void EnableFeedBackButtonsOnResponse()
        {
            if (FeedbackResponse != null)
            {
                FeedbackResponse.EnableAllButtons();
            }
        }
        private void UpdateScore( string s)
        {
            Score = Convert.ToInt32(s);
            MoveTestForward();
      
            
        }

        public void CheckAndTakeBreak()
        {
            if (gateTest.CurrentWordIndex == (int)gateTest.NumOfWords / 2 && !BreakTakenBefore)
            {

                DialogResult userResponse =MessageBox.Show("Please press ok to ComeBack later and Complete the test or press Cancel to move forward with this Test" , "Break Time", MessageBoxButtons.OKCancel);
                BreakTakenBefore = true;
                if (userResponse == DialogResult.OK)
                {
                   
                    string destinationFolder = gateTest.strDirPath + "\\" + subject.SubjectID;

                    if (!Directory.Exists(destinationFolder))
                    {
                        Directory.CreateDirectory(destinationFolder);
                    }
                    foreach (string filename in gateTest.FilesToCopyAfterBreak)
                    {
                        File.Copy(filename, destinationFolder + filename.Substring(filename.LastIndexOf("\\")), true);
                    }



                    if (MessageBox.Show("Please Save your Test result", "Export to Excel", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        SaveToExcel(dgSummary);
                        SaveToExcel(dgResults);
                    }

                    this.Close();
                    Application.Exit();
                }
               
            }
            if (gateTest.CurrentWordIndex == gateTest.NumOfWords)
            {

                MessageBox.Show("Test Complete", "Complete", MessageBoxButtons.OK);
                if (MessageBox.Show("Please Save your Test result", "Export to Excel", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    SaveToExcel(dgSummary);
                    SaveToExcel(dgResults);
                }

                
            }

        }

                    
    }
    //contains data that is reported back to application
    public class GateReporter
    {
        public int Sequence { get; set; }
        public string RootWord { get; set; } 
        public string Predictability { get; set; }
        public string Filename { get; set; }   
        public Nullable<int> GatesPresented { get; set; }
        public string Score { get; set; }
        public string Result { get; set; }
      //  public static int CurrentIndex { get; set; }
    }
}
