using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class ContactController : Controller
    {
        ContactManager _contactManager = new ContactManager(new EFContactDal());
        ContactValidator  _cv= new ContactValidator();
        public ActionResult Index()
        {
            var contactValues =_contactManager.GetList();

            return View(contactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValues = _contactManager.GeyByID(id);

            return View(contactValues);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
    }
}