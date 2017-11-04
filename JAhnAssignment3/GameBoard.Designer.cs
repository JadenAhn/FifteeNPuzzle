namespace JAhnAssignment3
{
    partial class GameBoard
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
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLoadFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.cbDifficulty = new System.Windows.Forms.ComboBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCol = new System.Windows.Forms.TextBox();
            this.txtRow = new System.Windows.Forms.TextBox();
            this.pnlTile = new System.Windows.Forms.Panel();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.lblClickNumber = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(384, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNewGame,
            this.menuLoadFile,
            this.menuSaveFile});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // menuNewGame
            // 
            this.menuNewGame.Name = "menuNewGame";
            this.menuNewGame.Size = new System.Drawing.Size(185, 22);
            this.menuNewGame.Text = "New Game     Ctrl+N";
            this.menuNewGame.Click += new System.EventHandler(this.MenuNewGame_Click);
            // 
            // menuLoadFile
            // 
            this.menuLoadFile.Name = "menuLoadFile";
            this.menuLoadFile.Size = new System.Drawing.Size(185, 22);
            this.menuLoadFile.Text = "Load Game     Ctrl+O";
            this.menuLoadFile.Click += new System.EventHandler(this.MenuLoadFile_Click);
            // 
            // menuSaveFile
            // 
            this.menuSaveFile.Name = "menuSaveFile";
            this.menuSaveFile.Size = new System.Drawing.Size(185, 22);
            this.menuSaveFile.Text = "Save Game     Ctrl+S";
            this.menuSaveFile.Click += new System.EventHandler(this.MenuSaveFile_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.cbDifficulty);
            this.pnlMenu.Controls.Add(this.btnGenerate);
            this.pnlMenu.Controls.Add(this.label3);
            this.pnlMenu.Controls.Add(this.label2);
            this.pnlMenu.Controls.Add(this.label1);
            this.pnlMenu.Controls.Add(this.txtCol);
            this.pnlMenu.Controls.Add(this.txtRow);
            this.pnlMenu.Location = new System.Drawing.Point(83, 126);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(211, 141);
            this.pnlMenu.TabIndex = 1;
            // 
            // cbDifficulty
            // 
            this.cbDifficulty.FormattingEnabled = true;
            this.cbDifficulty.Items.AddRange(new object[] {
            "Easy",
            "Normal",
            "Hard",
            "HELL"});
            this.cbDifficulty.Location = new System.Drawing.Point(88, 64);
            this.cbDifficulty.Name = "cbDifficulty";
            this.cbDifficulty.Size = new System.Drawing.Size(100, 20);
            this.cbDifficulty.TabIndex = 2;
            this.cbDifficulty.Text = "Easy";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(33, 95);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(137, 34);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "Difficulty";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Columns";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rows";
            // 
            // txtCol
            // 
            this.txtCol.Location = new System.Drawing.Point(88, 36);
            this.txtCol.Name = "txtCol";
            this.txtCol.Size = new System.Drawing.Size(100, 21);
            this.txtCol.TabIndex = 1;
            this.txtCol.Text = "4";
            // 
            // txtRow
            // 
            this.txtRow.Location = new System.Drawing.Point(88, 9);
            this.txtRow.Name = "txtRow";
            this.txtRow.Size = new System.Drawing.Size(100, 21);
            this.txtRow.TabIndex = 0;
            this.txtRow.Text = "4";
            // 
            // pnlTile
            // 
            this.pnlTile.Location = new System.Drawing.Point(0, 35);
            this.pnlTile.Name = "pnlTile";
            this.pnlTile.Size = new System.Drawing.Size(70, 60);
            this.pnlTile.TabIndex = 2;
            // 
            // dlgSave
            // 
            this.dlgSave.InitialDirectory = "C:\\";
            this.dlgSave.RestoreDirectory = true;
            // 
            // dlgOpen
            // 
            this.dlgOpen.FileName = "openFileDialog1";
            // 
            // lblClickNumber
            // 
            this.lblClickNumber.AutoSize = true;
            this.lblClickNumber.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblClickNumber.ForeColor = System.Drawing.Color.Maroon;
            this.lblClickNumber.Location = new System.Drawing.Point(8, 30);
            this.lblClickNumber.Name = "lblClickNumber";
            this.lblClickNumber.Size = new System.Drawing.Size(0, 12);
            this.lblClickNumber.TabIndex = 3;
            // 
            // GameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.lblClickNumber);
            this.Controls.Add(this.pnlTile);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GameBoard";
            this.Text = "15 Puzzle";
            this.Load += new System.EventHandler(this.GameBoard_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuNewGame;
        private System.Windows.Forms.ToolStripMenuItem menuSaveFile;
        private System.Windows.Forms.ToolStripMenuItem menuLoadFile;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCol;
        private System.Windows.Forms.TextBox txtRow;
        private System.Windows.Forms.Panel pnlTile;
        private System.Windows.Forms.ComboBox cbDifficulty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.Label lblClickNumber;
    }
}

