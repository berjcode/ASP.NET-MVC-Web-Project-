using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace MVCProje.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        WriterManager wm = new WriterManager(new EFWriterDal());
        WriterValidator writerValidator = new WriterValidator();

        Context _context = new Context();

        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
            string p = (string)Session["WriterMail"];
            ViewBag.d = p;
            id = _context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();

            var writerValue = wm.GetByID(id);
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult WriterProfil(Writer p)
        {
            ValidationResult result = writerValidator.Validate(p);
            if (result.IsValid)
            {
                wm.WriterUpdate(p);

                return RedirectToAction("AllHeading", "WriterPanel");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        public ActionResult MyHeading(string mail_)
        {
                 mail_ = (string)Session["WriterMail"];
                 var writerHeadingInfo = _context.Writers.Where(x => x.WriterMail == mail_).Select(y => y.WriterID).FirstOrDefault();
            
         
                 var values = hm.GetListByWriter(writerHeadingInfo);
                   return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            
            List<SelectListItem> valueCatagory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();

            ViewBag.vlc = valueCatagory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            string m_ =  (string)Session["WriterMail"];
            var writerHeadingInfo = _context.Writers.Where(x => x.WriterMail ==m_).Select(y => y.WriterID).FirstOrDefault();
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = writerHeadingInfo;
            ViewBag.d = writerHeadingInfo;
            p.HeadingStatus = true;
            hm.HeadingAdd(p);
            return RedirectToAction("MyHeading");
        }



        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCatagory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCatagory;
            /* -------------------------------------------------------------*/
            var headingValue = hm.GeyByID(id);
            return View(headingValue);

        }

        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            
            hm.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        
        }
    
        public ActionResult DeleteHeading(int id)
        {
            var headingValue = hm.GeyByID(id);
            headingValue.HeadingStatus = false;
            hm.HeadingDelete(headingValue);
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeading(int p=1)
        {
            var headings = hm.GetList().ToPagedList(p,4);
            return View(headings);
        }


    }
}