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

namespace ModernUI_FontAw
{
    public partial class FormShift : Form
    {
        AdminBLL_Shi add = new AdminBLL_Shi();
        public FormShift()
        {
            InitializeComponent();
            Create();
        }
        public void Create()
        {
            var data = add.GetAll().Select(p => new { p.ID_Shift, p.Employee.FirstName, p.Employee.LastName, p.ID_Employee, p.Date_Work, p.Hour, p.StatusShift.Description });
            dataGridView1.DataSource = data.ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtSearch.Text != null)
            {

            }
        }
        
        private void btnDel_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    String maso = i.Cells["ID_Shift"].Value.ToString();
                    int id = Convert.ToInt32(maso);
                    add.DelShift(id);
                }
            }
            Create();
        }
    }
}
