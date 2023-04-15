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
    public partial class Admin_employee_detail : Form
    {
        private String manv, name,  mapq,  sdt, cccd,  diachi, gioitinh, ngaysinh, ngayvao;

        private void Admin_employee_detail_Load(object sender, EventArgs e)
        {
            txtManv.Text = manv;
            txtName.Text = name;
            txtGen.Text = gioitinh;
            txtDate.Text = ngaysinh;
            txtCCCD.Text = cccd;
            txtDiachi.Text = diachi;
            txtSdt.Text = sdt;
            txtMapq.Text = mapq;
            txtNgayVao.Text = ngayvao;
        }

        public Admin_employee_detail()
        {
            InitializeComponent();
        }

        public Admin_employee_detail(String manv, String name, String mapq, String sdt, String cccd, String diachi, String gioitinh, String ngaysinh, String ngayvao)
        {
            InitializeComponent();
            this.manv = manv;
            this.name = name;
            this.mapq = mapq;
            this.sdt = sdt;
            this.cccd = cccd;
            this.diachi = diachi;
            this.gioitinh   = gioitinh;
            this.ngaysinh = ngaysinh;
            this.ngayvao= ngayvao;
        }
    }
}
