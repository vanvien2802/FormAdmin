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

namespace ModernUI_FontAw.View
{
    public partial class FormCustommer : Form
    {
        DataTable dt;
        AdminBLL_Cus adMana = new AdminBLL_Cus();
        AdminBLL_OderHis adOHis = new AdminBLL_OderHis();
        public FormCustommer()
        {
            InitializeComponent();
            ShowAll_Mana();
            //Create();
            CreateCBB();
        }
        //public void Create()
        //{
        //    var l = add.GetAll().Select(p => new { p.ID_User, p.FirstName, p.LastName, p.DateOfBirth, p.Phone, p.Email, p.Day_Create, p.Gender, p.Money, p.ID_Employee });
        //    dgvShowCus.DataSource = l.ToList();
        //}
        public void CreateCBB()
        {
            cbbSort.Items.Clear();
            cbbSearch.Items.Clear();
            cbbSearch.Items.Add("All");
            cbbSearch.Items.Add("ID_User");
            cbbSearch.Items.Add("Name");
            cbbSort.Items.Add("Name");
            cbbSort.Items.Add("ID_User");
        }
        public void ShowAll_Mana()
        {
            foreach(Customer i in adMana.GetAll())
            {
                i.FullNameCus = i.FirstName + i.LastName;
                i.Employee.FullNameEm = i.Employee.FirstName + i.LastName;
            }
            var l = adMana.GetAll().Select(p => new { p.ID_User, p.FullNameCus, p.DateOfBirth, p.Phone, p.Email, p.Day_Create, p.Gender, p.Employee.FullNameEm });
            adMana = new AdminBLL_Cus();
            var data = l.ToList();
            dgvShowCus.DataSource = data;
        }
        public void ShowAll_His()
        {
            foreach (UseComputerHistory i in adOHis.GetAll())
            {
                i.Customer.FullNameCus = i.Customer.FirstName + i.Customer.LastName;
            }
            var l = adOHis.GetAll().Select(p => new { p.ID_HistoryUseComputer,p.Customer.FullNameCus,p.ID_Computer,p._LogIn,p._LogOut,p.HourUsed});
            adMana = new AdminBLL_Cus();
            var data = l.ToList();
            dgvHUse.DataSource = data;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string txt = txtSearch.Text;
            string s = cbbSearch.Text;

            if (tbMana.SelectedIndex == 0)
            {
                foreach (Customer i in adMana.GetAll())
                {
                    i.FullNameCus = i.FirstName + i.LastName;
                    i.Employee.FullNameEm = i.Employee.FirstName + i.LastName;
                }
                var l = adMana.Search(s, txt).Select(p => new { p.ID_User, p.FullNameCus, p.DateOfBirth, p.Phone, p.Email, p.Day_Create, p.Gender, p.Employee.FullNameEm });
                adMana = new AdminBLL_Cus();
                var data = l.ToList();
                dgvShowCus.DataSource = data;
            }
            else if (tbMana.SelectedIndex == 1)
            {
                var l = adOHis.Search(s, txt).Select(p => new { p.ID_HistoryUseComputer, p.Customer.FullNameCus, p.ID_Computer, p._LogIn, p._LogOut, p.HourUsed });
                adOHis = new AdminBLL_OderHis();
                var data = l.ToList();
                dgvHUse.DataSource = data;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormCusAdd_Up f = new FormCusAdd_Up("");
            f.d = new FormCusAdd_Up.MyDel(ShowAll_Mana);
            f.Show();
        }

        

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (dgvShowCus.SelectedRows.Count == 1)
            {
                string s = dgvShowCus.SelectedRows[0].Cells["ID_User"].Value.ToString();
                FormCusAdd_Up f = new FormCusAdd_Up(s);
                f.d = new FormCusAdd_Up.MyDel(ShowAll_Mana);
                f.Show();
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (tbMana.SelectedIndex == 0)
            {
                foreach (Customer i in adMana.GetAll())
                {
                    i.FullNameCus = i.FirstName + i.LastName;
                    i.Employee.FullNameEm = i.Employee.FirstName + i.LastName;
                }
                var l = adMana.Sort(cbbSort.Text).Select(p => new { p.ID_User, p.FullNameCus, p.DateOfBirth, p.Phone, p.Email, p.Day_Create, p.Gender, p.Employee.FullNameEm });
                adMana = new AdminBLL_Cus();
                var data = l.ToList();
                dgvShowCus.DataSource = data;
            }
            else if (tbMana.SelectedIndex == 1)
            {
                var l = adOHis.Sort(cbbSort.Text).Select(p => new { p.ID_HistoryUseComputer, p.Customer.FullNameCus, p.ID_Computer, p._LogIn, p._LogOut, p.HourUsed });
                adOHis = new AdminBLL_OderHis();
                var data = l.ToList();
                dgvHUse.DataSource = data;
            }

        }

        private void tbMana_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbMana.SelectedIndex == 0)
            {
                CreateCBB();

                ShowAll_Mana();
            }
            else if (tbMana.SelectedIndex == 1)
            {
                cbbSearch.Items.Clear();
                cbbSort.Items.Clear();
                cbbSearch.Items.Add("All");
                cbbSearch.Items.Add("ID_History");
                cbbSearch.Items.Add("Name");
                cbbSearch.Items.Add("ID_Customer");
                cbbSort.Items.Add("ID_Computer");
                cbbSort.Items.Add("ID_History");
                cbbSort.Items.Add("Name");
                ShowAll_His();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (tbMana.SelectedIndex == 1)
            {
                string s;
                foreach (DataGridViewRow i in dgvHUse.SelectedRows)
                {
                    s = i.Cells["ID_HistoryUseComputer"].Value.ToString();
                    adOHis.DelHis(s);
                }
            }
            ShowAll_His();
        }
    }
}
