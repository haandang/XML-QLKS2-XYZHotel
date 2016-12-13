using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Hosting;
using System.IO;
using System.Xml;

namespace WS_Dich_Vu_Du_Lieu
{
    /// <summary>
    /// Summary description for DataService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class DataService : System.Web.Services.WebService
    {
        //static string connection = System.Configuration.ConfigurationSettings.AppSettings["connectString"];
        protected static DirectoryInfo Thu_muc_Project = new DirectoryInfo(HostingEnvironment.ApplicationPhysicalPath);
        //protected static DirectoryInfo Thu_muc_Solution = Thu_muc_Project.Parent;
        protected static DirectoryInfo Thu_muc_Du_lieu = Thu_muc_Project.GetDirectories("DuLieu")[0];
        protected static string connection = Thu_muc_Du_lieu.FullName + @"\" + "CNXML_SV_QLKS_2_Cach_1" + ".xml";
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        #region KhachSan
        //Lấy dữ liệu bảng KHACH_SAN
        [WebMethod]
        public List<CKhachSan> Tai_DS_Khach_San()
        {
            List<CKhachSan> list = new List<CKhachSan>();
            CKhachSan ks;
            XmlDocument file = new XmlDocument();
            file.Load(connection);
            XmlNodeList ksnodelist = file.SelectNodes("/CNXML_SV_QLKS_2_Cach_1/KHACH_SAN");
            for (int i = 0; i < ksnodelist.Count; i++)
            {
                XmlElement node = (XmlElement)ksnodelist[i];
                ks = new CKhachSan();
                ks._ID = int.Parse(node.GetAttribute("ID"));
                ks._Ten = node.GetAttribute("Ten");
                ks._Dia_Chi = node.GetAttribute("Dia_chi");
                ks._Dien_Thoai = node.GetAttribute("Dien_thoai");
                ks._Mail = node.GetAttribute("Mail");
                list.Add(ks);
            }
            return list;
        }
        #endregion

        #region KhuVuc
        //Lấy dữ liệu bảng KHU_VUC
        [WebMethod]
        public List<CKhuVuc> Tai_DS_Khu_Vuc()
        {
            List<CKhuVuc> list = new List<CKhuVuc>();
            CKhuVuc kv;
            XmlDocument file = new XmlDocument();
            file.Load(connection);
            XmlNodeList ksnodelist = file.SelectNodes("/CNXML_SV_QLKS_2_Cach_1/KHU_VUC");
            for (int i = 0; i < ksnodelist.Count; i++)
            {
                XmlElement node = (XmlElement)ksnodelist[i];
                kv = new CKhuVuc();
                kv._ID = int.Parse(node.GetAttribute("ID"));
                kv._Ten = node.GetAttribute("Ten");
                kv._ID_Khach_San = int.Parse(node.GetAttribute("ID_KHACH_SAN"));
                kv._Ma_So = node.GetAttribute("Ma_so");
                list.Add(kv);
            }
            return list;
        }
        #endregion

        #region LoaiPhong
        //Lấy dữ liệu bảng LOAI_PHONG
        [WebMethod]
        public List<CLoaiPhong> Tai_DS_Loai_Phong()
        {
            List<CLoaiPhong> list = new List<CLoaiPhong>();
            CLoaiPhong lp;
            XmlDocument file = new XmlDocument();
            file.Load(connection);
            XmlNodeList ksnodelist = file.SelectNodes("/CNXML_SV_QLKS_2_Cach_1/LOAI_PHONG");
            for (int i = 0; i < ksnodelist.Count; i++)
            {
                XmlElement node = (XmlElement)ksnodelist[i];
                lp = new CLoaiPhong();
                lp._ID = int.Parse(node.GetAttribute("ID"));
                lp._Ten = node.GetAttribute("Ten");
                lp._Ma_So = node.GetAttribute("Ma_so");
                lp._So_Khach_Toi_Da = int.Parse(node.GetAttribute("So_Khach_Toi_da"));
                lp._Tien_Nghi = node.GetAttribute("Tien_nghi");
                lp._Don_Gia = int.Parse(node.GetAttribute("Don_gia"));
                list.Add(lp);
            }
            return list;
        }
        //Thay đổi giá phòng trong bảng LOAI_PHONG
        [WebMethod]
        public bool Cap_Nhat_Gia_Loai_Phong(CLoaiPhong lp)
        {
            XmlDocument file = new XmlDocument();
            file.Load(connection);

            XmlElement restaurant = file.DocumentElement;

            XmlNode oldnode = file.SelectSingleNode("/CNXML_SV_QLKS_2_Cach_1/LOAI_PHONG" + "[@ID ='" + lp._ID + "']");

            XmlElement updatenode = file.CreateElement("LOAI_PHONG");
            updatenode.SetAttribute("ID", lp._ID.ToString());
            updatenode.SetAttribute("Ten", lp._Ten);
            updatenode.SetAttribute("Ma_so", lp._Ma_So);
            updatenode.SetAttribute("Don_gia", lp._Don_Gia.ToString());
            updatenode.SetAttribute("Tien_nghi", lp._Tien_Nghi.ToString());
            updatenode.SetAttribute("So_Khach_Toi_da", lp._So_Khach_Toi_Da.ToString());
            try
            {
                restaurant.ReplaceChild(updatenode, oldnode);
            }
            catch
            {
                return false;
            }

            file.Save(connection);
            return true;
        }
        #endregion

        #region PhieuThue
        //Lấy dữ liệu bảng PHIEU_THUE
        [WebMethod]
        public List<CPhieuThuePhong> Tai_DS_Phieu_Thue()
        {
            List<CPhieuThuePhong> list = new List<CPhieuThuePhong>();
            CPhieuThuePhong ptp;
            XmlDocument file = new XmlDocument();
            file.Load(connection);
            XmlNodeList ksnodelist = file.SelectNodes("/CNXML_SV_QLKS_2_Cach_1/PHIEU_THUE");
            for (int i = 0; i < ksnodelist.Count; i++)
            {
                XmlElement node = (XmlElement)ksnodelist[i];
                ptp = new CPhieuThuePhong();
                ptp._ID = int.Parse(node.GetAttribute("ID"));
                ptp._ID_Phong = int.Parse(node.GetAttribute("ID_PHONG"));
                ptp._Ngay_Bat_Dau = DateTime.Parse(node.GetAttribute("Ngay_Bat_dau"));
                ptp._Ngay_Du_Kien_Tra = DateTime.Parse(node.GetAttribute("Ngay_Du_kien_Tra"));
                ptp._Ngay_Ket_Thuc = DateTime.Parse(node.GetAttribute("Ngay_Ket_thuc"));
                ptp._Tien_Tra = double.Parse(node.GetAttribute("Tien_Tra"));

                list.Add(ptp);
            }
            return list;
        }

        //Trả phòng (Cập nhật dữ liệu): 
        //Thêm dữ liệu Ngay_Ket_Thuc
        //Thêm dữ liệu Tien_Tra
        [WebMethod]
        public bool Cap_Nhat_Tra_Phong(CPhieuThuePhong ptp)
        {
            XmlDocument file = new XmlDocument();
            file.Load(connection);

            XmlElement restaurant = file.DocumentElement;

            XmlNode oldnode = file.SelectSingleNode("/CNXML_SV_QLKS_2_Cach_1/PHIEU_THUE" + "[@ID ='" + ptp._ID + "']");

            XmlElement updatenode = file.CreateElement("PHIEU_THUE");
            updatenode.SetAttribute("ID", ptp._ID.ToString());
            updatenode.SetAttribute("ID_PHONG", ptp._ID_Phong.ToString());
            updatenode.SetAttribute("Ngay_Bat_dau", ptp._Ngay_Bat_Dau.ToString());
            updatenode.SetAttribute("Ngay_Du_kien_Tra", ptp._Ngay_Du_Kien_Tra.ToString());
            updatenode.SetAttribute("Ngay_Ket_thuc", ptp._Ngay_Ket_Thuc.ToString());
            updatenode.SetAttribute("Tien_Tra", ptp._Tien_Tra.ToString());
            try
            {
                restaurant.ReplaceChild(updatenode, oldnode);
            }
            catch
            {
                return false;
            }

            file.Save(connection);
            return true;
        }

        //Thuê phòng mới (Tạo mới dữ liệu)
        [WebMethod]
        public bool Them_Phieu_Thue_Phong(CPhieuThuePhong ptp)
        {
            XmlDocument file = new XmlDocument();
            file.Load(connection);

            XmlElement doc = file.DocumentElement;   //CNXML_SV_QLKS_2_Cach_1
            XmlElement ptpnode = file.CreateElement("");
            //ptpnode.SetAttribute("ID", ptp._ID.ToString());
            //Tự phát sinh ID
            ptpnode.SetAttribute("ID", Phat_Sinh_ID_Phieu_Thue().ToString());
            ptpnode.SetAttribute("ID_PHONG", ptp._ID_Phong.ToString());
            ptpnode.SetAttribute("Ngay_Bat_dau", ptp._Ngay_Bat_Dau.ToString());
            ptpnode.SetAttribute("Ngay_Du_kien_Tra", ptp._Ngay_Du_Kien_Tra.ToString());
            ptpnode.SetAttribute("Ngay_Ket_thuc", ptp._Ngay_Ket_Thuc.ToString());
            ptpnode.SetAttribute("Tien_Tra", ptp._Tien_Tra.ToString());
            try
            {
                doc.AppendChild(ptpnode);
            }
            catch
            {
                return false;
            }

            file.Save(connection);
            return true;

        }

        //Hàm phát sinh ID cho một phiếu thuê mới được khởi tạo
        public int Phat_Sinh_ID_Phieu_Thue()
        {
            List<CPhong> list = new List<CPhong>();
            XmlDocument file = new XmlDocument();
            file.Load(connection);
            XmlNodeList ksnodelist = file.SelectNodes("/CNXML_SV_QLKS_2_Cach_1/PHIEU_THUE");
            XmlElement node = (XmlElement)ksnodelist[ksnodelist.Count - 1];
            return int.Parse(node.GetAttribute("ID")) + 1;
        }
        #endregion

        #region Phong
        //Lấy dữ liệu bảng PHONG
        [WebMethod]
        public List<CPhong> Tai_DS_Phong()
        {
            List<CPhong> list = new List<CPhong>();
            CPhong p;
            XmlDocument file = new XmlDocument();
            file.Load(connection);
            XmlNodeList ksnodelist = file.SelectNodes("/CNXML_SV_QLKS_2_Cach_1/PHONG");
            for (int i = 0; i < ksnodelist.Count; i++)
            {
                XmlElement node = (XmlElement)ksnodelist[i];
                p = new CPhong();
                p._ID = int.Parse(node.GetAttribute("ID"));
                p._Ten = node.GetAttribute("Ten");
                p._Ma_So = node.GetAttribute("Ma_so");
                p._ID_Loai_Phong = int.Parse(node.GetAttribute("ID_LOAI_PHONG"));
                p._ID_Tang = int.Parse(node.GetAttribute("ID_TANG"));
                list.Add(p);
            }
            return list;
        }
        #endregion

        #region QLKS
        //Lấy dữ liệu bảng QLKS (Tài khoản)
        [WebMethod]
        public List<CTaiKhoan> Tai_DS_QLKS()
        {
            List<CTaiKhoan> list = new List<CTaiKhoan>();
            CTaiKhoan qlks;
            XmlDocument file = new XmlDocument();
            file.Load(connection);
            XmlNodeList ksnodelist = file.SelectNodes("/CNXML_SV_QLKS_2_Cach_1/QLKS");
            for (int i = 0; i < ksnodelist.Count; i++)
            {
                XmlElement node = (XmlElement)ksnodelist[i];
                qlks = new CTaiKhoan();
                qlks._ID = int.Parse(node.GetAttribute("ID"));
                qlks._Ten_Dang_Nhap = node.GetAttribute("Ten_Dang_nhap");
                qlks._Mat_Khau = node.GetAttribute("Mat_khau");
                qlks._Cap_Quan_Ly = node.GetAttribute("ID_KHACH_SAN");

                list.Add(qlks);
            }
            return list;
        }
        #endregion

        #region QLKV
        //Lấy dữ liệu bảng QLKV (Tài khoản)
        [WebMethod]
        public List<CTaiKhoan> Tai_DS_QLKV()
        {
            List<CTaiKhoan> list = new List<CTaiKhoan>();
            CTaiKhoan qlkv;
            XmlDocument file = new XmlDocument();
            file.Load(connection);
            XmlNodeList ksnodelist = file.SelectNodes("/CNXML_SV_QLKS_2_Cach_1/QLKV");
            for (int i = 0; i < ksnodelist.Count; i++)
            {
                XmlElement node = (XmlElement)ksnodelist[i];
                qlkv = new CTaiKhoan();
                qlkv._ID = int.Parse(node.GetAttribute("ID"));
                qlkv._Ten_Dang_Nhap = node.GetAttribute("Ten_Dang_nhap");
                qlkv._Mat_Khau = node.GetAttribute("Mat_khau");
                qlkv._Cap_Quan_Ly = node.GetAttribute("DS_ID_KHU_VUC");

                list.Add(qlkv);
            }
            return list;
        }
        #endregion

        #region Tang
        //Lấy dữ liệu bảng TANG
        [WebMethod]
        public List<CTang> Tai_DS_Tang()
        {
            List<CTang> list = new List<CTang>();
            CTang t;
            XmlDocument file = new XmlDocument();
            file.Load(connection);
            XmlNodeList ksnodelist = file.SelectNodes("/CNXML_SV_QLKS_2_Cach_1/TANG");
            for (int i = 0; i < ksnodelist.Count; i++)
            {
                XmlElement node = (XmlElement)ksnodelist[i];
                t = new CTang();
                t._ID = int.Parse(node.GetAttribute("ID"));
                t._Ten = node.GetAttribute("Ten");
                t._Ma_So = node.GetAttribute("Ma_so");
                t._ID_Khu_Vuc = int.Parse(node.GetAttribute("Dien_thoai"));
                list.Add(t);
            }
            return list;
        }
        #endregion

        #region TiepTan
        //Lấy dữ liệu bảng TIEP_TAN (Tài khoản)
        [WebMethod]
        public List<CTaiKhoan> Tai_DS_Tiep_Tan()
        {
            List<CTaiKhoan> list = new List<CTaiKhoan>();
            CTaiKhoan tt;
            XmlDocument file = new XmlDocument();
            file.Load(connection);
            XmlNodeList ksnodelist = file.SelectNodes("/CNXML_SV_QLKS_2_Cach_1/TIEP_TAN");
            for (int i = 0; i < ksnodelist.Count; i++)
            {
                XmlElement node = (XmlElement)ksnodelist[i];
                tt = new CTaiKhoan();
                tt._ID = int.Parse(node.GetAttribute("ID"));
                tt._Ten_Dang_Nhap = node.GetAttribute("Ten_Dang_nhap");
                tt._Mat_Khau = node.GetAttribute("Mat_khau");
                tt._Cap_Quan_Ly = node.GetAttribute("ID_KHU_VUC");

                list.Add(tt);
            }
            return list;
        }
        #endregion


    }
}
