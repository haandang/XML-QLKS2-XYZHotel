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
    public partial class MH_Dang_Nhap : Form
    {
        XL_Nghiep_Vu_Tiep_Tan NghiepVu = new XL_Nghiep_Vu_Tiep_Tan();
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
            int TTKV = NghiepVu.Kiem_Tra_Dang_Nhap(tbx_Ten_Dang_Nhap.Text, tbx_Mat_Khau.Text);
            //Kiem tra tài khoản

            switch (TTKV)
            {
                case 0: //Lỗi
                    lb_Thong_Bao_Loi.Text = "Tên đăng nhập hoặc tài khoản không đúng.";
                    break;
                case 1: //KV A
                    MH_Quan_Ly_Phieu_Thue_Phong mha = new MH_Quan_Ly_Phieu_Thue_Phong();
                    mha.ShowDialog();
                    break;
                case 2: //KV B
                    MH_Quan_Ly_Phieu_Thue_Phong_KVB mhb = new MH_Quan_Ly_Phieu_Thue_Phong_KVB();
                    mhb.ShowDialog();
                    break;
                case 3: //KV C
                    MH_Quan_Ly_Phieu_Thue_Phong_KVC mhc = new MH_Quan_Ly_Phieu_Thue_Phong_KVC();
                    mhc.ShowDialog();
                    break;
            }
        }
    }
}
