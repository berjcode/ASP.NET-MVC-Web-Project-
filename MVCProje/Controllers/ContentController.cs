using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class ContentController : Controller
    {


        ContentManager cm= new ContentManager(new EFContentDal());
        Context c = new Context();
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }


        [AllowAnonymous]
        public ActionResult GetAllContent(string p)
        {
            var values = from x in c.Contents select x;
            if(!string.IsNullOrEmpty(p))
            {
                values = values.Where(y => y.ContentValue.Contains(p));
            }
         //   var values = c.Contents.ToList();
            return View(values.ToList());
        }
        public ActionResult ContentByHeading(int id )
        {
            var contentValues = cm.GetListByHeadingId(id);

            return View(contentValues);
        }
    }
}