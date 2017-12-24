using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBSITEBANSACH.Models;
using PagedList;
using PagedList.Mvc;
namespace WEBSITEBANSACH.Controllers
{
    public class HomeController : Controller
    {
        SACHEntities13 db = new SACHEntities13();
      // 
        private List<CHITIETSACH> sachmoi(int count)
        {
            return db.CHITIETSACHes.OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();

        }
        public ActionResult WebsiteBanSach(int? page)
        {
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            var moi = sachmoi(54);
            return View(moi.ToPagedList(pageNumber, pageSize));

        }
        public ActionResult KhuyenMai()
        {
            
            return View(db.CHITIETSACHes.Where(n => n.khuyenmai == true).ToList());
        }
        public ActionResult giaohang()
        {
            
            return View();

        }



   
     
    }
}