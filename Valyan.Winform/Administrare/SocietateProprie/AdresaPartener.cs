using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Syncfusion.Windows.Forms.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Valyan.API.Controllers;
using Valyan.API.Interfaces;
using Valyan.API.Repositories;
using Valyan.Shared.Data;



namespace Valyan.Winform.Administrare.SocietateProprie
{
    public partial class AdresaPartener : Form
    {
        private readonly frmSelfCompany _parentForm;

        public AdresaPartener(frmSelfCompany parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm;
            this.Load += AdresaPartener_Load;
            this.button1.Click += button1_Click;
        }

        private void AdresaPartener_Load(object? sender, EventArgs e)
        {
            LoadJudeteInCombo();
        }

        private void LoadJudeteInCombo()
        {
            try
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                string? connectionString = configuration.GetConnectionString("DefaultConnection");
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured or is null.");
                }

                var judete = JudetDataAccess.GetAllJudete(connectionString);

                cmbJudet.DataSource = judete;
                cmbJudet.DisplayMember = "Nume";
                cmbJudet.ValueMember = "IdJudet";

                // Corrected code to hide columns
                var gridModel = cmbJudet.ListBox.Grid.Model;
                gridModel.Cols.Hidden[gridModel.NameToColIndex("IdJudet")] = true;
                gridModel.Cols.Hidden[gridModel.NameToColIndex("JudetGuid")] = true;
                gridModel.Cols.Hidden[gridModel.NameToColIndex("Siruta")] = false;
                gridModel.Cols.Hidden[gridModel.NameToColIndex("CodAuto")] = false;
                gridModel.Cols.Hidden[gridModel.NameToColIndex("Ordine")] = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea județelor: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object? sender, EventArgs e)
        {
            try
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                string? connectionString = configuration.GetConnectionString("DefaultConnection");
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured or is null.");
                }
                // Inițializează repository și controller
                IPartnerRepository repo = new PartnerRepository(connectionString);
                var controller = new PartnerController(repo);

                // Creează modelul Partner cu date din frmSelfCompany
                var partner = new Partner
                {
                    PartnerCode = _parentForm.CodIntern,
                    PartnerName = _parentForm.Denumire,
                    E_Mail = _parentForm.Email,
                    Remark = _parentForm.Observatii,
                    IsUE = _parentForm.EsteUE,
                    IsNONUE = _parentForm.EsteNONUE,
                    FiscalCode = _parentForm.CodFiscal,
                    FiscalAtribute = _parentForm.AtributFiscal,
                    HoldingId = _parentForm.EsteHolding ? 1 : null, // Assuming 1 is the ID for holding
                    GroupId = _parentForm.EsteGrupDeFirme ? 1 : null, // Assuming 1 is the ID for group
                };

                // After creating the partner
                var (newPartnerId, newPartnerGuid) = controller.AddPartner(partner);

                // Creează modelul PartnerAddress cu date din controalele locale
                var selectedJudet = cmbJudet.SelectedItem as Judet;
                var address = new PartnerAddress
                {
                    PartnerId = newPartnerId,
                    PartnerGUID = newPartnerGuid, // Assign the correct GUID
                    CityId = int.TryParse(txtOras.Text, out var cityId) ? cityId : null,
                    IdJudet = selectedJudet?.IdJudet,
                    JudetGuid = selectedJudet?.JudetGuid,
                    // ... other fields
                };

                controller.AddPartnerAddress(address);

                MessageBox.Show("Partener și adresă adăugate cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la inserare: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
