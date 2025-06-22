using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.DataGrid.Styles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Valyan.API.Repositories;

namespace Valyan.Winform.Administrare.SocietateProprie
{
    public partial class frmSelfCompany : Form
    {
        private MultiColumnComboBox cmbJudet;
        private List<Judet> allJudete; // Store all judete for filtering

        public frmSelfCompany()
        {
            InitializeComponent();

            cmbJudet = new MultiColumnComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(10, 10), // Adjust location as needed
                Size = new Size(200, 30) // Adjust size as needed
            };
            Controls.Add(cmbJudet); // Add it to the form's controls

            rbtGrupDeFirme.CheckedChanged += rbtGrupDeFirme_CheckedChanged;
            rbtGrupDeFirme_CheckedChanged(this, EventArgs.Empty); // setează starea inițială
            btnAddAddress.Click += btnAddAddress_Click;
        }

        public string CodIntern => txtCodIntern.Text.Trim();
        public string Denumire => txtDenumire.Text.Trim();
        public string Email => txtEmail.Text.Trim();
        public string Observatii => txtObservatii.Text.Trim();
        public bool EsteUE => ckbEsteUE.Checked;
        public bool EsteNONUE => ckbEsteNONUE.Checked;
        public string CodFiscal => txtCodFiscal.Text.Trim();
        public string AtributFiscal => txtAtributFiscal.Text.Trim();
        public bool EsteGrupDeFirme => rbtGrupDeFirme.Checked;
        public bool EsteHolding => rbtEsteHolding.Checked; 

        private void rbtGrupDeFirme_CheckedChanged(object? sender, EventArgs e)
        {
            bool isGrupChecked = rbtGrupDeFirme.Checked;
            txtCodFiscal.Enabled = !isGrupChecked;
            txtAtributFiscal.Enabled = !isGrupChecked;
        }

        private void btnAddAddress_Click(object? sender, EventArgs e)
        {
            using (var frm = new AdresaPartener(this))
            {
                frm.ShowDialog(this);
            }
        }

        private async void frmSelfCompany_Load(object sender, EventArgs e)
        {
            try
            {
                var configurationBuilder = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                var configuration = configurationBuilder.Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");

                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    var repo = new PartnerRepository(connectionString);
                    if (repo.ExistsWithHoldingOrGroupId1())
                    {
                        rbtGrupDeFirme.Enabled = false;
                        rbtEsteHolding.Enabled = false;
                    }

                    var judetRepo = new JudetRepository(connection);
                    allJudete = (await judetRepo.GetAllAsync()).ToList();
                    cmbJudet.DataSource = allJudete;
                    cmbJudet.DisplayMember = "Nume";
                    cmbJudet.ValueMember = "IdJudet";
                    cmbJudet.AllowFiltering = true;
                    cmbJudet.ShowColumnHeader = true;
                    this.cmbJudet.TextChanged += MultiColumnComboboxTextBox_TextChanged;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la verificarea statusului Holding/Grup: " + ex.Message,
                    "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MultiColumnComboboxTextBox_TextChanged(object sender, EventArgs e)
        {
            // The filter criteria can be given in the FilterRecords method which can be assigned to Filter property.
            this.cmbJudet.Filter = FilterRecords;
        }

        public bool FilterRecords(object o)
        {
            var item = o as Judet;
            if (item != null)
            {
                if (item.Nume.Equals(this.cmbJudet.TextBox.Text))
                    return true;
            }

            return false;
        }
    }
}
