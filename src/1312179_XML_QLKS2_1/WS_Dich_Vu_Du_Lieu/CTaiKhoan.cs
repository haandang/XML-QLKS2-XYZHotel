using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Dich_Vu_Du_Lieu
{
    public class CTaiKhoan
    {
        private int ID;
        private string Ten_Dang_Nhap, Mat_Khau, Cap_Quan_Ly;
        //CTaiKhoan(int _ID, string _Ten_Dang_Nhap, string _Mat_Khau, string _Cap_Quan_Ly)
        //{
        //    ID = _ID;
        //    Ten_Dang_Nhap = _Ten_Dang_Nhap;
        //    Mat_Khau = _Mat_Khau;
        //    Cap_Quan_Ly = _Cap_Quan_Ly;
        //}
        public int _ID
        {
            get { return ID; }
            set { ID = value; }
        }
        public string _Ten_Dang_Nhap
        {
            get { return Ten_Dang_Nhap; }
            set { Ten_Dang_Nhap = value; }
        }
        public string _Mat_Khau
        {
            get { return Mat_Khau; }
            set { Mat_Khau = value; }
        }
        public string _Cap_Quan_Ly
        {
            get { return Cap_Quan_Ly; }
            set { Cap_Quan_Ly = value; }
        }
    }
}