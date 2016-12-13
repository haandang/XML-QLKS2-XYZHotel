using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Dich_Vu_Du_Lieu
{
    public class CKhachSan
    {
        private int ID;
        private string Ten, Dien_Thoai, Mail, Dia_Chi;
        //CKhachSan(int _ID, string _Ten, string _Dien_Thoai, string _Mail, string _Dia_Chi)
        //{
        //    ID = _ID;
        //    Ten = _Ten;
        //    Dien_Thoai = _Dien_Thoai;
        //    Mail = _Mail;
        //    Dia_Chi = _Dia_Chi;
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
        public string _Dien_Thoai
        {
            get { return Dien_Thoai; }
            set { Dien_Thoai= value; }
        }
        public string _Mail
        {
            get { return Mail; }
            set { Mail = value; }
        }
        public string _Dia_Chi
        {
            get { return Dia_Chi; }
            set { Dia_Chi = value; }
        }
    }
}