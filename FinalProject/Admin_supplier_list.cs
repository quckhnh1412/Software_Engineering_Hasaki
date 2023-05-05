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
    public partial class Admin_supplier_list : Form
    {
        public Admin_supplier_list()
        {
            InitializeComponent();
        }

        private void Admin_supplier_list_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hASAKIDataSet.NHACUNGCAP' table. You can move, or remove it, as needed.
            this.nHACUNGCAPTableAdapter.Fill(this.hASAKIDataSet.NHACUNGCAP);
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=HASAKI;Integrated Security=True";
            conn.Open();
            String sSQL = "SELECT * FROM tblNHACUNGCAP";
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

        private void label4_Click(object sender, EventArgs e)
        {
            Admin_order_list order_List = new Admin_order_list();
            order_List.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Admin_customer_list customer_List = new Admin_customer_list();
            customer_List.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Admin_bill_list bill_List = new Admin_bill_list();
            bill_List.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Admin_employee_list employee_List = new Admin_employee_list();
            employee_List.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=HASAKI;Integrated Security=True";
            conn.Open();
            String sSQL = "SELECT * FROM tblHOADON_SANPHAM WHERE MANCC = " + txtSearch.Text + "";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
