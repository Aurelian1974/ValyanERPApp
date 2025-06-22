namespace Valyan.Winform.Administrare.SocietateProprie
{
    partial class AdresaPartener
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
            Syncfusion.Windows.Forms.MetroColorTable metroColorTable1 = new Syncfusion.Windows.Forms.MetroColorTable();
            txtOras = new TextBox();
            cmbJudet = new Syncfusion.Windows.Forms.Tools.MultiColumnComboBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)cmbJudet).BeginInit();
            SuspendLayout();
            // 
            // txtOras
            // 
            txtOras.Location = new Point(33, 138);
            txtOras.Name = "txtOras";
            txtOras.Size = new Size(100, 23);
            txtOras.TabIndex = 0;
            // 
            // cmbJudet
            // 
            cmbJudet.AllowFiltering = false;
            cmbJudet.AlphaBlendSelectionColor = Color.FromArgb(64, 22, 165, 220);
            cmbJudet.BackColor = Color.White;
            cmbJudet.Filter = null;
            cmbJudet.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbJudet.Location = new Point(12, 52);
            cmbJudet.MaxDropDownItems = 10;
            cmbJudet.MetroColor = Color.FromArgb(22, 165, 220);
            cmbJudet.Name = "cmbJudet";
            cmbJudet.ScrollMetroColorTable = metroColorTable1;
            cmbJudet.SelectedIndex = -1;
            cmbJudet.Size = new Size(231, 27);
            cmbJudet.Sorted = true;
            cmbJudet.Style = Syncfusion.Windows.Forms.VisualStyle.Metro;
            cmbJudet.TabIndex = 4;
            cmbJudet.ThemeName = "Metro";
            // 
            // button1
            // 
            button1.Location = new Point(12, 395);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // AdresaPartener
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(cmbJudet);
            Controls.Add(txtOras);
            Name = "AdresaPartener";
            Text = "AdresaPartener";
            ((System.ComponentModel.ISupportInitialize)cmbJudet).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtOras;
        private Syncfusion.Windows.Forms.Tools.MultiColumnComboBox cmbJudet;
        private Button button1;
    }
}