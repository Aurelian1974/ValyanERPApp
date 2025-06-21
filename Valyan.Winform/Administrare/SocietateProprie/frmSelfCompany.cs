using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Syncfusion DataGrid
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.DataGrid; // Ensure this namespace is included  
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.DataGrid.Styles;

// Fix for CS0246: Ensure the correct namespace is used for IGridCellTemplate  
using Syncfusion.WinForms.DataGrid;
// Add the correct namespace for IGridCellTemplate  
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Styles;
using Syncfusion.WinForms.DataGrid.Styles;

namespace Valyan.Winform.Administrare.SocietateProprie
{
    public partial class frmSelfCompany : Form
    {
        private List<Employee> employees; // Declare the 'employees' field

        public frmSelfCompany()
        {
            InitializeComponent();
        }

        private void frmSelfCompany_Load(object sender, EventArgs e)
        {
            InitializeDataGrid();
            LoadData();
        }

        private void InitializeDataGrid()
        {
            // Existing code for initializing the DataGrid
        }

        private void LoadData()
        {
            // Existing code for loading data into the DataGrid
        }
    }

    // Template personalizat pentru butoane
    public class ActionButtonTemplate : IGridCellTemplate
    {
        private Button editButton;
        private Button deleteButton;
        private Button viewButton;
        private Panel buttonPanel;
        private MainForm parentForm;
        private Employee currentEmployee;

        public ActionButtonTemplate(MainForm form)
        {
            parentForm = form;
            Initialize();
        }

        public void Initialize()
        {
            // Creează panel-ul container
            buttonPanel = new Panel()
            {
                Size = new Size(170, 30),
                Padding = new Padding(2)
            };

            // Buton pentru vizualizare
            viewButton = new Button()
            {
                Text = "👁",
                Size = new Size(30, 26),
                Location = new Point(2, 2),
                BackColor = Color.LightGreen,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            viewButton.FlatAppearance.BorderSize = 1;
            viewButton.FlatAppearance.BorderColor = Color.DarkGreen;

            // Buton pentru editare
            editButton = new Button()
            {
                Text = "✏",
                Size = new Size(30, 26),
                Location = new Point(36, 2),
                BackColor = Color.LightBlue,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            editButton.FlatAppearance.BorderSize = 1;
            editButton.FlatAppearance.BorderColor = Color.DarkBlue;

            // Buton pentru ștergere
            deleteButton = new Button()
            {
                Text = "🗑",
                Size = new Size(30, 26),
                Location = new Point(70, 2),
                BackColor = Color.LightCoral,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            deleteButton.FlatAppearance.BorderSize = 1;
            deleteButton.FlatAppearance.BorderColor = Color.DarkRed;

            // Event handlers
            viewButton.Click += ViewButton_Click;
            editButton.Click += EditButton_Click;
            deleteButton.Click += DeleteButton_Click;

            // Tooltip-uri
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(viewButton, "Vizualizează detalii");
            toolTip.SetToolTip(editButton, "Editează angajat");
            toolTip.SetToolTip(deleteButton, "Șterge angajat");

            // Adaugă butoanele la panel
            buttonPanel.Controls.Add(viewButton);
            buttonPanel.Controls.Add(editButton);
            buttonPanel.Controls.Add(deleteButton);
        }

        private void ViewButton_Click(object sender, EventArgs e)
        {
            if (currentEmployee != null && parentForm != null)
            {
                parentForm.ViewEmployee(currentEmployee);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (currentEmployee != null && parentForm != null)
            {
                parentForm.EditEmployee(currentEmployee);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (currentEmployee != null && parentForm != null)
            {
                parentForm.DeleteEmployee(currentEmployee);
            }
        }

        public Control GetTemplate()
        {
            return buttonPanel;
        }

        // Această metodă este apelată când template-ul este setat pentru o celulă
        public void SetCellValue(object value)
        {
            // Value este obiectul din linia curentă
            currentEmployee = value as Employee;
        }
    }

    // Clasa Employee
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
    }
}
