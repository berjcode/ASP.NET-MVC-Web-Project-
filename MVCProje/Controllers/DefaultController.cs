using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager _Hm = new HeadingManager(new EFHeadingDal());
        ContentManager _Cm = new ContentManager(new EFContentDal());

        public ActionResult Headings()
        {
            var headingList = _Hm.GetList();
            return View(headingList);
        }
        public PartialViewResult Index(int id =0)
        {
            var contentList = _Cm.GetListByHeadingId(id);
            return PartialView(contentList);
        }
    }
}