using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Dich_Vu_Du_Lieu
{
    public class CKhuVuc
    {
        private int ID, ID_Khach_San;
        private string Ten, Ma_So;
        //CKhuVuc(int _ID, string _Ten, string _Ma_So, int _ID_Khach_San)
        //{
        //    ID = _ID;
        //    Ten = _Ten;
        //    Ma_So = _Ma_So;
        //    ID_Khach_San = _ID_Khach_San;
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
        public int _ID_Khach_San
        {
            get { return ID_Khach_San; }
            set { ID_Khach_San = value; }
        }
    }
}