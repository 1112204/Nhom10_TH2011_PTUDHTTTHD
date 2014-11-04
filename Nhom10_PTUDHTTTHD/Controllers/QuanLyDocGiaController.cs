using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom10_PTUDHTTTHD.Models;
using OnBarcode.Barcode.ASPNET;

namespace Nhom10_PTUDHTTTHD.Controllers
{
    public class QuanLyDocGiaController : Controller
    {
        private QuanLyThuVienEntities db = new QuanLyThuVienEntities();

        /// <summary>
        /// Thống kê thông tin đọc giả theo nhiều tiêu chí khác nhau
        ///      - theo loại: sinh viên, nghiên cứu sinh, giáo viên
        ///      - theo độ tuổi
        ///      - theo giới tính
        /// </summary>
        /// <returns></returns>
        public ActionResult ThongKeDocGia()
        {
            return View();
        }

        /// <summary>
        /// Xem danh sách của các đọc giả trong hệ thống
        ///     *** Có thực hiện phân trang
        ///     *** Trong danh sách, mỗi dòng sẽ có 1 cái link dẫn tới action xem danh sách hình của đọc giả
        ///     *** Tham khảo: Apress.Pro.ASP.NET.MVC.4.Framework.Jan.2013 trang 178
        /// </summary>
        /// <param name="page">page: trang hiện tại</param>
        /// <returns></returns>
        public ActionResult XemDanhSachDocGia(int page = 0)
        {
            return View();
        }

        /// <summary>
        /// Xem danh sách hình của đọc giả nào đó
        /// </summary>
        /// <param name="ma_doc_gia">ma_doc_gia: mã của đọc giả cần xem danh sách hình</param>
        /// <returns></returns>
        public ActionResult XemDanhSachHinhDocGia(int id_doc_gia)
        {
            return View();
        }

        /// <summary>
        /// Thêm hình của đọc giả từ màn hình xem danh sách
        ///     *** bổ sung các tham số cho phương thức
        /// </summary>
        /// <returns>trả về màn hình xem danh sách hình đọc giả</returns>
        public ActionResult ThemHinhDocGia(int id_doc_gia, int ma_hinh)
        {
            return View();
        }

        /// <summary>
        /// Xóa hình của đọc giả từ màn hình xem danh sách
        ///     *** bổ sung các tham số cho phương thức
        /// </summary>
        /// <returns>trả về màn hình xem danh sách hình đọc giả</returns>
        public ActionResult XoaHinhDocGia(int id_doc_gia, int ma_hinh)
        {
            return View();
        }

        /// <summary>
        /// Phát sinh mã vạch, mã số thẻ cho đọc giả
        /// </summary>
        /// <returns></returns>
        public ActionResult PhatSinhMaVach()
        {
            return View();
        }

        //AjaxAction
        public string GetBarcode(string id_doc_gia)
        {
            string fname = id_doc_gia + ".png";
            string path = AppDomain.CurrentDomain.BaseDirectory + "temp/" + fname;
            string bar_code = id_doc_gia;
            string bar_code_url = "/temp/" + fname;
            OnBarcode.Barcode.Linear barcode = new OnBarcode.Barcode.Linear();
            barcode.Type = OnBarcode.Barcode.BarcodeType.CODE39;
            barcode.Data = id_doc_gia;
            barcode.drawBarcode(path);
            return "<form action='SaveBarcode' method='post'><input type='hidden' name='id_doc_gia' value='" + id_doc_gia + "'/><label>Mã thẻ</label><br /><input type='text' name='bar_code' value='" + bar_code + "'/><br /><br /><label>Mã vạch:</label><br /><input type='hidden' name='bar_code_url' value='" + bar_code_url + "'/><img src='" + bar_code_url + "' /><br /><br /><input type='submit' value='Lưu'/></form>";
        }

        public ActionResult SaveBarcode(string id_doc_gia, string bar_code, string bar_code_url)
        {
            int id = Int32.Parse(id_doc_gia);
            QuanLyThuVienEntities data = new QuanLyThuVienEntities();
            DocGia dg = (   from d in data.DocGias
                            where d.id_doc_gia == id
                            select d).First();
            dg.bar_code = bar_code;
            dg.bar_code_url = bar_code_url;
            data.SaveChanges();
            return RedirectToAction("PhatSinhMaVach");                      
        }
    }
}
