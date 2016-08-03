namespace PlayerConfigSelection
{
    partial class ConfigDialog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigDialog));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unselectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectCharactersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CharacterSelectButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.buttonClose = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.checkedListBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(69, 67);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.ScrollAlwaysVisible = true;
            this.checkedListBox1.Size = new System.Drawing.Size(652, 298);
            this.checkedListBox1.Sorted = true;
            this.checkedListBox1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.unselectAllToolStripMenuItem,
            this.selectCharactersToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(249, 94);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(248, 30);
            this.selectAllToolStripMenuItem.Text = "&Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // unselectAllToolStripMenuItem
            // 
            this.unselectAllToolStripMenuItem.Name = "unselectAllToolStripMenuItem";
            this.unselectAllToolStripMenuItem.Size = new System.Drawing.Size(248, 30);
            this.unselectAllToolStripMenuItem.Text = "&Unselect All";
            this.unselectAllToolStripMenuItem.Click += new System.EventHandler(this.unselectAllToolStripMenuItem_Click);
            // 
            // selectCharactersToolStripMenuItem
            // 
            this.selectCharactersToolStripMenuItem.Name = "selectCharactersToolStripMenuItem";
            this.selectCharactersToolStripMenuItem.Size = new System.Drawing.Size(248, 30);
            this.selectCharactersToolStripMenuItem.Text = "&Character Selection";
            this.selectCharactersToolStripMenuItem.Click += new System.EventHandler(this.selectCharactersToolStripMenuItem_Click);
            // 
            // CharacterSelectButton
            // 
            this.CharacterSelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CharacterSelectButton.Location = new System.Drawing.Point(69, 425);
            this.CharacterSelectButton.Margin = new System.Windows.Forms.Padding(4);
            this.CharacterSelectButton.Name = "CharacterSelectButton";
            this.CharacterSelectButton.Size = new System.Drawing.Size(225, 38);
            this.CharacterSelectButton.TabIndex = 1;
            this.CharacterSelectButton.Text = "&Character Selection";
            this.CharacterSelectButton.UseVisualStyleBackColor = true;
            this.CharacterSelectButton.Click += new System.EventHandler(this.CharacterSelectButton_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClose.Location = new System.Drawing.Point(316, 425);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(225, 38);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "C&lose";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // ConfigDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 491);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.CharacterSelectButton);
            this.Controls.Add(this.checkedListBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConfigDialog";
            this.Text = "Player Configutation ";
            this.Load += new System.EventHandler(this.ConfigDialog_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button CharacterSelectButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unselectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectCharactersToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button buttonClose;
    }
}

