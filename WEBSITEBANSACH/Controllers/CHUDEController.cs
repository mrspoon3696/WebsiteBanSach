using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBSITEBANSACH.Models;
namespace WEBSITEBANSACH.Controllers
{
    public class CHUDEController : Controller
    {
        //123
        // GET: /CHUDE/
        //xong roi nha tui sua lai ma chi tiet voi ma sach la int het nha uk  nên code luu ý y chang thầy
        //bam vo xem gio hang de xem gio 

        SACHEntities13 db = new SACHEntities13();
        public PartialViewResult CHUDEpartial()
        {
            var theloai = db.CHUDEs.ToList();
            return PartialView(theloai);
        }
        public ActionResult SPTHEOCHUDE(int id)
        {
            var sach = from s in db.CHITIETSACHes where  s.MACHUDE == id select s;
            return View(sach);
        }
	}
}