using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UD_Tiep_Tan
{
    public partial class MH_Quan_Ly_Phieu_Thue_Phong_KVB : Form
    {
        public MH_Quan_Ly_Phieu_Thue_Phong_KVB()
        {
            InitializeComponent();
            MessageBox.Show("Chức năng đang được phát triển.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_B_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang được phát triển.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Dang_Xuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
