namespace Test
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.cmbAction = new System.Windows.Forms.ComboBox();
            this.axAgent1 = new AxAgentObjects.AxAgent();
            this.cmbChar = new System.Windows.Forms.ComboBox();
            this.userAnimation = new System.Windows.Forms.ComboBox();
            this.btnUserAnimate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axAgent1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(205, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 21);
            this.button1.TabIndex = 1;
            this.button1.Text = "Animate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbAction
            // 
            this.cmbAction.FormattingEnabled = true;
            this.cmbAction.Items.AddRange(new object[] {
            "Acknowledge",
            "Alert",
            "Announce",
            "Blink",
            "Confused",
            "congratulate",
            "Decline",
            "Domagic1",
            "domagic2",
            "Dontrecognize",
            "Explain",
            "GestureDown",
            "GestureLeft",
            "GestureRight",
            "GestureUp",
            "GetAttention",
            "Greet",
            "Hide",
            "Idle1_1",
            "Idle1_2",
            "Idle1_3",
            "Idle1_4",
            "Idle2_1",
            "Idle2_2",
            "Idle3_1",
            "LookDown",
            "LookLeft",
            "LookRight",
            "Lookup",
            "MoveLeft",
            "MoveDown",
            "Moveright",
            "MoveUp",
            "Pleased",
            "Process",
            "Read",
            "readContinued",
            "Restpose",
            "Sad",
            "Search",
            "Show",
            "StartListening",
            "StopListening",
            "Suggest",
            "Surprised",
            "Think",
            "Uncertain",
            "Wave",
            "Write",
            "writeContinued",
            "WriteReturn"});
            this.cmbAction.Location = new System.Drawing.Point(21, 79);
            this.cmbAction.Name = "cmbAction";
            this.cmbAction.Size = new System.Drawing.Size(167, 21);
            this.cmbAction.TabIndex = 2;
            // 
            // axAgent1
            // 
            this.axAgent1.Enabled = true;
            this.axAgent1.Location = new System.Drawing.Point(10, 209);
            this.axAgent1.Name = "axAgent1";
            this.axAgent1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAgent1.OcxState")));
            this.axAgent1.Size = new System.Drawing.Size(32, 32);
            this.axAgent1.TabIndex = 3;
            // 
            // cmbChar
            // 
            this.cmbChar.FormattingEnabled = true;
            this.cmbChar.Items.AddRange(new object[] {
            "Merlin.acs",
            "Genie.acs",
            "Peedy.acs",
            "Robby.acs"});
            this.cmbChar.Location = new System.Drawing.Point(19, 50);
            this.cmbChar.Name = "cmbChar";
            this.cmbChar.Size = new System.Drawing.Size(168, 21);
            this.cmbChar.TabIndex = 4;
            this.cmbChar.Text = "Peedy.acs";
            this.cmbChar.SelectedIndexChanged += new System.EventHandler(this.cmbChar_SelectedIndexChanged);
            // 
            // userAnimation
            // 
            this.userAnimation.FormattingEnabled = true;
            this.userAnimation.Items.AddRange(new object[] {
            "Dance",
            "Jump",
            "Process",
            "Magic"});
            this.userAnimation.Location = new System.Drawing.Point(21, 113);
            this.userAnimation.Name = "userAnimation";
            this.userAnimation.Size = new System.Drawing.Size(165, 21);
            this.userAnimation.TabIndex = 5;
            // 
            // btnUserAnimate
            // 
            this.btnUserAnimate.Location = new System.Drawing.Point(204, 113);
            this.btnUserAnimate.Name = "btnUserAnimate";
            this.btnUserAnimate.Size = new System.Drawing.Size(54, 28);
            this.btnUserAnimate.TabIndex = 6;
            this.btnUserAnimate.Text = "Animate";
            this.btnUserAnimate.UseVisualStyleBackColor = true;
            this.btnUserAnimate.Click += new System.EventHandler(this.btnUserAnimate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 266);
            this.Controls.Add(this.btnUserAnimate);
            this.Controls.Add(this.userAnimation);
            this.Controls.Add(this.cmbChar);
            this.Controls.Add(this.axAgent1);
            this.Controls.Add(this.cmbAction);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.axAgent1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbAction;
        private AxAgentObjects.AxAgent axAgent1;
        private System.Windows.Forms.ComboBox cmbChar;
        private System.Windows.Forms.ComboBox userAnimation;
        private System.Windows.Forms.Button btnUserAnimate;
    }
}

