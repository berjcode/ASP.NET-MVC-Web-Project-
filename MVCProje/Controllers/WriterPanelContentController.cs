using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVCProje.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EFContentDal());

        Context c = new Context();
        public ActionResult MyContent(string p)
        {

          
            

           p = (string)Session["WriterMail"];
            ViewBag.p = p;
            //var writerInfo =2;
            var writerInfo=c.Writers.Where(x=> x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
      
            var contentValues = cm.GetListByWriter(writerInfo);

            return View(contentValues);
        }


        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content p)
        {
           string mail = (string)Session["WriterMail"];
            p.ContentDate = DateTime.Parse(DateTime.Now.ToLongDateString());
            var writerInfo = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();
            var contentValues = cm.GetListByWriter(writerInfo);
            p.WriterID = writerInfo;
            p.ContentStatus = true;
            cm.ContentAdd(p);
            return RedirectToAction("MyContent");
        }



        public ActionResult ToDoList()
        {
            return View();
        }
    }
}