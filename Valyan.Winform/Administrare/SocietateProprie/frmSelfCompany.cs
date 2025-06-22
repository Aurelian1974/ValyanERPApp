using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.DataGrid.Styles;

namespace Valyan.Winform.Administrare.SocietateProprie
{
    public partial class frmSelfCompany : Form
    {
        
        public frmSelfCompany()
        {
            InitializeComponent();
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

        private void frmSelfCompany_Load(object sender, EventArgs e)
        {
            //LoadJudeteInGrid();
        }
    }
}
