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
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;

// Fix for CS0234: The type or namespace name 'Cells' does not exist in the namespace 'Syncfusion.WinForms.DataGrid'  
// Ensure the correct namespace is used and the required assembly reference is added.  

// Update the using directive to the correct namespace.  
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Styles;

// Remove the incorrect namespace reference.  
// The namespace 'Syncfusion.WinForms.DataGrid.Cells' does not exist, so it should be removed.
using Syncfusion.WinForms.DataGrid.Styles;

namespace Valyan.Winform.Administrare.SocietateProprie;

public partial class MainForm : Form
{
    // Fix for CS0102: Ensure there is only one definition of 'sfDataGrid1' in the class.
    // Remove duplicate declaration of 'sfDataGrid1' if it exists elsewhere in the file.

    private readonly SfDataGrid sfDataGrid1; // This declaration is correct and should remain.
    private readonly List<Employee> employees;

    public MainForm()
    {
        InitializeComponent();
        sfDataGrid1 = new SfDataGrid();
        InitializeDataGrid();
        LoadData();
    }

    private void InitializeDataGrid()
    {
        // Initialize and configure DataGrid
        sfDataGrid1 = new SfDataGrid()
        {
            Dock = DockStyle.Fill,
            AutoGenerateColumns = false,
            AllowEditing = false,
            AllowSorting = true,
            AllowFiltering = true
        };

        // Add normal columns
        sfDataGrid1.Columns.Add(new GridTextColumn()
        {
            MappingName = "EmployeeID",
            HeaderText = "ID",
            Width = 80
        });

        sfDataGrid1.Columns.Add(new GridTextColumn()
        {
            MappingName = "FirstName",
            HeaderText = "Prenume",
            Width = 120
        });

        sfDataGrid1.Columns.Add(new GridTextColumn()
        {
            MappingName = "LastName",
            HeaderText = "Nume",
            Width = 120
        });

        sfDataGrid1.Columns.Add(new GridTextColumn()
        {
            MappingName = "Department",
            HeaderText = "Departament",
            Width = 150
        });

        sfDataGrid1.Columns.Add(new GridTextColumn()
        {
            MappingName = "Salary",
            HeaderText = "Salariu",
            Width = 100,
            Format = "C"
        });

        // Add template column with buttons
        GridTemplateColumn templateColumn = new GridTemplateColumn()
        {
            MappingName = "Actions",
            HeaderText = "Acțiuni",
            Width = 180,
            AllowSorting = false,
            AllowFiltering = false
        };

        // Set custom template
        templateColumn.CellTemplate = new ActionButtonTemplate(this);
        sfDataGrid1.Columns.Add(templateColumn);

        // Add DataGrid to form
        this.Controls.Add(sfDataGrid1);
    }

    private void LoadData()
    {
        // Test data
        employees = new List<Employee>
        {
            new Employee { EmployeeID = 1, FirstName = "Ion", LastName = "Popescu", Department = "IT", Salary = 5000 },
            new Employee { EmployeeID = 2, FirstName = "Maria", LastName = "Ionescu", Department = "HR", Salary = 4500 },
            new Employee { EmployeeID = 3, FirstName = "Andrei", LastName = "Gheorghe", Department = "Finance", Salary = 5500 },
            new Employee { EmployeeID = 4, FirstName = "Ana", LastName = "Stoica", Department = "Marketing", Salary = 4000 },
            new Employee { EmployeeID = 5, FirstName = "Mihai", LastName = "Radu", Department = "IT", Salary = 6000 }
        };

        sfDataGrid1.DataSource = employees;
    }

    // Public methods for template actions
    public void EditEmployee(Employee employee)
    {
        MessageBox.Show($"Editare angajat: {employee.FirstName} {employee.LastName}\n" +
                      $"ID: {employee.EmployeeID}\n" +
                      $"Departament: {employee.Department}",
                      "Editare Angajat",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information);

        // Open edit form (if needed)
        // EditEmployeeForm editForm = new EditEmployeeForm(employee);
        // if (editForm.ShowDialog() == DialogResult.OK)
        // {
        //     RefreshGrid();
        // }
    }

    public void DeleteEmployee(Employee employee)
    {
        var result = MessageBox.Show($"Sigur vrei să ștergi angajatul {employee.FirstName} {employee.LastName}?",
                                   "Confirmare Ștergere",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            employees.Remove(employee);
            RefreshGrid();
            MessageBox.Show("Angajatul a fost șters cu succes!",
                          "Ștergere Completă",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
        }
    }

    public void ViewEmployee(Employee employee)
    {
        MessageBox.Show($"Detalii Angajat:\n\n" +
                      $"ID: {employee.EmployeeID}\n" +
                      $"Nume: {employee.FirstName} {employee.LastName}\n" +
                      $"Departament: {employee.Department}\n" +
                      $"Salariu: {employee.Salary:C}",
                      "Vizualizare Angajat",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
    }

    private void RefreshGrid()
    {
        sfDataGrid1.DataSource = null;
        sfDataGrid1.DataSource = employees;
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

