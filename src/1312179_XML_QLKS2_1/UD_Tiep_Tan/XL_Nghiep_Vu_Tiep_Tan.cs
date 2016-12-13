using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UD_Tiep_Tan.BusinessServiceRef;
namespace UD_Tiep_Tan
{
    public class XL_Nghiep_Vu_Tiep_Tan
    {
        BusinessServiceSoapClient bssc = new BusinessServiceSoapClient();

        
       
                

        

        #region Xu ly dang nhap
        //Kiem tra dang nhap
        public int Kiem_Tra_Dang_Nhap(string _Ten_Dang_Nhap, string _Mat_Khau)
        {
            //Tai danh sach tai khoan QLKS
            bssc = new BusinessServiceSoapClient();
            //switch _te
            if (bssc.Kiem_Tra_Dang_Nhap(_Ten_Dang_Nhap, _Mat_Khau, "TiepTan"))
            {
                if (_Ten_Dang_Nhap == "TT_1") return 1;
                if (_Ten_Dang_Nhap == "TT_2") return 2;
                if (_Ten_Dang_Nhap == "TT_3") return 3;
            }
            return 0;
        }
        #endregion

       
    }
}
