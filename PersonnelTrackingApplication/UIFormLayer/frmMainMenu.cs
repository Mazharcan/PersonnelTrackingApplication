using PersonnelTrackingApplication.DataAccessLayer.Abstract;
using PersonnelTrackingApplication.DataAccessLayer.Concrete.SQLite;
using PersonnelTrackingApplication.DataAccessLayer.Concrete.SqlServer;
using PersonnelTrackingApplication.EntitesLayer.Concreate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonnelTrackingApplication.UIFormLayer
{
    public partial class frmMainMenu : Form
    {
        public frmMainMenu(string dataBase) 
        {
            InitializeComponent();
            _employeeDAL = dataBase switch
            {
                "SQLite" => new SQLiteEmployeeDAL(),
                "SqlServer" => new SqlServerDAL(),
                _ => throw new NotSupportedException($"Unsupported database type: {dataBase}")
            };
        }

        IEmployeeDAL _employeeDAL;

        Employee _employee;  //We declare the running entity, create the object of this entity wherever we need it and assign values to the relevant fields.
        private int _selectedEmployeeID;

        private bool IsEmptyValue()
        {
            bool control = true;
            foreach (Control item in panelTools.Controls)     
            {
                if (item.Text == string.Empty || item.Text == " ")  //for dateTimePicker 
                {
                    control = false;
                }
            }
            return control;
        }
        private void GridViewOrganise()
        {
            dgvEmployee.Columns["Id"].Visible = false; //Id part in datagridview will not be visible to the user
            foreach (DataGridViewColumn column in dgvEmployee.Columns)  //will visit all columns in datagridview and capitalise each column
            {
                column.HeaderText = column.Name.ToUpper(CultureInfo.InvariantCulture);  //English capitalisation conversion
                if (column.Name == "TCno")
                    column.HeaderText = "TC NO";
                if (column.Name == "PersonnelNo")
                    column.HeaderText = "PERSONEL NO";
            }
            dgvEmployee.ClearSelection();  //we prevent row selection
        }

        private void ClearControls() 
        {
            foreach (Control control in panelTools.Controls) 
            {
                if (control is Label) //if control is a Label then go to the next control in the panel
                    continue;

                control.Text = string.Empty;
            }  
            dateBirthDate.Format = DateTimePickerFormat.Custom;
            dateBirthDate.CustomFormat = " ";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsEmptyValue()) //First of all, if even one check is empty, IsEmptyValue() will be false, but we use the ! operator so that it is true and we enter the if block and give a warning message.
                {
                    MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    _employee = new Employee //We have created a new entity with values loaded into its props.
                    {
                        Name = tbxName.Text,
                        LastName = tbxLastName.Text,
                        TCno = msktbxTCno.Text,
                        PersonnelNo = tbxPersonnelNo.Text,
                        BirthDate = dateBirthDate.Value,
                        Department = cbxDepartment.SelectedItem.ToString(),
                        Title = cbxTitle.SelectedItem.ToString(),
                        Status = cbxStatus.SelectedItem.ToString()
                    };
                    //Now we send this entity as a parameter to the save method in SQLiteEmployeeDAL class.
                    bool process = _employeeDAL.Save(_employee); //If the save method saves successfully, the process variable becomes true because the save method returns true.
                    if (process)
                    {
                        MessageBox.Show("Saving has been done.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvEmployee.DataSource = _employeeDAL.ListEmployees(string.Empty); //To use it to list all records, we write string.Empty to the parameter it requests (we write the where condition as a parameter).
                        GridViewOrganise();
                        ClearControls();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControls();
            dgvEmployee.DataSource = _employeeDAL.ListEmployees(string.Empty);
            _selectedEmployeeID = 0;
            GridViewOrganise();
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            //dgvEmployee.DataSource = _employeeDAL.ListEmployees("WHERE status = 'Active Employee'"); //When the form is first loaded, it will list data whose status property is ‘active employee’.
            dgvEmployee.DataSource = _employeeDAL.ListEmployees(string.Empty); 
            GridViewOrganise();
            ClearControls();
        }

        private void dateBirthDate_ValueChanged(object sender, EventArgs e)
        {
            //When we clear the datetimepicker, when we want to change the value, so that it can return to its old format again. 
            dateBirthDate.Format = DateTimePickerFormat.Short; 
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectedEmployeeID = int.Parse(dgvEmployee.CurrentRow.Cells[0].Value.ToString());
            tbxName.Text = dgvEmployee.CurrentRow.Cells[1].Value.ToString();
            tbxLastName.Text = dgvEmployee.CurrentRow.Cells[2].Value.ToString();
            msktbxTCno.Text = dgvEmployee.CurrentRow.Cells[3].Value.ToString();
            tbxPersonnelNo.Text = dgvEmployee.CurrentRow.Cells[4].Value.ToString();
            dateBirthDate.Value = DateTime.Parse(dgvEmployee.CurrentRow.Cells[5].Value.ToString());
            dateBirthDate.Format = DateTimePickerFormat.Short; //we was changed the datetime format. In order to show it again in the form load method, we need to convert it to short format.
            cbxDepartment.SelectedItem = dgvEmployee.CurrentRow.Cells[6].Value.ToString();
            cbxTitle.SelectedItem = dgvEmployee.CurrentRow.Cells[7].Value.ToString();
            cbxStatus.SelectedItem = dgvEmployee.CurrentRow.Cells[8].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedEmployeeID == 0)  //if the user does not select any record
                    MessageBox.Show("Please select the record you want to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (!IsEmptyValue()) //if the record is selected, this time check whether the relevant fields are empty or not
                    MessageBox.Show("Please fill in the mandatory fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    _employee = new Employee //We have created a new entity with values loaded into its props.
                    {
                        Id = _selectedEmployeeID,
                        Name = tbxName.Text,
                        LastName = tbxLastName.Text,
                        TCno = msktbxTCno.Text,
                        PersonnelNo = tbxPersonnelNo.Text,
                        BirthDate = dateBirthDate.Value,
                        Department = cbxDepartment.SelectedItem.ToString(),
                        Title = cbxTitle.SelectedItem.ToString(),
                        Status = cbxStatus.SelectedItem.ToString()
                    };
                    bool process = _employeeDAL.Update(_employee);
                    if (process)
                    {
                        dgvEmployee.DataSource = _employeeDAL.ListEmployees(string.Empty);
                        GridViewOrganise();
                        MessageBox.Show("Updating has been done.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearControls();
                    }
                    _selectedEmployeeID = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedEmployeeID == 0)
                    MessageBox.Show("Please select the record you want to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else 
                {
                    DialogResult approval = MessageBox.Show("The selected record will be permanently deleted.\nDo you confirm the deletion of the selected record?","Record Will be Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if (approval == DialogResult.Yes)  //if user say yes
                    {
                        bool process = _employeeDAL.Delete(_selectedEmployeeID);
                        if (process) 
                        {
                            MessageBox.Show("The record has been permanently deleted from the database.","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        }
                        dgvEmployee.DataSource = _employeeDAL.ListEmployees(string.Empty);
                        GridViewOrganise();
                        ClearControls();
                    }
                    _selectedEmployeeID = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult approval = MessageBox.Show("All records in the database will be deleted..\n Do you confirm the deletion of the all record?", "All Record Will be Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (approval == DialogResult.Yes)  //if user say yes
                {
                    bool process = _employeeDAL.Delete(string.Empty); //this will be delete all records from Employees
                    if (process)
                    {
                            MessageBox.Show("The record has been permanently deleted from the database.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    dgvEmployee.DataSource = null; //Since all the data in the database is already deleted, there is no need to assign something to datagridview> datasource.
                    GridViewOrganise();
                    ClearControls();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string CreateConditionClause()  //will create a condition statement for the List method in the employeeDAL class.
        {
            string conditionClause = string.Empty;
            List<string> fields = new List<string>();
            //to navigate to the controls where the user can enter data :
            foreach (Control control in panelTools.Controls)
            {
                if (control.Tag == null) continue; //if the tag value of the control is null > we only assigned tag values to tbx,cmbx,mskbx or it will skip labels

                string fieldName = control.Tag.ToString(); //assign the tag value of that control to the fieldName string for full tag values
                string value = string.Empty; //if the user enters data into the corresponding control, assign that data to the value string

                if (String.IsNullOrEmpty(control.Text) || control.Text == " ") continue; //if no data is entered in the relevant non-labelled controls, pass them directly / control.Text == ‘ ’ for datetimepicker!  

                //passing these, if there is a control where the user enters data =>    
                value = control.Text; //we assigned the data entered by the user in the relevant control to the value value

                if (control.Name == "dateBirthDate")
                {
                    fields.Add($"{fieldName} = {value}");
                }

                //lists the records that contain the data entered with the like operator
                else
                {
                    fields.Add($"{fieldName} LIKE '%{value}%'");
                }

            }
            if (fields.Count > 0) conditionClause = $"WHERE {string.Join(" AND ", fields)}";  //that is, if the user has entered at least 1 controle data, create our condition sentence in this way.

            return conditionClause;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvEmployee.DataSource = _employeeDAL.ListEmployees(CreateConditionClause());
            GridViewOrganise();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            _employee = _employeeDAL.GetEmployee(CreateConditionClause());
            if (_employee != null)
            {
                MessageBox.Show($"{_employee.Id.ToString()}\n" +
                $"{_employee.Name}\n" +
                $"{_employee.LastName}" +
                $"\n{_employee.TCno.ToString()}\n" +
                $"{_employee.PersonnelNo.ToString()}\n" +
                $"{_employee.BirthDate.ToString()}\n" +
                $"{_employee.Department}\n" +
                $"{_employee.Title}\n" +
                $"{_employee.Status}");
            }
        }
    }
}
