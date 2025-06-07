using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Valyan.Winform.Administrare; // Asigură-te că ai referința corectă la namespace-ul UAT

namespace Valyan.Winform.Main
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void administrareUATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new frmUAT())
            {
                frm.ShowDialog(this); // deschide modal peste frmMain
            }
        }
    }
}
