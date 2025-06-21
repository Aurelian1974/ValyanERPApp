using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.DataGrid.Styles;

namespace Valyan.Winform.Administrare.SocietateProprie
{
    public partial class frmSelfCompany : Form
    {
        private readonly List<Employee> employees;

        public frmSelfCompany()
        {
            InitializeComponent();
            employees = new List<Employee>();
            InitializeDataGrid();
        }

        private void frmSelfCompany_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void InitializeDataGrid()
        {
            sfDataGrid1.Dock = DockStyle.Fill;
            sfDataGrid1.AutoGenerateColumns = false;
            sfDataGrid1.Columns.Clear();

            sfDataGrid1.Columns.Add(new GridTextColumn { MappingName = "EmployeeID", HeaderText = "ID" });
            sfDataGrid1.Columns.Add(new GridTextColumn { MappingName = "FirstName", HeaderText = "Prenume" });
            sfDataGrid1.Columns.Add(new GridTextColumn { MappingName = "LastName", HeaderText = "Nume" });
            sfDataGrid1.Columns.Add(new GridTextColumn { MappingName = "Department", HeaderText = "Departament" });
            sfDataGrid1.Columns.Add(new GridTextColumn { MappingName = "Salary", HeaderText = "Salariu" });

            // Coloana cu buton pentru acțiuni
            var actionColumn = new GridButtonColumn
            {
                MappingName = "Action",
                HeaderText = "Acțiune",
                //Text = "Detalii",
                Width = 100
            };
            sfDataGrid1.Columns.Add(actionColumn);

            // Eveniment pentru click pe buton
            sfDataGrid1.CellButtonClick += SfDataGrid1_CellButtonClick;
        }

        private void SfDataGrid1_CellButtonClick(object sender, CellButtonClickEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var recordEntry = sfDataGrid1.View.GetRecordAt(e.RowIndex);
            var employee = (recordEntry as Syncfusion.Data.RecordEntry)?.Data as Employee;
            if (employee != null)
            {
                MessageBox.Show($"Detalii angajat: {employee.FirstName} {employee.LastName}");
            }
        }

        private void LoadData()
        {
            employees.Clear();
            employees.Add(new Employee
            {
                EmployeeID = 1,
                FirstName = "Ioan",
                LastName = "Popescu",
                Department = "IT",
                Salary = 5000
            });
            employees.Add(new Employee
            {
                EmployeeID = 2,
                FirstName = "Maria",
                LastName = "Ionescu",
                Department = "HR",
                Salary = 4200
            });
            sfDataGrid1.DataSource = employees;
        }
    }

    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        // Proprietate dummy pentru coloana de acțiune
        public string Action => "Detalii";
    }
}
