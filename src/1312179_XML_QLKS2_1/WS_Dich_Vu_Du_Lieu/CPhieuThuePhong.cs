using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Dich_Vu_Du_Lieu
{
    public class CPhieuThuePhong
    {
        private int ID, ID_Phong;
        private string DS_Ho_Ten, DS_CMND;
        private double Tien_Tra;
        private DateTime Ngay_Bat_Dau, Ngay_Du_Kien_Tra, Ngay_Ket_Thuc;
        //CPhieuThuePhong(int _ID, int _ID_Phong, DateTime _Ngay_Bat_Dau, DateTime _Ngay_Du_Kien_Tra, DateTime _Ngay_Ket_Thuc, double _Tien_Tra, string _DS_Ho_Ten, string _DS_CMND)
        //{
        //    ID = _ID;
        //    ID_Phong = _ID_Phong;
        //    Ngay_Bat_Dau = _Ngay_Bat_Dau;
        //    Ngay_Du_Kien_Tra = _Ngay_Du_Kien_Tra;
        //    Ngay_Ket_Thuc = _Ngay_Ket_Thuc;
        //    Tien_Tra = _Tien_Tra;
        //    DS_Ho_Ten=_DS_Ho_Ten;
        //    DS_CMND=_DS_CMND;

        //}
        public int _ID
        {
            get { return ID; }
            set { ID = value; }
        }
        public DateTime _Ngay_Bat_Dau
        {
            get { return Ngay_Bat_Dau; }
            set { Ngay_Bat_Dau = value; }
        }
        public DateTime _Ngay_Du_Kien_Tra
        {
            get { return Ngay_Du_Kien_Tra; }
            set { Ngay_Du_Kien_Tra = value; }
        }
        public DateTime _Ngay_Ket_Thuc
        {
            get { return Ngay_Ket_Thuc; }
            set { Ngay_Ket_Thuc = value; }
        }
        public double _Tien_Tra
        {
            get { return Tien_Tra; }
            set { Tien_Tra = value; }
        }
        public int _ID_Phong
        {
            get { return ID_Phong; }
            set { ID_Phong = value; }
        }
        public string _DS_Ho_Ten
        {
            get { return DS_Ho_Ten; }
            set { DS_Ho_Ten = value; }
        }
        public string _DS_CMND
        {
            get { return DS_CMND; }
            set { DS_CMND = value; }
        }
    }
}