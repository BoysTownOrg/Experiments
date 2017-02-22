using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using Experiments;

namespace Test
{
    public partial class Form1 : Form
    {
        AgentController []myAgent= new AgentController[4];
        
        Random r;
        public Form1()
        {
            InitializeComponent();
            r = new Random();
            myAgent[0] = new AgentController(axAgent1, "peedy.acs");
            myAgent[1] = new AgentController(axAgent1, "genie.acs");
            myAgent[2] = new AgentController(axAgent1, "merlin.acs");
            myAgent[3] = new AgentController(axAgent1, "robby.acs");
     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = cmbChar.SelectedIndex; ;// r.Next(4);
                myAgent[i].MoveTo(400, 400,true);
                myAgent[i].Show();
                myAgent[i].Animate(cmbAction.Text, false);
             //   myAgent[i].Hide();
        }

        private void cmbChar_SelectedIndexChanged(object sender, EventArgs e)
        {
         //   myAgent.Dispose();
          //  myAgent = new AgentController(axAgent1, cmbChar.Text);

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            for(int i=0;i<4;i++)
            myAgent[i].Dispose();
         }

        private void btnUserAnimate_Click(object sender, EventArgs e)
        {
            int i = cmbChar.SelectedIndex;
            myAgent[i].MoveTo(400, 400, true);
            myAgent[i].Show();
            switch (userAnimation.Text)
            {
                case "Dance":
                    myAgent[i].Dance();
                    break;
                case "Jump":
                    myAgent[i].Jump();
                    break;
                case "Process":
                    myAgent[i].Process();
                    break;
                case "Magic":
                    myAgent[i].Magic();
                    break;
                default:
                    break;
            }
            myAgent[i].Hide();
        }
        
    }
}
