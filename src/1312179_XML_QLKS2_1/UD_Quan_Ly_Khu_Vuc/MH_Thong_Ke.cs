using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UD_Quan_Ly_Khu_Vuc
{
    public partial class MH_Thong_Ke : Form
    {
        BusinessServiceRef.CDoanhThuThang[] Doanh_Thu;
        int Nam_Thong_Ke = DateTime.Now.Year;  //lấy năm của thời gian hiện tại
        int Thang_Thong_Ke = DateTime.Now.Month - 1;   //Thang hien tai
        //int ID_KS_Chieu_Ha_Vang = 1;
        protected XL_Nghiep_Vu_QLKV NghiepVu = new XL_Nghiep_Vu_QLKV();
        public MH_Thong_Ke()
        {
            InitializeComponent();
            Doanh_Thu = NghiepVu.Tinh_Doanh_Thu(Nam_Thong_Ke);
            Hien_Thi_Thong_Ke(Thang_Thong_Ke, Nam_Thong_Ke);
        }
        private void Hien_Thi_Thong_Ke(int _Thang, int _Nam)
        {
            double Doanh_Thu_Thang = NghiepVu.Doanh_Thu_Thang(Doanh_Thu, _Thang);
            double Doanh_Thu_Nam = NghiepVu.Doanh_Thu_Nam(Doanh_Thu);
            lb_Nam_Thong_Ke.Text = "Năm " + _Nam.ToString();
            lb_Tong_Thu_Nam_Thong_Ke.Text = "Tổng thu: " + String.Format("{0:0,0}", Doanh_Thu_Nam);

            lb_Thang_Thong_Ke.Text = "Tháng " + _Thang.ToString();
            lb_Tong_Thu_Thang_Thong_Ke.Text = "Tổng thu: " + String.Format("{0:0,0}", Doanh_Thu_Thang);
            lb_Ti_Le_Thang.Text = "Tỉ lệ :" + Math.Round(Doanh_Thu_Thang / Doanh_Thu_Nam * 100, 1) + "%";

            lb_Tong_Thu_LP1.Text = "Tổng thu: " + String.Format("{0:0,0}", Doanh_Thu[_Thang - 1]._Doanh_Thu_LP1);
            lb_Ti_Le_LP1.Text = "Tỉ lệ: " + Math.Round(Doanh_Thu[_Thang - 1]._Doanh_Thu_LP1 / Doanh_Thu_Nam * 100, 1) + "%";
            lb_Tong_Thu_LP2.Text = "Tổng thu: " + String.Format("{0:0,0}", Doanh_Thu[_Thang - 1]._Doanh_Thu_LP2);
            lb_Ti_Le_LP2.Text = "Tỉ lệ: " + Math.Round(Doanh_Thu[_Thang - 1]._Doanh_Thu_LP2 / Doanh_Thu_Nam * 100, 1) + "%";
            lb_Tong_Thu_LP3.Text = "Tổng thu: " + String.Format("{0:0,0}", Doanh_Thu[_Thang - 1]._Doanh_Thu_LP3);
            lb_Ti_Le_LP3.Text = "Tỉ lệ: " + Math.Round(Doanh_Thu[_Thang - 1]._Doanh_Thu_LP3 / Doanh_Thu_Nam * 100, 1) + "%";

            btn_Thang01.BackColor = Control.DefaultBackColor;
            btn_Thang02.BackColor = Control.DefaultBackColor;
            btn_Thang03.BackColor = Control.DefaultBackColor;
            btn_Thang04.BackColor = Control.DefaultBackColor;
            btn_Thang05.BackColor = Control.DefaultBackColor;
            btn_Thang06.BackColor = Control.DefaultBackColor;
            btn_Thang07.BackColor = Control.DefaultBackColor;
            btn_Thang08.BackColor = Control.DefaultBackColor;
            btn_Thang09.BackColor = Control.DefaultBackColor;
            btn_Thang10.BackColor = Control.DefaultBackColor;
            btn_Thang11.BackColor = Control.DefaultBackColor;
            btn_Thang12.BackColor = Control.DefaultBackColor;
            switch (Thang_Thong_Ke)
            {
                case 1: btn_Thang01.BackColor = Color.LightSkyBlue; break;
                case 2: btn_Thang02.BackColor = Color.LightSkyBlue; break;
                case 3: btn_Thang03.BackColor = Color.LightSkyBlue; break;
                case 4: btn_Thang04.BackColor = Color.LightSkyBlue; break;
                case 5: btn_Thang05.BackColor = Color.LightSkyBlue; break;
                case 6: btn_Thang06.BackColor = Color.LightSkyBlue; break;
                case 7: btn_Thang07.BackColor = Color.LightSkyBlue; break;
                case 8: btn_Thang08.BackColor = Color.LightSkyBlue; break;
                case 9: btn_Thang09.BackColor = Color.LightSkyBlue; break;
                case 10: btn_Thang10.BackColor = Color.LightSkyBlue; break;
                case 11: btn_Thang11.BackColor = Color.LightSkyBlue; break;
                case 12: btn_Thang12.BackColor = Color.LightSkyBlue; break;
            }
        }
        private void btn_Nam2016_Click(object sender, EventArgs e)
        {
            Nam_Thong_Ke = 2016;
            Thang_Thong_Ke = DateTime.Now.Month - 1;
            Doanh_Thu = NghiepVu.Tinh_Doanh_Thu(Nam_Thong_Ke);
            Hien_Thi_Thong_Ke(Thang_Thong_Ke, Nam_Thong_Ke);
        }

        private void btn_Nam2015_Click(object sender, EventArgs e)
        {
            Nam_Thong_Ke = 2015;
            //Doanh_Thu=NghiepVu.Tinh_Doanh_Thu(Nam_Thong_Ke);
            //if (NghiepVu.Doanh_Thu_Nam(Doanh_Thu) == 0) MessageBox.Show("Không có dữ liệu.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("Không có dữ liệu.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
        private void btn_Dang_Xuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_ThongKeThang_Click(object sender, EventArgs e)
        {
            Thang_Thong_Ke = int.Parse(((Button)sender).Name.Substring(9, 2));
            //MessageBox.Show(Thang.ToString());
            if (NghiepVu.Doanh_Thu_Thang(Doanh_Thu, Thang_Thong_Ke) == 0)
            {
                MessageBox.Show("Không có dữ liệu.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                
                Hien_Thi_Thong_Ke(Thang_Thong_Ke, Nam_Thong_Ke);
                
            }
        }

        private void btn_Tim_Kiem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng đang được phát triển.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Thong_Ke_Click(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.LightSkyBlue;
        }

        private void btn_Dang_Xuat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}