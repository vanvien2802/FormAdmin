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
    public partial class FormProducts : Form
    {
        DataTable dt;
        AdminBLL_Pro add = new AdminBLL_Pro();
        public FormProducts()
        {
            InitializeComponent();
            var data = add.GetAll().Select(p => new {p.ID_Product, p.NameProduct, p.ID_Category,p.ID_Unit,p.Amount,p.Price});
            dataGridView1.DataSource = data.ToList();
        }
        public void Create()
        {
            for (int i = 0; i < 100; i++)
            {
                dt.Rows.Add(new object[]
                {
                    imageList1.Images[0],
                });
            }
        }

        private void btnPrMana_Click(object sender, EventArgs e)
        {
            btnHistory.BackColor = Color.FromArgb(64, 45, 64);
            btnMerMana.BackColor = Color.FromArgb(64, 45, 64);
            btnPrMana.BackColor = Color.RosyBrown;
            dataGridView1.Columns.Clear();
            dt = new DataTable();
            dt.Columns.AddRange(new[]
                {
                    new DataColumn(" ", typeof(Image)),
                    new DataColumn("STT", typeof(int)),
                    new DataColumn("IdProduct", typeof(string)),
                    new DataColumn("NameProduct", typeof(string)),
                    new DataColumn("ImportPrice", typeof(DateTime)),
                    new DataColumn("SellingPrice", typeof(string)),
                });
            Create();
            dataGridView1.DataSource = dt;
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            btnHistory.BackColor = Color.RosyBrown;
            btnPrMana.BackColor = Color.FromArgb(64, 45, 64);
            btnMerMana.BackColor = Color.FromArgb(64, 45, 64);
            dataGridView1.Columns.Clear();
            dt = new DataTable();
            dt.Columns.AddRange(new[]
                {
                    new DataColumn(" ", typeof(Image)),
                    new DataColumn("STT", typeof(int)),
                    new DataColumn("IdProduct", typeof(string)),
                    new DataColumn("Customer", typeof(string)),
                    new DataColumn("DayUsed", typeof(DateTime)),
                    new DataColumn("NameProduct", typeof(string)),
                    new DataColumn("Amount", typeof(int)),
                    new DataColumn("Cost/1", typeof(double)),
                });
            Create();
            dataGridView1.DataSource = dt;
        }

        private void btnMerMana_Click(object sender, EventArgs e)
        {
            btnHistory.BackColor = Color.FromArgb(64, 45, 64);
            btnPrMana.BackColor = Color.FromArgb(64, 45, 64);
            btnMerMana.BackColor = Color.RosyBrown;
            dataGridView1.Columns.Clear();
            dt = new DataTable();
            dt.Columns.AddRange(new[]
                {
                    new DataColumn(" ", typeof(Image)),
                    new DataColumn("STT", typeof(int)),
                    new DataColumn("IdProduct", typeof(string)),
                    new DataColumn("NameProduct", typeof(string)),
                    new DataColumn("ImportDate", typeof(int)),
                    new DataColumn("ExpiryDate", typeof(double)),
                });
            Create();
            dataGridView1.DataSource = dt;
        }
    }
}
