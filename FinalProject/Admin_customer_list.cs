using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Admin_customer_list : Form
    {
        public Admin_customer_list()
        {
            InitializeComponent();
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Admin_employee_list employee_List = new Admin_employee_list();
            employee_List.Show();
        }

        private void Admin_customer_list_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hASAKIDataSet.KHACHHANG' table. You can move, or remove it, as needed.
            this.kHACHHANGTableAdapter.Fill(this.hASAKIDataSet.KHACHHANG);
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=HASAKI;Integrated Security=True";
            conn.Open();
            String sSQL = "SELECT * FROM tblKHACHHANG";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("No Data");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Admin_supplier_list supplier_List = new Admin_supplier_list();
            supplier_List.Show();
        }
    }
}
