using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WS_Dich_Vu_Nghiep_Vu.DataServiceRef;

namespace WS_Dich_Vu_Nghiep_Vu
{
    /// <summary>
    /// Summary description for BusinessService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BusinessService : System.Web.Services.WebService
    {
        DataServiceRef.DataServiceSoapClient dssc;
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        #region Thay doi gia phong
        //Thay doi gia phong
        [WebMethod]
        public bool Thay_Doi_Gia_Phong(int _ID, int _Don_Gia_Moi)
        {
            dssc = new DataServiceRef.DataServiceSoapClient();
            //Mặc định ID đúng
            DataServiceRef.CLoaiPhong lpm = new DataServiceRef.CLoaiPhong();
            lpm = Tim_Loai_Phong_Theo_ID(_ID);
            lpm._Don_Gia = _Don_Gia_Moi;
            return dssc.Cap_Nhat_Gia_Loai_Phong(lpm);
        }
        [WebMethod]
        public DataServiceRef.CLoaiPhong Tim_Loai_Phong_Theo_ID(int _ID)
        {
            //Mặc định có loai phòng
            dssc = new DataServiceRef.DataServiceSoapClient();
            DataServiceRef.CLoaiPhong lp = new DataServiceRef.CLoaiPhong();
            //Tải danh sách loại phòng
            DataServiceRef.CLoaiPhong[] list = dssc.Tai_DS_Loai_Phong();
            for (int i = 0; i < list.Length; i++)
            {
                if (_ID == list[i]._ID)
                {
                    lp._ID = list[i]._ID;
                    lp._Ma_So = list[i]._Ma_So;
                    lp._So_Khach_Toi_Da = list[i]._So_Khach_Toi_Da;
                    lp._Ten = list[i]._Ten;
                    lp._Tien_Nghi = list[i]._Tien_Nghi;
                    lp._Don_Gia = list[i]._Don_Gia;
                    break;
                }
            }
            return lp;
        }
        #endregion

        #region Trich rut thong tin doanh thu

        //Doanh thu theo nam
        [WebMethod]
        public double Tinh_Doanh_Thu_Nam(int Nam)
        {
            dssc = new DataServiceRef.DataServiceSoapClient();

            DataServiceRef.CPhieuThuePhong[] dsptp = dssc.Tai_DS_Phieu_Thue();
            double doanhthu = 0;

            for (int i = 0; i < 12; i++)
            {
                doanhthu += Tinh_Doanh_Thu_Thang(i + 1, Nam);
            }

            return doanhthu;
        }
        [WebMethod]
        public double Tinh_Doanh_Thu_Thang(int Thang, int Nam)
        {
            dssc = new DataServiceRef.DataServiceSoapClient();

            DataServiceRef.CPhieuThuePhong[] dsptp = dssc.Tai_DS_Phieu_Thue();
            double doanhthu = 0;
            double[] doanhthutheoloaiphong = Tinh_Doanh_Thu_Loai_Phong(Thang, Nam);
            for (int i = 0; i < 3; i++)
            {
                doanhthu += doanhthutheoloaiphong[i];
            }

            return doanhthu;
        }
        [WebMethod]
        public double[] Tinh_Doanh_Thu_Loai_Phong(int Thang, int Nam)
        {
            dssc = new DataServiceRef.DataServiceSoapClient();

            DataServiceRef.CPhieuThuePhong[] dsptp = dssc.Tai_DS_Phieu_Thue();
            double[] doanhthu = new double[3] { 0, 0, 0 };

            //for (int i = 0; i < 12; i++) doanhthuthang[i] = 0;
            for (int i = 0; i < dsptp.Length; i++)
            {
                if (dsptp[i]._Ngay_Ket_Thuc.Month == Thang)
                {
                    int lp = Tim_Phong_Theo_ID(dsptp[i]._ID_Phong)._ID_Loai_Phong - 1;  //Loai phong
                    doanhthu[lp] += dsptp[i]._Tien_Tra;
                }

            }
            return doanhthu;
        }
        [WebMethod]
        public List<CDoanhThuThang> Tinh_Doanh_Thu(int Nam)
        {
            List<CDoanhThuThang> doanhthu = new List<CDoanhThuThang>();
            for (int i = 0; i < 12; i++)
            {
                CDoanhThuThang temp = new CDoanhThuThang();

                temp._Doanh_Thu_LP1 = temp._Doanh_Thu_LP2 = temp._Doanh_Thu_LP3 = 0;
                doanhthu.Add(temp);
            }

            dssc = new DataServiceRef.DataServiceSoapClient();

            DataServiceRef.CPhieuThuePhong[] dsptp = dssc.Tai_DS_Phieu_Thue();
            for (int i = 0; i < dsptp.Length; i++)
            {
                // DOANHTHU [ THANG , LOAIPHONG ]
                int thang = dsptp[i]._Ngay_Ket_Thuc.Month - 1;
                int loaiphong = Tim_Phong_Theo_ID(dsptp[i]._ID_Phong)._ID_Loai_Phong;
                switch (loaiphong) {
                    case 1:
                        doanhthu[thang]._Doanh_Thu_LP1 += dsptp[i]._Tien_Tra;
                        break;
                    case 2:
                        doanhthu[thang]._Doanh_Thu_LP2 += dsptp[i]._Tien_Tra;
                        break;
                    case 3:
                        doanhthu[thang]._Doanh_Thu_LP3 += dsptp[i]._Tien_Tra;
                        break;
                }
            }
            return doanhthu;
        }
       
        [WebMethod]
        public DataServiceRef.CPhong Tim_Phong_Theo_ID(int _ID)
        {
            DataServiceRef.CPhong p = new DataServiceRef.CPhong();
            //Tai danh sach phong
            dssc = new DataServiceRef.DataServiceSoapClient();
            DataServiceRef.CPhong[] dsp = dssc.Tai_DS_Phong();
            for (int i = 0; i < dsp.Length; i++)
            {
                if (_ID == dsp[i]._ID)
                {
                    p._ID = dsp[i]._ID;
                    p._ID_Loai_Phong = dsp[i]._ID_Loai_Phong;
                    p._ID_Tang = dsp[i]._ID_Tang;
                    p._Ma_So = dsp[i]._Ma_So;
                    p._Ten = dsp[i]._Ten;
                    break;
                }
            }
            return p;
        }
        #endregion
        #region Thong ke tinh trang phong
        public List<CThongTinPhong> Tai_DS_Thong_Tin_Phong(DateTime _Ngay_Hien_Tai)
        {
            dssc = new DataServiceSoapClient();
            List<CThongTinPhong> dsthongtin = new List<CThongTinPhong>();
            CPhong[] dsphong = dssc.Tai_DS_Phong();
            for (int i = 0; i < dsphong.Length; i++)
            {
                CThongTinPhong temp = new CThongTinPhong();
                temp._ID = dsphong[i]._ID;     //id phong
                temp._Ten = dsphong[i]._Ten;   //ten phong
                dsthongtin.Add(temp);
            }

            CPhieuThuePhong[] dsphieuthue = dssc.Tai_DS_Phieu_Thue();
            for (int i = 0; i < dsphieuthue.Length; i++)
            {
                if (dsphieuthue[i]._Ngay_Ket_Thuc.Day == 0) //chua tra phong
                {
                    dsthongtin[dsphieuthue[i]._ID_Phong]._Ngay_Bat_Dau = dsphieuthue[i]._Ngay_Bat_Dau;
                    dsthongtin[dsphieuthue[i]._ID_Phong]._Ngay_Du_Kien_Tra = dsphieuthue[i]._Ngay_Du_Kien_Tra;
                } else
                {

                }
            }

            return dsthongtin;
        }
        #endregion

        #region Tinh tien phong
        public double Tinh_Tien_Phong(int _ID_Phieu_Thue, DateTime _Ngay_Bat_Dau, DateTime _Ngay_Ket_Thuc, int _ID_Loai_Phong)
        {
            //double tienphong = 0;
            //double dongia = 0;
            CLoaiPhong loaiphong = Tim_Loai_Phong_Theo_ID(_ID_Loai_Phong);
            
            return (_Ngay_Ket_Thuc - _Ngay_Bat_Dau).Days * loaiphong._Don_Gia;
        }

        public bool Cap_Nhat_Tra_Phong(int _ID_Phieu_Thue, DateTime _Ngay_Ket_Thuc, double _Tien_Tra)
        {
            CPhieuThuePhong ptp = Tim_Phieu_Thue_Theo_ID(_ID_Phieu_Thue);
            dssc = new DataServiceSoapClient();
            ptp._Tien_Tra = _Tien_Tra;
            ptp._Ngay_Ket_Thuc = _Ngay_Ket_Thuc;
            return dssc.Cap_Nhat_Tra_Phong(ptp);
            //return true;
        }

        public CPhieuThuePhong Tim_Phieu_Thue_Theo_ID(int _ID_Phieu_Thue)
        {
            CPhieuThuePhong ptp = new CPhieuThuePhong();
            //Tai danh sach phieu thue
            dssc = new DataServiceSoapClient();
            CPhieuThuePhong[] dsphieuthue = dssc.Tai_DS_Phieu_Thue();
            for (int i = 0; i < dsphieuthue.Length; i++)
            {
                if (_ID_Phieu_Thue == dsphieuthue[i]._ID)
                {
                    ptp._ID = dsphieuthue[i]._ID;
                    ptp._DS_CMND = dsphieuthue[i]._DS_CMND;
                    ptp._DS_Ho_Ten = dsphieuthue[i]._DS_Ho_Ten;
                    ptp._ID_Phong = dsphieuthue[i]._ID_Phong;
                    ptp._Ngay_Bat_Dau = dsphieuthue[i]._Ngay_Bat_Dau;
                    ptp._Ngay_Du_Kien_Tra = dsphieuthue[i]._Ngay_Du_Kien_Tra;
                    ptp._Ngay_Ket_Thuc = dsphieuthue[i]._Ngay_Ket_Thuc;
                    ptp._Tien_Tra = dsphieuthue[i]._Tien_Tra;
                    break;
                }
            }
            return ptp;
        }

        #endregion
        #region Xu ly dang nhap
        //Kiem tra dang nhap
        //_Loai_Nhan_Vien la QLKS, QLKV hoac TiepTan
        [WebMethod]
        public bool Kiem_Tra_Dang_Nhap(string _Ten_Dang_Nhap, string _Mat_Khau, string _Loai_Nhan_Vien)
        {
            //Tai danh sach tai khoan QLKS
            dssc = new DataServiceSoapClient();
            CTaiKhoan[] dstk = new CTaiKhoan[10];
            switch (_Loai_Nhan_Vien)
            {
                case "QLKS":
                    dstk = dssc.Tai_DS_QLKS();
                    break;
                case "QLKV":
                    dstk = dssc.Tai_DS_QLKV();
                    break;
                case "TiepTan":
                    dstk = dssc.Tai_DS_Tiep_Tan();
                    break;
            }             

            for (int i = 0; i < dstk.Length; i++)
            {
                if (_Ten_Dang_Nhap == dstk[i]._Ten_Dang_Nhap && _Mat_Khau == dstk[i]._Mat_Khau)
                    return true;
            }
            return false;
        }
        #endregion

        #region Thong tin
        //Tải thông tin khách sạn
        [WebMethod]
        public DataServiceRef.CKhachSan Thong_Tin_Khach_San(int _ID)
        {
            //DataServiceRef.CKhachSan ks = new DataServiceRef.CKhachSan();
            dssc = new DataServiceSoapClient();
            CKhachSan[] dsks = dssc.Tai_DS_Khach_San();
            for (int i = 0; i < dsks.Length; i++)
            {
                if (_ID == dsks[i]._ID)
                {
                    return dsks[i];
                }
            }
            return null;    //khong tim thay
        }
        #endregion

    }
}
