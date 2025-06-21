namespace Valyan.Winform.Main
{
    partial class frmMain
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
            menuStrip1 = new MenuStrip();
            administrareToolStripMenuItem = new ToolStripMenuItem();
            dateCompanieToolStripMenuItem = new ToolStripMenuItem();
            administrareUATToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { administrareToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(957, 29);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // administrareToolStripMenuItem
            // 
            administrareToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dateCompanieToolStripMenuItem, administrareUATToolStripMenuItem });
            administrareToolStripMenuItem.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            administrareToolStripMenuItem.Name = "administrareToolStripMenuItem";
            administrareToolStripMenuItem.Size = new Size(99, 23);
            administrareToolStripMenuItem.Text = "Administrare";
            // 
            // dateCompanieToolStripMenuItem
            // 
            dateCompanieToolStripMenuItem.Name = "dateCompanieToolStripMenuItem";
            dateCompanieToolStripMenuItem.Size = new Size(185, 24);
            dateCompanieToolStripMenuItem.Text = "Date companie";
            dateCompanieToolStripMenuItem.Click += dateCompanieToolStripMenuItem_Click;
            // 
            // administrareUATToolStripMenuItem
            // 
            administrareUATToolStripMenuItem.Name = "administrareUATToolStripMenuItem";
            administrareUATToolStripMenuItem.Size = new Size(185, 24);
            administrareUATToolStripMenuItem.Text = "Administrare UAT";
            administrareUATToolStripMenuItem.Click += administrareUATToolStripMenuItem_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(957, 489);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmMain";
            Text = "Valyan Enterprise ERP";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem administrareToolStripMenuItem;
        private ToolStripMenuItem dateCompanieToolStripMenuItem;
        private ToolStripMenuItem administrareUATToolStripMenuItem;
    }
}