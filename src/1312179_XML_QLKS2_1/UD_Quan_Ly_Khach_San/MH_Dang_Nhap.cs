using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UD_Quan_Ly_Khach_San
{
    public partial class MH_Dang_Nhap : Form
    {
        int ID_KS_Chieu_Ha_Vang = 1;
        protected XL_Nghiep_Vu_QLKS NghiepVu = new XL_Nghiep_Vu_QLKS();
        public MH_Dang_Nhap()
        {
            InitializeComponent();
        }

        private void btn_Dang_Nhap_Click(object sender, EventArgs e)
        {
            //Kiem tra textbox
            if (tbx_Ten_Dang_Nhap.Text == "")
            {
                lb_Thong_Bao_Loi.Text = "Tên đăng nhập không được rỗng.";
                return;
            }
            if (tbx_Mat_Khau.Text == "")
            {
                lb_Thong_Bao_Loi.Text = "Mật khẩu không được rỗng.";
                return;
            }
            //Kiem tra tài khoản
            if (NghiepVu.Kiem_Tra_Dang_Nhap(tbx_Ten_Dang_Nhap.Text, tbx_Mat_Khau.Text))
            {
                //MessageBox.Show("THANH CONG");
                lb_Thong_Bao_Loi.Text = "";

                MH_Thong_Ke tc = new MH_Thong_Ke();

                tc.ShowDialog();

            }
            else
            {
                lb_Thong_Bao_Loi.Text = "Tên đăng nhập hoặc Mật khẩu chưa đúng.";
                //MessageBox.Show("THAT BAI");
            }
            //
        }
    }
}
