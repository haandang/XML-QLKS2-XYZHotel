using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Dich_Vu_Du_Lieu
{
    public class CPhong
    {
        private int ID, ID_Loai_Phong, ID_Tang;
        private string Ten, Ma_So;
        //CPhong(int _ID, string _Ten, string _Ma_So, int _ID_Loai_Phong, int _ID_Tang)
        //{
        //    ID = _ID;
        //    Ten = _Ten;
        //    Ma_So = _Ma_So;
        //    ID_Loai_Phong = _ID_Loai_Phong;
        //    ID_Tang = _ID_Tang;
           
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
        public int _ID_Loai_Phong
        {
            get { return ID_Loai_Phong; }
            set { ID_Loai_Phong = value; }
        }
        public int _ID_Tang
        {
            get { return ID_Tang; }
            set { ID_Tang = value; }
        }
    }
}