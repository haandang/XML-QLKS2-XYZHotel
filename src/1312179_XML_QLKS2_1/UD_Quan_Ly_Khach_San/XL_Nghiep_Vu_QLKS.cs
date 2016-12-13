using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UD_Quan_Ly_Khach_San.BusinessServiceRef;

namespace UD_Quan_Ly_Khach_San
{
    public class XL_Nghiep_Vu_QLKS
    {
        BusinessServiceRef.BusinessServiceSoapClient bssc = new BusinessServiceRef.BusinessServiceSoapClient();
        
        //DataServiceRef.DataServiceSoapClient dssc = new DataServiceRef.DataServiceSoapClient();

        #region Thay doi gia phong
        //Thay doi gia phong
        public bool Thay_Doi_Gia_Phong(int _ID, int _Don_Gia_Moi)
        {
            bssc = new BusinessServiceRef.BusinessServiceSoapClient();
            //Mặc định ID đúng
            return bssc.Thay_Doi_Gia_Phong(_ID, _Don_Gia_Moi);
        }

        #endregion

        #region Trich rut thong tin doanh thu
        public CDoanhThuThang[] Tinh_Doanh_Thu(int _Nam)
        {
            bssc = new BusinessServiceSoapClient();
            return bssc.Tinh_Doanh_Thu(_Nam);
        }
        public double Doanh_Thu_Thang(CDoanhThuThang[] _Doanh_Thu, int _Thang)
        {
            return _Doanh_Thu[_Thang-1]._Doanh_Thu_LP1 + _Doanh_Thu[_Thang-1]._Doanh_Thu_LP2 + _Doanh_Thu[_Thang-1]._Doanh_Thu_LP3;
        }
        public double Doanh_Thu_Nam(CDoanhThuThang[] _Doanh_Thu)
        {
            double doanhthu = 0;
            for (int i = 0; i < 12; i++)
            {
                doanhthu+=Doanh_Thu_Thang(_Doanh_Thu, i+1);
            }
            return doanhthu;
        }


        #endregion

        public CLoaiPhong Tim_Loai_Phong_Theo_ID(int _ID_Loai_Phong)
        {
            bssc = new BusinessServiceSoapClient();
            return bssc.Tim_Loai_Phong_Theo_ID(_ID_Loai_Phong);
        }

        #region Xu ly dang nhap
        //Kiem tra dang nhap
        public bool Kiem_Tra_Dang_Nhap(string _Ten_Dang_Nhap, string _Mat_Khau)
        {
            //Tai danh sach tai khoan QLKS
            bssc = new BusinessServiceRef.BusinessServiceSoapClient();
            
            return bssc.Kiem_Tra_Dang_Nhap(_Ten_Dang_Nhap,_Mat_Khau,"QLKS");
        }
        #endregion
    }
}
