using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FeedbackVisual
{
    public partial class Response : Form
    {
        public delegate void ButtonClicked(int number);
        public event ButtonClicked UserResponded;
        public int currentScore;
        public Response()
        {
            InitializeComponent();
            Screen s = null ;
            if (Screen.AllScreens.Length > 1)//multiscreen
            {
                s = Screen.AllScreens[1];
            }
            else //singlescreen
                s = Screen.AllScreens[0];




            this.Location = s.Bounds.Location;
            this.StartPosition = FormStartPosition.Manual;
            this.WindowState = FormWindowState.Normal;
        }

        private void button_Click(object sender, EventArgs e)
        {
           Button b = (Button) sender;
           currentScore = Convert.ToInt32(b.Tag);
           if (UserResponded != null )
           {
               
            
               UserResponded(currentScore);
           }
           
            
        }
        public void DisableAllButtons()
        {
            button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = false;
        }

        public void EnableAllButtons( )
        {
            button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (UserResponded != null && currentScore > 1 && currentScore <=5)
            {
   
                UserResponded(currentScore);
            }
        }
    }
}
