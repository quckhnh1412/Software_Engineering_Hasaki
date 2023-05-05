using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Admin_report_by_product_type : Form
    {
        public Admin_report_by_product_type()
        {
            InitializeComponent();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void Admin_report_by_product_type_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=HASAKI;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Categories ";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["CategoryName"].ToString());
            }
            reader.Close();
            connection.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string selectedLoai = comboBox1.SelectedItem.ToString();
                string connectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=HASAKI;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionString);
                string query = "SELECT * FROM OrderDetails WHERE ProductID in (SELECT ProductID FROM Products WHERE CategoryID = (SELECT CategoryID FROM Categories WHERE CategoryName = @Loai))";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Loai", selectedLoai);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;

                int totalQuantity = 0;
                if (Int32.TryParse(table.Compute("SUM(Quantity)", "").ToString(), out totalQuantity))
                {
                    labelCount.Text = totalQuantity.ToString();
                }
                else
                {
                    labelCount.Text = "0";
                }

                SqlConnection connection1 = new SqlConnection(connectionString);
                string query1 = "SELECT SUM(od.Quantity * p.UnitPrice) AS TotalSum FROM OrderDetails od INNER JOIN Products p ON od.ProductID = p.ProductID WHERE p.CategoryID = (SELECT CategoryID FROM Categories WHERE CategoryName = @Loai)";
                SqlCommand command1 = new SqlCommand(query1, connection1);
                command1.Parameters.AddWithValue("@Loai", selectedLoai);
                connection1.Open();
                decimal totalSum = 0;
                object result = command1.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    totalSum = Convert.ToDecimal(result);
                }
                connection1.Close();
                int totalSumInt = Convert.ToInt32(totalSum);
                labelTotalSum.Text = totalSumInt.ToString();


            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string outputPath = @"D:\reportByProductType.txt";
            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                writer.WriteLine("Báo cáo doanh thu về " + comboBox1.SelectedItem.ToString());
                writer.WriteLine("- Tổng số sản phẩm bán ra : " + labelCount.Text);
                writer.WriteLine("- Tổng tiền: " + labelTotalSum.Text);
            }

            MessageBox.Show("Xuất file thành công!");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Admin_report report = new Admin_report();
            report.Show();
            this.Hide();
        }
    }
}
