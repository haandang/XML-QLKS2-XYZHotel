using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Dich_Vu_Du_Lieu
{
    public class CTang
    {
        private int ID, ID_Khu_Vuc;
        private string Ten, Ma_So;
        //CTang(int _ID, string _Ten, string _Ma_So, int _ID_Khu_Vuc)
        //{
        //    ID = _ID;
        //    Ten = _Ten;
        //    Ma_So = _Ma_So;
        //    ID_Khu_Vuc = _ID_Khu_Vuc;
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
        public int _ID_Khu_Vuc
        {
            get { return ID_Khu_Vuc; }
            set { ID_Khu_Vuc = value; }
        }
    }
}