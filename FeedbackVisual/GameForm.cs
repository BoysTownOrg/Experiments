using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FeedbackVisual
{
    public partial class GameForm : Form
    {
        private Game game;
        //private Image []lstAnimImages ;
        //int GameWidth;
        //int GameHeight;
        public GameForm()
        {
            InitializeComponent();
            Screen s = null;
            if (Screen.AllScreens.Length > 1)//multiscreen
            {
                s = Screen.AllScreens[1];
            }
            else //singlescreen
                s = Screen.AllScreens[0];
               
            
            this.Location = s.WorkingArea.Location;
            panelGame.Width = (int)(s.Bounds.Width * .9);// (this.Width * .9); //90% of window is pic
            panelGame.Height = (int)(s.Bounds.Height * 0.9);// (this.Height * .9);
            panelGame.Left = 10;//(this.Width * .05);
            panelGame.Top = 4;
            
            this.WindowState = FormWindowState.Maximized;
        }
        private List<string> GamePaths=new List<string>();
        public void SetupGame(string[] strGamePath,int WordCount)
        {
            GamePaths.AddRange(strGamePath);
            game = new Game();
            game.SetPanel(this.panelGame);
            game.SetSize(panelGame.Size);
            SetupGame(GamePaths[0]);
            GamePaths.RemoveAt(0);
            //setup notification
            progressbar.Maximum = WordCount;
            progressbar.Minimum = 0;
            progressbar.Step = 1;          
        }
        private void SetupGame(string strGamePath)
        {            
            game.LoadGame(strGamePath,false);//game file,randomize feedback           
            Draw();
            panelGame.Focus();
        }
        private void Draw()
        {
              if(null != game)
                game.Draw(PointToScreen(panelGame.Location));
        }
        public bool Step(int wordindex)
        {
            if (wordindex <= progressbar.Maximum && wordindex >= progressbar.Minimum) 
            progressbar.Value = wordindex;
            
            if (!game.StepGame(PointToScreen(panelGame.Location)))
            {
                if (GamePaths.Count > 0)
                {
                    SetupGame(GamePaths[0]);
                    GamePaths.RemoveAt(0);
                    return Step(wordindex);
                }
                else return false;
            }
            else return true;

        }
        
        public void Finish()
        {
            if (game.Type == GameType.DotToDot || game.Type == GameType.Reveal)
                while (game.StepGame(PointToScreen(panelGame.Location)) == true) ;

        }

        private void panelGame_Paint(object sender, PaintEventArgs e)
        {
            Draw();
        }

        
        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
