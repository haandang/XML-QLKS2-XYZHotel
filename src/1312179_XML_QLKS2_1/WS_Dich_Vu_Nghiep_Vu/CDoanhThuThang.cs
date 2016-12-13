using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Dich_Vu_Nghiep_Vu
{
    public class CDoanhThuThang
    {
        double Doanh_Thu_LP1, Doanh_Thu_LP2, Doanh_Thu_LP3, Tong_Doanh_Thu_Thang;
        public double _Doanh_Thu_LP1 {
            get { return Doanh_Thu_LP1; }
            set { Doanh_Thu_LP1 = value; }
        }
        public double _Doanh_Thu_LP2
        {
            get { return Doanh_Thu_LP2; }
            set { Doanh_Thu_LP2 = value; }
        }
        public double _Doanh_Thu_LP3
        {
            get { return Doanh_Thu_LP3; }
            set { Doanh_Thu_LP3 = value; }
        }
        public double _Tong_Doanh_Thu_Thang
        {
            get { return _Doanh_Thu_LP1 + _Doanh_Thu_LP2 + _Doanh_Thu_LP3; }
            //set { Doanh_Thu_Thang = value; }
        }

    }
}