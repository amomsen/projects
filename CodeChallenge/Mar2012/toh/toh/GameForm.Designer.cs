namespace toh
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.highScorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeAmountOfDisksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.showMeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hints = new System.Windows.Forms.RichTextBox();
            this.hintsLable = new System.Windows.Forms.Label();
            this.usernameTextbox = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.moveCounterLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.moveCounter = new System.Windows.Forms.ToolStripStatusLabel();
            this.possibleToSolve = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1250, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.highScorerToolStripMenuItem,
            this.changeAmountOfDisksToolStripMenuItem,
            this.showMeToolStripMenuItem,
            this.restartToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(95, 20);
            this.toolStripMenuItem1.Text = "Game Options";
            // 
            // highScorerToolStripMenuItem
            // 
            this.highScorerToolStripMenuItem.Name = "highScorerToolStripMenuItem";
            this.highScorerToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.highScorerToolStripMenuItem.Text = "View high scores";
            this.highScorerToolStripMenuItem.Click += new System.EventHandler(this.highScorerToolStripMenuItem_Click);
            // 
            // changeAmountOfDisksToolStripMenuItem
            // 
            this.changeAmountOfDisksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.changeAmountOfDisksToolStripMenuItem.Name = "changeAmountOfDisksToolStripMenuItem";
            this.changeAmountOfDisksToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.changeAmountOfDisksToolStripMenuItem.Text = "Change amount of disks";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem3.Text = "3";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem4.Text = "4";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem5.Text = "5";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem6.Text = "6";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // showMeToolStripMenuItem
            // 
            this.showMeToolStripMenuItem.Name = "showMeToolStripMenuItem";
            this.showMeToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.showMeToolStripMenuItem.Text = "Show Me";
            this.showMeToolStripMenuItem.Click += new System.EventHandler(this.showMeToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // hints
            // 
            this.hints.Location = new System.Drawing.Point(1070, 52);
            this.hints.Name = "hints";
            this.hints.Size = new System.Drawing.Size(168, 405);
            this.hints.TabIndex = 1;
            this.hints.Text = global::toh.Properties.Resources.base_image;
            // 
            // hintsLable
            // 
            this.hintsLable.AutoSize = true;
            this.hintsLable.Location = new System.Drawing.Point(1067, 36);
            this.hintsLable.Name = "hintsLable";
            this.hintsLable.Size = new System.Drawing.Size(58, 13);
            this.hintsLable.TabIndex = 4;
            this.hintsLable.Text = "Instructions:";
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.Location = new System.Drawing.Point(12, 437);
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.Size = new System.Drawing.Size(123, 20);
            this.usernameTextbox.TabIndex = 6;
            this.usernameTextbox.Text = "Enter your name here";
            this.usernameTextbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveCounterLabel,
            this.moveCounter,
            this.possibleToSolve});
            this.statusStrip1.Location = new System.Drawing.Point(0, 464);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1250, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // moveCounterLabel
            // 
            this.moveCounterLabel.Name = "moveCounterLabel";
            this.moveCounterLabel.Size = new System.Drawing.Size(45, 17);
            this.moveCounterLabel.Text = "Moves:";
            // 
            // moveCounter
            // 
            this.moveCounter.Name = "moveCounter";
            this.moveCounter.Size = new System.Drawing.Size(0, 17);
            // 
            // possibleToSolve
            // 
            this.possibleToSolve.Name = "possibleToSolve";
            this.possibleToSolve.Size = new System.Drawing.Size(0, 17);
            // 
            // GameForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 486);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.usernameTextbox);
            this.Controls.Add(this.hintsLable);
            this.Controls.Add(this.hints);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GameForm";
            this.Text = "Tower of Hanoi";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.Form2_DragOver);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem highScorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeAmountOfDisksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem showMeToolStripMenuItem;
        private System.Windows.Forms.RichTextBox hints;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.Label hintsLable;
        private System.Windows.Forms.TextBox usernameTextbox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel moveCounterLabel;
        private System.Windows.Forms.ToolStripStatusLabel moveCounter;
        private System.Windows.Forms.ToolStripStatusLabel possibleToSolve;

	}
}