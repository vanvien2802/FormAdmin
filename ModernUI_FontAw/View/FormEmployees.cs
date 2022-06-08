using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModernUI_FontAw.Model;
using ModernUI_FontAw.BLL;
using ModernUI_FontAw.Repositories;

namespace ModernUI_FontAw
{
    public partial class FormEmployees : Form
    {
        private string filter;
        AdminBLL_Em add = new AdminBLL_Em();
        public FormEmployees()
        {
            InitializeComponent();
            dataGridView1.DataSource = add.GetAll().Select(p => new {
                p.ID_User,
                p.FirstName,
                p.LastName,
                p.DateOfBirth,
                p.Phone,
                p.Email,
                p.Day_Create,
                p.Gender,
                p.ID_SalaryEmployee,
                p.Identify
            }).ToList();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            this.filter = "";
        }

        private void btnFull_Click(object sender, EventArgs e)
        {

        }
    }
}
