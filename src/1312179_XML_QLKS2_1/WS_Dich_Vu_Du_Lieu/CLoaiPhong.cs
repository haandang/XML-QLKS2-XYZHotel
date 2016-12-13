using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Dich_Vu_Du_Lieu
{
    public class CLoaiPhong
    {
        private int ID, So_Khach_Toi_Da, Don_Gia;
        private string Ten, Ma_So, Tien_Nghi;
        //CLoaiPhong(int _ID, string _Ten, string _Ma_So, string _Tien_Nghi, int _Don_Gia, int _So_Khach_Toi_Da)
        //{
        //    ID = _ID;
        //    Ten = _Ten;
        //    Ma_So = _Ma_So;
        //    Tien_Nghi = _Tien_Nghi;
        //    Don_Gia = _Don_Gia;
        //    So_Khach_Toi_Da = _So_Khach_Toi_Da;
        //}
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
        public string _Ma_So
        {
            get { return Ma_So; }
            set { Ma_So = value; }
        }
        public int _Don_Gia
        {
            get { return Don_Gia; }
            set { Don_Gia = value; }
        }
        public string _Tien_Nghi
        {
            get { return Tien_Nghi; }
            set { Tien_Nghi = value; }
        }
        public int _So_Khach_Toi_Da
        {
            get { return So_Khach_Toi_Da; }
            set { So_Khach_Toi_Da = value; }
        }
    }
}