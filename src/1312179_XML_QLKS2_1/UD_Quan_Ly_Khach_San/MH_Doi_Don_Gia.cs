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
    public partial class MH_Doi_Don_Gia : Form
    {
        XL_Nghiep_Vu_QLKS Nghiep_Vu = new XL_Nghiep_Vu_QLKS();
        public MH_Doi_Don_Gia()
        {
            InitializeComponent();
            LP_Click(btn_LP1, null);
            btn_Doi_Don_Gia.BackColor = Color.LightSkyBlue;
        }
        public void LP_Click(object sender, EventArgs e)
        {
            btn_LP1.BackColor = Control.DefaultBackColor;
            btn_LP2.BackColor = Control.DefaultBackColor;
            btn_LP3.BackColor = Control.DefaultBackColor;
            ((Button)sender).BackColor = Color.LightSkyBlue;
            BusinessServiceRef.CLoaiPhong loaiphong = Nghiep_Vu.Tim_Loai_Phong_Theo_ID(int.Parse(((Button)sender).Name.Substring(6,1)));
            lb_Loai_Phong.Text = loaiphong._Ten;
            lb_Ma_So_LP.Text = loaiphong._Ma_So;
            lb_So_Khach_Toi_Da.Text = loaiphong._So_Khach_Toi_Da.ToString();
            lb_Tien_Nghi_LP.Text = loaiphong._Tien_Nghi;
            tbx_Don_Gia.Text = loaiphong._Don_Gia.ToString();
        }
        private void btn_Doi_Don_Gia_Moi_Click(object sender, EventArgs e)
        {
            Nghiep_Vu.Thay_Doi_Gia_Phong(int.Parse(lb_Ma_So_LP.Text.Substring(3, 1)), int.Parse(tbx_Don_Gia.Text));
        }

        private void btn_Thong_Ke_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Doi_Don_Gia_Click(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.LightSkyBlue;

        }
    }
}
