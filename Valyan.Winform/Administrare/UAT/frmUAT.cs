using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Valyan.Winform.Data;
using Valyan.API.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using Valyan.Shared.Models;
//using Valyan.Shared.Data;
//using Valyan.Shared.Controllers;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.Windows.Forms.Grid;




namespace Valyan.Winform.Administrare
{
    public partial class frmUAT : Form
    {
        private readonly JudetController _controller;
        private List<Judet> _judete = new();
        private bool _hasUnsavedChanges = false; // Flag pentru modificări nesalvate
        private DataSet dsOrase; // Add this field
        public frmUAT()
        {
            InitializeComponent();
            btnAdaugare.Enabled = false;
            btnModificare.Enabled = false;
            btnStergere.Enabled = false;

            // Enable filtering
            sfDataGrid1.AllowFiltering = true;
            sfDataGrid1.FilterRowPosition = Syncfusion.WinForms.DataGrid.Enums.RowPosition.Top;

            // Enable grouping
            sfDataGrid1.AllowGrouping = true;
            sfDataGrid1.ShowGroupDropArea = true;

            // Create an instance of IConfiguration to pass to DbConnectionFactory
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var configuration = configurationBuilder.Build();

            var dbConnectionFactory = new DbConnectionFactory(configuration); 
            var connection = dbConnectionFactory.CreateConnection();
            // Initialize the dataset
            InitializeOraseDataSet(connection);
            var repo = new JudetRepository(connection);
            _controller = new JudetController(repo);

            tabControlUAT.SelectedIndexChanged += TabControlUAT_SelectedIndexChanged;
            sfDataGrid1.SelectionChanged += SfDataGrid1_SelectionChanged;
            sfDataGrid1.DataSourceChanged += (s, e) =>
            {
                if (sfDataGrid1.Columns != null && sfDataGrid1.Columns.Any(col => col.MappingName == "IdJudet"))
                {
                    var column = sfDataGrid1.Columns.FirstOrDefault(col => col.MappingName == "IdJudet");
                    if (column != null)
                    {
                        column.Visible = false;
                    }
                }
            };
            btnAdaugare.Click += BtnAdaugare_Click;
            btnModificare.Click += BtnModificare_Click;
            btnStergere.Click += BtnStergere_Click;
            txtCodJudet.TextChanged += txtCodJudet_TextChanged;
            txtDenumireJudet.TextChanged += txtDenumireJudet_TextChanged;
            txtCodSiruta.TextChanged += txtCodSiruta_TextChanged;
        }

        private void InitializeOraseDataSet(IDbConnection connection)
        {
            try
            {
                dsOrase = new DataSet("Orase");
                using (var adapter = new SqlDataAdapter("SELECT * FROM Oras", (SqlConnection)connection))
                {
                    adapter.Fill(dsOrase, "Oras");
                }

                // Bind standard ComboBox
                comboBox1.DataSource = dsOrase.Tables["Oras"];
                comboBox1.DisplayMember = "Nume";
                comboBox1.ValueMember = "Nume";

                // Bind Syncfusion ComboBoxAdv
                comboBoxAdv1.DataSource = dsOrase.Tables["Oras"];
                comboBoxAdv1.DisplayMember = "Nume";
                comboBoxAdv1.ValueMember = "Nume";

                // Bind Syncfusion AutoComplete ComboBox
                comboBoxAutoComplete1.DataSource = dsOrase.Tables["Oras"];
                comboBoxAutoComplete1.DisplayMember = "Nume";
                comboBoxAutoComplete1.ValueMember = "Nume";

                // Bind Syncfusion MultiColumn ComboBox
                multiColumnComboBox1.DataSource = dsOrase.Tables["Oras"];
                multiColumnComboBox1.DisplayMember = "Nume";
                multiColumnComboBox1.ValueMember = "Nume";

               
                

                // Bind Syncfusion SfComboBox
                sfComboBox1.DataSource = dsOrase.Tables["Oras"];
                sfComboBox1.DisplayMember = "Nume";
                sfComboBox1.ValueMember = "Nume";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea datelor: {ex.Message}", "Eroare",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void frmUAT_Load(object sender, EventArgs e)
        {
            if (tabControlUAT.SelectedTab == tabPageJudet)
            {
                txtCodJudet.Text = "";
                txtDenumireJudet.Text = "";
                _judete = await _controller.GetAllAsync();
                sfDataGrid1.DataSource = _judete;
                await UpdateButtonStates();
            }
        }
        private bool _isHandlingTabChange = false; 
        private async void TabControlUAT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isHandlingTabChange) return; // Prevent recursive calls

            _isHandlingTabChange = true;
            try
            {
                if (_hasUnsavedChanges)
                {
                    var result = MessageBox.Show(
                        "Există modificări nesalvate. Doriți să continuați fără salvare?",
                        "Confirmare",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.No)
                    {
                        tabControlUAT.SelectedTab = tabPageJudet; 
                        return;
                    }
                    _hasUnsavedChanges = false;
                }

                if (tabControlUAT.SelectedTab == tabPageJudet)
                {
                    txtCodJudet.Text = "";
                    txtDenumireJudet.Text = "";
                    txtCodSiruta.Text = "";
                    _judete = await _controller.GetAllAsync();
                    sfDataGrid1.DataSource = _judete;
                }
            }
            finally
            {
                _isHandlingTabChange = false;
            }
        }

