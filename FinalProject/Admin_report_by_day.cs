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
    public partial class Admin_report_by_day : Form
    {
        public Admin_report_by_day()
        {
            InitializeComponent();
        }

        private void Admin_report_by_day_Load(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void labelTongDon_Click(object sender, EventArgs e)
        {

        }

        private void btnSearchByDay_Click(object sender, EventArgs e)
        {
            DateTime searchDate;
            if (!DateTime.TryParse(maskedTextBox1.Text, out searchDate))
            {
                MessageBox.Show("Vui lòng nhập định dạng ngày hợp lệ (mm/dd/yyyy).");
                return;
            }

            string connectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=HASAKI;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM Orders WHERE CONVERT(date, OrderDate) = @SearchDate";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SearchDate", searchDate);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            int rowCount = dataTable.Rows.Count;
            int totalAmount = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                totalAmount += Convert.ToInt32(row["TotalAmount"]);
            }
            labelTongDon.Text = rowCount.ToString();
            labelTongTien.Text = totalAmount.ToString();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string outputPath = @"D:\reportByDay.txt";
            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                writer.WriteLine("Báo cáo ngày " + maskedTextBox1.Text +" :");
                writer.WriteLine("- Tổng số đơn: " + labelTongDon.Text);
                writer.WriteLine("- Tổng tiền: " + labelTongTien.Text);
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
