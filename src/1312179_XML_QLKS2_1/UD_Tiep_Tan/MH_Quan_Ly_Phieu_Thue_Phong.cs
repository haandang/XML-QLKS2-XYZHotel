using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UD_Tiep_Tan.BusinessServiceRef;
namespace UD_Tiep_Tan
{
    public partial class MH_Quan_Ly_Phieu_Thue_Phong : Form
    {
        BusinessServiceSoapClient dssc = new BusinessServiceSoapClient();
        public MH_Quan_Ly_Phieu_Thue_Phong()
        {
            InitializeComponent();
            //BusinessServiceRef.ctho
            MessageBox.Show("Chức năng đang được phát triển.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_A_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang được phát triển.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Dang_Xuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
