using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Dich_Vu_Nghiep_Vu
{
    public class CThongTinPhong
    {
        //DataServiceRef.CPhong Phong;
        int ID;
        string Ten, DS_Khach_Hang, DS_CMND;
        DateTime Ngay_Bat_Dau, Ngay_Ket_Thuc, Ngay_Du_Kien_Tra;
        double Tien_Tra;

        public int _ID
        {
            get { return ID; }
            set { ID = value; }
        }
        public string _Ten
        {
            get { return Ten; }
            set { Ten = value; }
        }
        public string _DS_Khach_Hang
        {
            get { return DS_Khach_Hang; }
            set { DS_Khach_Hang = value; }
        }
        public string _DS_CMND
        {
            get { return DS_CMND; }
            set { DS_CMND = value; }
        }
        public DateTime _Ngay_Bat_Dau
        {
            get { return Ngay_Bat_Dau; }
            set { Ngay_Bat_Dau = value; }
        }
        public DateTime _Ngay_Ket_Thuc
        {
            get { return Ngay_Ket_Thuc; }
            set { Ngay_Ket_Thuc = value; }
        }
        public DateTime _Ngay_Du_Kien_Tra
        {
            get { return Ngay_Du_Kien_Tra; }
            set { Ngay_Du_Kien_Tra = value; }
        }
    }
}