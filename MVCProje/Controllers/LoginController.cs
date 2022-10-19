using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCProje.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

       
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)

        {
            Context c = new Context();
            var adminUserInfo = c.Admin.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);


            if(adminUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName, false);
                Session["AdminUserName"] =adminUserInfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }else
            {
                return RedirectToAction("Index");

            }
           
        }


        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            Context c = new Context();
            var WriterUserInfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);


            if (WriterUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(WriterUserInfo.WriterMail, false);
                Session["WriterMail"] = WriterUserInfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");

            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
       
    }
}