        private void SfDataGrid1_SelectionChanged(object sender, EventArgs e)
        {
            if (sfDataGrid1.SelectedItem is Judet j)
            {
                txtCodJudet.Text = j.CodJudet;
                txtDenumireJudet.Text = j.Nume;
                txtCodSiruta.Text = j.Siruta?.ToString() ?? string.Empty;
            }
        }

        private async void BtnAdaugare_Click(object sender, EventArgs e)
        {
            var cod = txtCodJudet.Text.Trim();
            var nume = txtDenumireJudet.Text.Trim();
            var sirutaText = txtCodSiruta.Text.Trim();

            // Validare Siruta
            if (!ValidateSiruta(sirutaText, out int siruta))
                return;

            try
            {
                if (await _controller.ExistsAsync(cod, nume, siruta))
                {
                    // Verifică care câmp este duplicat
                    if (await _controller.ExistsAsync(cod, "", 0))
                        MessageBox.Show("Există deja un județ cu acest cod!", "Duplicat",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (await _controller.ExistsAsync("", nume, 0))
                        MessageBox.Show("Există deja un județ cu această denumire!", "Duplicat",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (siruta != 0 && await _controller.ExistsAsync("", "", siruta))
                        MessageBox.Show("Există deja un județ cu acest cod SIRUTA!", "Duplicat",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                await _controller.AddAsync(new Judet { CodJudet = cod, Nume = nume, Siruta = siruta });
                _hasUnsavedChanges = false;
                txtCodJudet.Text = txtDenumireJudet.Text = txtCodSiruta.Text = "";
                _judete = await _controller.GetAllAsync();
                sfDataGrid1.DataSource = _judete;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la salvare: {ex.Message}", "Eroare",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnModificare_Click(object sender, EventArgs e)
        {
            if (!(sfDataGrid1.SelectedItem is Judet selectedJudet))
                return;

            var cod = txtCodJudet.Text.Trim();
            var nume = txtDenumireJudet.Text.Trim();
            var sirutaText = txtCodSiruta.Text.Trim();

            // Validare Siruta
            if (!ValidateSiruta(sirutaText, out int siruta))
                return;

            try
            {
                // Verifică duplicate excluzând înregistrarea curentă
                var isDuplicate = await _controller.ExistsAsync(cod, nume, siruta);
                if (isDuplicate &&
                    (selectedJudet.CodJudet != cod ||
                     selectedJudet.Nume != nume ||
                     selectedJudet.Siruta != siruta))
                {
                    // Verifică care câmp este duplicat
                    if (await _controller.ExistsAsync(cod, "", 0) && selectedJudet.CodJudet != cod)
                        MessageBox.Show("Există deja un județ cu acest cod!", "Duplicat",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (await _controller.ExistsAsync("", nume, 0) && selectedJudet.Nume != nume)
                        MessageBox.Show("Există deja un județ cu această denumire!", "Duplicat",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (siruta != 0 && await _controller.ExistsAsync("", "", siruta) && selectedJudet.Siruta != siruta)
                        MessageBox.Show("Există deja un județ cu acest cod SIRUTA!", "Duplicat",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                selectedJudet.CodJudet = cod;
                selectedJudet.Nume = nume;
                selectedJudet.Siruta = siruta;

                await _controller.UpdateAsync(selectedJudet);
                _hasUnsavedChanges = false;
                txtCodJudet.Text = txtDenumireJudet.Text = txtCodSiruta.Text = "";
                _judete = await _controller.GetAllAsync();
                sfDataGrid1.DataSource = _judete;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la actualizare: {ex.Message}", "Eroare",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnStergere_Click(object sender, EventArgs e)
        {
            if (sfDataGrid1.SelectedItem is Judet j)
            {
                await _controller.DeleteAsync(j.IdJudet);
                txtCodJudet.Text = txtDenumireJudet.Text = "";
                _judete = await _controller.GetAllAsync();
                sfDataGrid1.DataSource = _judete;
            }
        }

        private void txtCodJudet_TextChanged(object sender, EventArgs e)
        {
            _hasUnsavedChanges = true;
            UpdateButtonStates();
        }

        private void txtDenumireJudet_TextChanged(object sender, EventArgs e)
        {
            _hasUnsavedChanges = true;
            UpdateButtonStates();
        }

        private void txtCodSiruta_TextChanged(object sender, EventArgs e)
        {
            _hasUnsavedChanges = true;
            if (!string.IsNullOrEmpty(txtCodSiruta.Text) &&
    !       int.TryParse(txtCodSiruta.Text, out _))
            {
                txtCodSiruta.BackColor = Color.LightPink;
                toolTip1.Show("Câmpul trebuie să fie numeric!", txtCodSiruta);
            }
            else
            {
                txtCodSiruta.BackColor = SystemColors.Window;
                toolTip1.Hide(txtCodSiruta);
            }

            UpdateButtonStates();
        }
        private bool ValidateSiruta(string sirutaText, out int siruta)
        {
            siruta = 0; // Inițializează siruta cu 0
            if (!string.IsNullOrEmpty(sirutaText) && !int.TryParse(sirutaText, out siruta))
            {
                MessageBox.Show("Câmpul Cod SIRUTA trebuie să fie numeric!",
                    "Validare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            siruta = string.IsNullOrEmpty(sirutaText) ? 0 : siruta;
            return true;
        }

        private async Task UpdateButtonStates()
        {
            var cod = txtCodJudet.Text.Trim();
            var nume = txtDenumireJudet.Text.Trim();
            var sirutaText = txtCodSiruta.Text.Trim();
            int siruta = 0;

            // Verifică dacă Siruta este valid
            if (!string.IsNullOrEmpty(sirutaText) && !int.TryParse(sirutaText, out siruta))
            {
                // Dacă Siruta nu este valid, dezactivează toate butoanele
                btnAdaugare.Enabled = false;
                btnModificare.Enabled = false;
                btnStergere.Enabled = false;
                return;
            }

            // Verifică dacă toate câmpurile sunt goale sau toate sunt completate
            bool toateGoale = string.IsNullOrEmpty(cod) &&
                              string.IsNullOrEmpty(nume) &&
                              string.IsNullOrEmpty(sirutaText);

            bool toateCompletate = !string.IsNullOrEmpty(cod) &&
                                  !string.IsNullOrEmpty(nume) &&
                                  !string.IsNullOrEmpty(sirutaText);

            // Verifică existența în baza de date doar dacă toate câmpurile sunt completate
            bool exista = toateCompletate && await _controller.ExistsAsync(cod, nume, siruta);

            // Logica pentru butoane:
            // 1. Adaugare: activ doar când toate sunt goale SAU toate sunt completate dar nu există în BD
            btnAdaugare.Enabled = toateGoale || (toateCompletate && !exista);

            // 2. Modificare și Ștergere: active doar când toate sunt completate și există în BD
            btnModificare.Enabled = toateCompletate && exista;
            btnStergere.Enabled = toateCompletate && exista;
            //btnStergere.Enabled = sfDataGrid1.SelectedItem is Judet;
        }


        // Verifică la închiderea formei
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_hasUnsavedChanges)
            {
                var result = MessageBox.Show(
                    "Există modificări nesalvate. Doriți să închideți fără salvare?",
                    "Confirmare",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Anulează închiderea
                    return;
                }
            }

            base.OnFormClosing(e);
        }

        // Metodă helper pentru a reseta flag-ul și câmpurile
        private void ResetForm()
        {
            txtCodJudet.Text = "";
            txtDenumireJudet.Text = "";
            txtCodSiruta.Text = "";
            _hasUnsavedChanges = false;
        }
    }
}
