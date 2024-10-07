using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonnelTrackingApplication.UIFormLayer
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private string _selectedDataBase;

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            _selectedDataBase = "SQLite";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            _selectedDataBase = "SqlServer";
        }

        frmMainMenu _frmMainMenu;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (rdbSQLite.Checked == false && rdbSqlServer.Checked == false) MessageBox.Show("Please select the database technology you want to work with.","Warning",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            else
            {
                if(_frmMainMenu == null || _frmMainMenu.IsDisposed) //if the form has not been opened before, we open it by generating an object from the frmMainMenu form.
                {
                    _frmMainMenu = new frmMainMenu(_selectedDataBase);
                    _frmMainMenu.Show();
                }
            }
            if (rdbSQLite.Checked == true && rdbSqlServer.Checked == true) MessageBox.Show("Please select only one database technology you would like to work with.", "Warning",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
