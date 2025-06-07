namespace Valyan.Winform.Administrare
{
    partial class frmUAT
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
            components = new System.ComponentModel.Container();
            Syncfusion.Windows.Forms.MetroColorTable metroColorTable1 = new Syncfusion.Windows.Forms.MetroColorTable();
            tabControlUAT = new TabControl();
            tabPageJudet = new TabPage();
            panel3 = new Panel();
            txtCodSiruta = new TextBox();
            lblCodSiruta = new Label();
            txtDenumireJudet = new TextBox();
            txtCodJudet = new TextBox();
            lblDenumireJudet = new Label();
            lblCodJudet = new Label();
            panel2 = new Panel();
            btnStergere = new Button();
            btnModificare = new Button();
            btnAdaugare = new Button();
            panel1 = new Panel();
            sfDataGrid1 = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            tabPageOras = new TabPage();
            panel4 = new Panel();
            comboBoxAdv1 = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            toolTip1 = new ToolTip(components);
            comboBoxAutoComplete1 = new Syncfusion.Windows.Forms.Tools.ComboBoxAutoComplete();
            multiColumnComboBox1 = new Syncfusion.Windows.Forms.Tools.MultiColumnComboBox();
            sfComboBox1 = new Syncfusion.WinForms.ListView.SfComboBox();
            comboBox1 = new ComboBox();
            tabControlUAT.SuspendLayout();
            tabPageJudet.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sfDataGrid1).BeginInit();
            tabPageOras.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)comboBoxAdv1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxAutoComplete1.AutoCompleteControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)multiColumnComboBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sfComboBox1).BeginInit();
            SuspendLayout();
            // 
            // tabControlUAT
            // 
            tabControlUAT.Controls.Add(tabPageJudet);
            tabControlUAT.Controls.Add(tabPageOras);
            tabControlUAT.Location = new Point(14, 15);
            tabControlUAT.Margin = new Padding(3, 4, 3, 4);
            tabControlUAT.Name = "tabControlUAT";
            tabControlUAT.SelectedIndex = 0;
            tabControlUAT.Size = new Size(887, 527);
            tabControlUAT.TabIndex = 0;
            // 
            // tabPageJudet
            // 
            tabPageJudet.Controls.Add(panel3);
            tabPageJudet.Controls.Add(panel2);
            tabPageJudet.Controls.Add(panel1);
            tabPageJudet.Location = new Point(4, 28);
            tabPageJudet.Margin = new Padding(3, 4, 3, 4);
            tabPageJudet.Name = "tabPageJudet";
            tabPageJudet.Padding = new Padding(3, 4, 3, 4);
            tabPageJudet.Size = new Size(879, 495);
            tabPageJudet.TabIndex = 0;
            tabPageJudet.Text = "Judete";
            tabPageJudet.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.Controls.Add(txtCodSiruta);
            panel3.Controls.Add(lblCodSiruta);
            panel3.Controls.Add(txtDenumireJudet);
            panel3.Controls.Add(txtCodJudet);
            panel3.Controls.Add(lblDenumireJudet);
            panel3.Controls.Add(lblCodJudet);
            panel3.Location = new Point(7, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(381, 109);
            panel3.TabIndex = 6;
            // 
            // txtCodSiruta
            // 
            txtCodSiruta.Location = new Point(160, 79);
            txtCodSiruta.Name = "txtCodSiruta";
            txtCodSiruta.Size = new Size(172, 27);
            txtCodSiruta.TabIndex = 5;
            // 
            // lblCodSiruta
            // 
            lblCodSiruta.AutoSize = true;
            lblCodSiruta.Location = new Point(19, 82);
            lblCodSiruta.Name = "lblCodSiruta";
            lblCodSiruta.Size = new Size(88, 20);
            lblCodSiruta.TabIndex = 4;
            lblCodSiruta.Text = "Cod SIRUTA";
            // 
            // txtDenumireJudet
            // 
            txtDenumireJudet.Location = new Point(160, 46);
            txtDenumireJudet.Name = "txtDenumireJudet";
            txtDenumireJudet.Size = new Size(172, 27);
            txtDenumireJudet.TabIndex = 3;
            // 
            // txtCodJudet
            // 
            txtCodJudet.Location = new Point(160, 13);
            txtCodJudet.Name = "txtCodJudet";
            txtCodJudet.Size = new Size(172, 27);
            txtCodJudet.TabIndex = 2;
            // 
            // lblDenumireJudet
            // 
            lblDenumireJudet.AutoSize = true;
            lblDenumireJudet.Location = new Point(19, 49);
            lblDenumireJudet.Name = "lblDenumireJudet";
            lblDenumireJudet.Size = new Size(112, 20);
            lblDenumireJudet.TabIndex = 1;
            lblDenumireJudet.Text = "Denumire judet";
            // 
            // lblCodJudet
            // 
            lblCodJudet.AutoSize = true;
            lblCodJudet.Location = new Point(19, 16);
            lblCodJudet.Name = "lblCodJudet";
            lblCodJudet.Size = new Size(74, 20);
            lblCodJudet.TabIndex = 0;
            lblCodJudet.Text = "Cod judet";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnStergere);
            panel2.Controls.Add(btnModificare);
            panel2.Controls.Add(btnAdaugare);
            panel2.Location = new Point(750, 8);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(121, 110);
            panel2.TabIndex = 5;
            // 
            // btnStergere
            // 
            btnStergere.Location = new Point(3, 77);
            btnStergere.Margin = new Padding(3, 4, 3, 4);
            btnStergere.Name = "btnStergere";
            btnStergere.Size = new Size(115, 29);
            btnStergere.TabIndex = 6;
            btnStergere.Text = "Stergere";
            btnStergere.UseVisualStyleBackColor = true;
            // 
            // btnModificare
            // 
            btnModificare.Location = new Point(3, 41);
            btnModificare.Margin = new Padding(3, 4, 3, 4);
            btnModificare.Name = "btnModificare";
            btnModificare.Size = new Size(115, 29);
            btnModificare.TabIndex = 6;
            btnModificare.Text = "Modificare";
            btnModificare.UseVisualStyleBackColor = true;
            // 
            // btnAdaugare
            // 
            btnAdaugare.Location = new Point(3, 4);
            btnAdaugare.Margin = new Padding(3, 4, 3, 4);
            btnAdaugare.Name = "btnAdaugare";
            btnAdaugare.Size = new Size(115, 29);
            btnAdaugare.TabIndex = 5;
            btnAdaugare.Text = "Adaugare";
            btnAdaugare.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(sfDataGrid1);
            panel1.Location = new Point(7, 124);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(864, 360);
            panel1.TabIndex = 4;
            // 
            // sfDataGrid1
            // 
            sfDataGrid1.AccessibleName = "Table";
            sfDataGrid1.Dock = DockStyle.Fill;
            sfDataGrid1.Location = new Point(0, 0);
            sfDataGrid1.Margin = new Padding(3, 4, 3, 4);
            sfDataGrid1.Name = "sfDataGrid1";
            sfDataGrid1.Size = new Size(864, 360);
            sfDataGrid1.Style.BorderColor = Color.FromArgb(100, 100, 100);
            sfDataGrid1.Style.CheckBoxStyle.CheckedBackColor = Color.FromArgb(0, 120, 215);
            sfDataGrid1.Style.CheckBoxStyle.CheckedBorderColor = Color.FromArgb(0, 120, 215);
            sfDataGrid1.Style.CheckBoxStyle.IndeterminateBorderColor = Color.FromArgb(0, 120, 215);
            sfDataGrid1.Style.HyperlinkStyle.DefaultLinkColor = Color.FromArgb(0, 120, 215);
            sfDataGrid1.TabIndex = 0;
            sfDataGrid1.Text = "sfDataGrid1";
            // 
            // tabPageOras
            // 
            tabPageOras.Controls.Add(comboBox1);
            tabPageOras.Controls.Add(sfComboBox1);
            tabPageOras.Controls.Add(multiColumnComboBox1);
            tabPageOras.Controls.Add(comboBoxAutoComplete1);
            tabPageOras.Controls.Add(panel4);
            tabPageOras.Controls.Add(comboBoxAdv1);
            tabPageOras.Location = new Point(4, 28);
            tabPageOras.Margin = new Padding(3, 4, 3, 4);
            tabPageOras.Name = "tabPageOras";
            tabPageOras.Padding = new Padding(3, 4, 3, 4);
            tabPageOras.Size = new Size(879, 495);
            tabPageOras.TabIndex = 1;
            tabPageOras.Text = "Orase";
            tabPageOras.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.Controls.Add(label3);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(label1);
            panel4.Location = new Point(6, 7);
            panel4.Name = "panel4";
            panel4.Size = new Size(354, 130);
            panel4.TabIndex = 0;
            // 
            // comboBoxAdv1
            // 
            comboBoxAdv1.Height = 27;
            comboBoxAdv1.Location = new Point(23, 163);
            comboBoxAdv1.Name = "comboBoxAdv1";
            comboBoxAdv1.Size = new Size(121, 27);
            comboBoxAdv1.TabIndex = 3;
            comboBoxAdv1.Text = "comboBoxAdv1";
            comboBoxAdv1.TextBoxHeight = 27;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 79);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 2;
            label3.Text = "label3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 47);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 1;
            label2.Text = "label2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 16);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // comboBoxAutoComplete1
            // 
            // 
            // 
            // 
            comboBoxAutoComplete1.AutoCompleteControl.ChangeDataManagerPosition = true;
            comboBoxAutoComplete1.AutoCompleteControl.HeaderFont = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.World);
            comboBoxAutoComplete1.AutoCompleteControl.ItemFont = new Font("Segoe UI", 8.25F);
            comboBoxAutoComplete1.AutoCompleteControl.MetroColor = Color.FromArgb(17, 158, 218);
            comboBoxAutoComplete1.AutoCompleteControl.OverrideCombo = true;
            comboBoxAutoComplete1.AutoCompleteControl.ParentForm = tabPageOras;
            comboBoxAutoComplete1.AutoCompleteControl.Style = Syncfusion.Windows.Forms.Tools.AutoCompleteStyle.Default;
            comboBoxAutoComplete1.DropDownWidth = 121;
            comboBoxAutoComplete1.Location = new Point(172, 163);
            comboBoxAutoComplete1.Name = "comboBoxAutoComplete1";
            comboBoxAutoComplete1.ParentForm = tabPageOras;
            comboBoxAutoComplete1.Size = new Size(121, 27);
            comboBoxAutoComplete1.TabIndex = 4;
            // 
            // multiColumnComboBox1
            // 
            multiColumnComboBox1.AllowFiltering = false;
            multiColumnComboBox1.Filter = null;
            multiColumnComboBox1.Location = new Point(23, 220);
            multiColumnComboBox1.MetroColor = Color.FromArgb(22, 165, 220);
            multiColumnComboBox1.Name = "multiColumnComboBox1";
            multiColumnComboBox1.ScrollMetroColorTable = metroColorTable1;
            multiColumnComboBox1.SelectedIndex = -1;
            multiColumnComboBox1.Size = new Size(121, 27);
            multiColumnComboBox1.TabIndex = 5;
            multiColumnComboBox1.Text = "multiColumnComboBox1";
            // 
            // sfComboBox1
            // 
            sfComboBox1.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            sfComboBox1.Location = new Point(172, 221);
            sfComboBox1.Name = "sfComboBox1";
            sfComboBox1.Size = new Size(121, 26);
            sfComboBox1.Style.TokenStyle.CloseButtonBackColor = Color.FromArgb(255, 255, 255);
            sfComboBox1.TabIndex = 6;
            sfComboBox1.TabStop = false;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(23, 285);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 27);
            comboBox1.TabIndex = 7;
            // 
            // frmUAT
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 570);
            Controls.Add(tabControlUAT);
            Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmUAT";
            Text = "Administrare UAT";
            Load += frmUAT_Load;
            tabControlUAT.ResumeLayout(false);
            tabPageJudet.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)sfDataGrid1).EndInit();
            tabPageOras.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)comboBoxAdv1).EndInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxAutoComplete1.AutoCompleteControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)multiColumnComboBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)sfComboBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControlUAT;
        private TabPage tabPageJudet;
        private TabPage tabPageOras;
        private Panel panel1;
        private Panel panel2;
        private Button btnStergere;
        private Button btnModificare;
        private Button btnAdaugare;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid1;
        private Panel panel3;
        private TextBox txtDenumireJudet;
        private TextBox txtCodJudet;
        private Label lblDenumireJudet;
        private Label lblCodJudet;
        private TextBox txtCodSiruta;
        private Label lblCodSiruta;
        private ToolTip toolTip1;
        private Panel panel4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAdv comboBoxAdv1;
        private ComboBox comboBox1;
        private Syncfusion.WinForms.ListView.SfComboBox sfComboBox1;
        private Syncfusion.Windows.Forms.Tools.MultiColumnComboBox multiColumnComboBox1;
        private Syncfusion.Windows.Forms.Tools.ComboBoxAutoComplete comboBoxAutoComplete1;
    }
}