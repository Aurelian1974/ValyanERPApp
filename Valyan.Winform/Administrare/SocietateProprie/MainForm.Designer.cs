namespace Valyan.Winform.Administrare.SocietateProprie
{
    partial class MainForm
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
            sfDataGrid1 = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            ((System.ComponentModel.ISupportInitialize)sfDataGrid1).BeginInit();
            SuspendLayout();
            // 
            // sfDataGrid1
            // 
            sfDataGrid1.AccessibleName = "Table";
            sfDataGrid1.Dock = DockStyle.Fill;
            sfDataGrid1.Location = new Point(0, 0);
            sfDataGrid1.Name = "sfDataGrid1";
            sfDataGrid1.Size = new Size(800, 450);
            sfDataGrid1.Style.BorderColor = Color.FromArgb(100, 100, 100);
            sfDataGrid1.Style.CheckBoxStyle.CheckedBackColor = Color.FromArgb(0, 120, 215);
            sfDataGrid1.Style.CheckBoxStyle.CheckedBorderColor = Color.FromArgb(0, 120, 215);
            sfDataGrid1.Style.CheckBoxStyle.IndeterminateBorderColor = Color.FromArgb(0, 120, 215);
            sfDataGrid1.Style.HyperlinkStyle.DefaultLinkColor = Color.FromArgb(0, 120, 215);
            sfDataGrid1.TabIndex = 0;
            sfDataGrid1.Text = "sfDataGrid1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(sfDataGrid1);
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)sfDataGrid1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid1;
    }
}