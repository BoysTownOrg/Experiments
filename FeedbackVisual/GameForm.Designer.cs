namespace FeedbackVisual
{
    partial class GameForm 
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
            this.panelGame = new System.Windows.Forms.Panel();
            this.progressbar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // panelGame
            // 
            this.panelGame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelGame.Location = new System.Drawing.Point(3, 28);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(729, 430);
            this.panelGame.TabIndex = 0;
            this.panelGame.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGame_Paint);
            // 
            // progressbar
            // 
            this.progressbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressbar.ForeColor = System.Drawing.Color.Lime;
            this.progressbar.Location = new System.Drawing.Point(374, 540);
            this.progressbar.Maximum = 50;
            this.progressbar.Name = "progressbar";
            this.progressbar.Size = new System.Drawing.Size(358, 21);
            this.progressbar.Step = 1;
            this.progressbar.TabIndex = 2;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 562);
            this.Controls.Add(this.progressbar);
            this.Controls.Add(this.panelGame);
            this.Name = "GameForm";
            this.Text = "Game";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGame;
        private System.Windows.Forms.ProgressBar progressbar;
    }
}

