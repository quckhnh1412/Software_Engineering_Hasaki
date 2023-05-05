using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Admin_report : Form
    {
        public Admin_report()
        {
            InitializeComponent();
        }

        private void Admin_report_Load(object sender, EventArgs e)
        {

        }

        private void btnfrmByDay_Click(object sender, EventArgs e)
        {
            Admin_report_by_day By_day = new Admin_report_by_day();
            By_day.Show();
            this.Hide();
        }

        private void btnfrmByProductType_Click(object sender, EventArgs e)
        {
            Admin_report_by_product_type By_product_type = new Admin_report_by_product_type();
            By_product_type.Show();
            this.Hide();
        }
    }
}
