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
    public partial class Admin_employee_list : Form
    {
        public Admin_employee_list()
        {
            InitializeComponent();
        }

        private void Admin_employee_list_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hASAKIDataSet.NHANVIEN' table. You can move, or remove it, as needed.
            this.nHANVIENTableAdapter.Fill(this.hASAKIDataSet.NHANVIEN);
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=HASAKI;Integrated Security=True";
            conn.Open();
            String sSQL = "SELECT * FROM tblNHANVIEN";
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
            int index = e.RowIndex;
            if (index < 0 || index >= dataGridView1.RowCount)
                return;
            try
            {
                DataGridViewRow row = dataGridView1.Rows[index];
                String manv = Convert.ToString(row.Cells[0].Value);
                String name = Convert.ToString(row.Cells[1].Value);
                String mapq = Convert.ToString(row.Cells[2].Value);
                String sdt = Convert.ToString(row.Cells[3].Value);
                String cccd = Convert.ToString(row.Cells[4].Value);
                String diachi = Convert.ToString(row.Cells[5].Value);
                String gioitinh = Convert.ToString(row.Cells[6].Value);
                String ngaysinh = Convert.ToString(row.Cells[7].Value);
                String ngayvaoviec = Convert.ToString(row.Cells[8].Value);
                Admin_employee_detail employee_Detail= new Admin_employee_detail(manv,name,mapq,sdt,cccd,diachi,gioitinh,ngaysinh,ngayvaoviec);
                employee_Detail.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex.Message);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=HASAKI;Integrated Security=True";
            conn.Open();
            String sSQL = "SELECT * FROM tblNHANVIEN WHERE MANV = " + txtSearch.Text + "";
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

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Admin_customer_list customer_List = new Admin_customer_list();
            customer_List.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Admin_supplier_list supplier_List = new Admin_supplier_list();
            supplier_List.Show();
        }
    }
}
