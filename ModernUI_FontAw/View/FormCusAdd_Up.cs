using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModernUI_FontAw.BLL;
using ModernUI_FontAw.Model;

namespace ModernUI_FontAw.View
{
    public partial class FormCusAdd_Up : Form
    {
        public delegate void MyDel(); // cái gì đây ?
        public MyDel d;
        AdminBLL_Cus adBLL = new AdminBLL_Cus();
        string id;
        public FormCusAdd_Up(string m)
        {
            id = m;
            InitializeComponent();
            GUI();
        }
        void GUI()
        {
            if (id != "")
            {
                int i = Convert.ToInt32(id);
                Customer s = adBLL.GetCusById(i);
                txtFirst.Text = s.FirstName.ToString();
                txtLast.Text = s.LastName.ToString();
                txtPhone.Text = s.Phone.ToString();
                txtEmail.Text = s.Email.ToString();
                dtpDOB.Text = s.DateOfBirth.ToLongDateString();
                dtpDCrea.Text = s.Day_Create.ToLongDateString();
                txtMoney.Text = s.Money.ToString();
                txtIDE.Text = s.ID_Employee.ToString();
                txtID_U.Text = s.ID_User.ToString();
                if (s.Gender == true) rdMale.Checked = true;
                else rdFemale.Checked = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            bool check;
            if(rdMale.Checked) check = true;
            else check = false;
            Customer cus = new Customer
            {
                FirstName = txtFirst.Text,
                LastName = txtLast.Text,
                Phone = txtPhone.Text,
                Email = txtEmail.Text,
                DateOfBirth = dtpDOB.Value,
                Day_Create = dtpDCrea.Value,
                Money = Convert.ToInt32(txtMoney.Text),
                ID_Employee = Convert.ToInt32(txtIDE.Text),
                ID_User = Convert.ToInt32(txtID_U.Text),
                Gender = check,
            };
            adBLL.UpdateAdd(cus);
            d();
            this.Dispose();
        }
    }
}
