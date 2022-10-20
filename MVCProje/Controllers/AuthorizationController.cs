using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class AuthorizationController : Controller
    {
        AdminManager _adminmanager = new AdminManager(new EFAdminDal());
        public ActionResult Index()
        {
            var adminValues = _adminmanager.GetList();
            return View(adminValues);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();

        }

        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            _adminmanager.AdminAdd(p);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var AdminValue = _adminmanager.GeyByID(id);


            return View(AdminValue);

        }


        [HttpPost]
        public ActionResult EditAdmin(Admin admin)
        {



            _adminmanager.AdminUpdate(admin);
            return RedirectToAction("Index");

        }
    }
}