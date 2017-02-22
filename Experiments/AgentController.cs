using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Experiments
{
    public sealed class AgentController:IDisposable
    {
        private AgentObjects.IAgentCtlCharacterEx _char;
        private AxAgentObjects.AxAgent _agent;
        private static int Count;
        private short  Curx,Cury;
        private string CharName;
        public AgentController(AxAgentObjects.AxAgent agent,
            string characterLocation)
        {
            _agent = agent;
            Count++;
            CharName = "CHAR" + Count.ToString();
            _agent.Characters.Load(CharName, characterLocation);
            _char = _agent.Characters.Character(CharName);
            _char.SoundEffectsOn = false;
         }
        public void Show()
        {
            _char.Show(null);
        }
        public void Hide()
        {
            _char.Hide(null);
        }
        public bool IsVisible() { return _char.Visible; }
        public void Animate(string animation, bool stopAll)
        {
            if (stopAll)
                _char.StopAll(null);
            switch (animation)
            {
                case "Dance":
                    Dance();
                    break;
                case "Jump":
                    Jump();
                    break;
                case "Process":
                    Process();
                    break;
                case "Magic":
                    Magic();
                    break;
                default:
                    _char.Play(animation);
                    break;
            }
        }
        public void Speak(string text, bool stopAll)
        {
            if (stopAll)
                _char.StopAll(null);
            _char.Speak(text, null);
        }
        public void MoveTo(int x, int y, bool stopAll)
        {
            if (stopAll)
                _char.StopAll(null);
            try
            {
                _char.MoveTo((short)x, (short)y, null);
                Curx = (short)x;
                Cury = (short)y;
            }
            catch (Exception ex) { }
        }
        // Encapsulating many operations into one
        public void Dance()
        {
            _char.Play("GestureRight");
            _char.Play("GestureLeft");
            _char.Play("Congratulate");
           //_char.Play("Congratulate_2");
        }
        public void Jump()
        {
            MoveTo(Curx, Cury-50, false);
            MoveTo(Curx , Cury+50, false);
            _char.Play("Acknowledge");
        }
        public void Process()
        {
            _char.Play("Process");
        }
        public void Magic()
        {
            _char.Play("Domagic1");
            this.Hide();
            MoveTo(Curx -50, Cury, false);
            this.Show();
        }
        public void Surprise()
        {
            _char.StopAll(null);
            _char.Play("Alert");
            _char.Play("Sad");
        }
        public void Dispose()
        {
            _char.Hide(null);
            _char.StopAll(null);
            
            _agent.Characters.Unload(CharName);
            while (System.Runtime.InteropServices.
                Marshal.FinalReleaseComObject(_char) > 0) ;
        }
        public int HomeX { get; set; }
        public int HomeY { get; set; }
        
    }
}
