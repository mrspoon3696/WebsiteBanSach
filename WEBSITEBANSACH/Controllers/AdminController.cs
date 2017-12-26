using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBSITEBANSACH.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;




namespace WEBSITEBANSACH.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        SACHEntities13 db = new SACHEntities13();
        public ActionResult TrangAdmin()
        {

            return View();
        }

        //////////////////////////////////////////KHACH HANG/////////////////////////////////////
        public ActionResult KHACHHANG(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(db.KHACHHANGs.ToList().OrderBy(n => n.MaKH).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult themKH()
        {


            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult themKH(KHACHHANG kh)
        {


            if (ModelState.IsValid)
            {

                db.KHACHHANGs.Add(kh);
                db.SaveChanges();
            }
            return RedirectToAction("KHACHHANG");
        }
        [HttpGet]
        public ActionResult xoaKH(int maKH)
        {
            //lay doi tuong theo mã 
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.MaKH == maKH);
            ViewBag.Masach = kh.MaKH;
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(kh);

        }
        [HttpPost, ActionName("xoaKH")]

        public ActionResult Xacnhankhachhang(int maKH)
        {
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.MaKH == maKH);
            ViewBag.Masach = kh.MaKH;
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.KHACHHANGs.Remove(kh);
            db.SaveChanges();
            return RedirectToAction("KHACHHANG");

        }
        [HttpGet]
        public ActionResult suakh(int makh)
        {
            //lay doi tuong theo mã 
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.MaKH == makh);

            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(kh);

        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult suakh(KHACHHANG qlkh, FormCollection f)
        {

            if (ModelState.IsValid)
            {
                db.Entry(qlkh).State = System.Data.EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("KHACHHANG");

        }
 //thống kê
        public ActionResult thongke()
        {
           
            var model = db.CHITIETSACHes
                .GroupBy(p=> p.CHUDE)
                .Select(g => new baocao
                {
                    Group = g.Key.Tenchude,
                    soluong= (int)(g.Sum(p => p.Soluongton)),
                    dongia = (float)(g.Sum(p => p.Dongia * p.Soluongton)),
                    Min = (float)(g.Min(p => p.Dongia)),
                    Max = (float)(g.Max(p => p.Dongia)),
                    Avg = (int)(g.Average(p => p.Dongia * p.Soluongton))                 
                  
                    
                });
            return View("thongke", model);
           
        }
        //doanh thu thống kê theo chủ đề 

        public ActionResult thongkedoanhthu()
        {
            var model = db.CHITIETDONHANGs
                .GroupBy(d => d.CHITIETSACH.CHUDE)
                .ToList()
                .Select(g => new baocao
                {
                    Group = g.Key.Tenchude,
                    soluong = (int)(g.Sum(p => p.Soluong)),
                    dongia = (double)(g.Sum(p => p.DonGia *p.Soluong)),
                    Min = (double)(g.Min(p => p.DonGia)),
                    Max = (double)(g.Max(p => p.DonGia)),
                    Avg = (int)(g.Average(p => p.DonGia * p.Soluong)) 
                });
            return View("thongkedoanhthu", model);
        }
       

    }




}

