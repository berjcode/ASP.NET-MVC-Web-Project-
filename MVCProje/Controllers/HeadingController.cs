using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        WriterManager wm = new WriterManager(new EFWriterDal());
        
        public ActionResult Index()
        {
            var headingValues = hm.GetList();
            return View(headingValues);
        }

        public ActionResult HeadingReport()
        {
            var headingValues = hm.GetList();
            return View(headingValues);
        }


        [HttpGet]
        public  ActionResult AddHeading()
        {
            List<SelectListItem> valueCatagory = (from x in cm.GetList()
                                   select new SelectListItem
                                   {
                                       Text=x.CategoryName,
                                       Value=x.CategoryId.ToString()
                                   } ).ToList();
            /*----------------------------Writer DropwList------------------------------------*/

            List<SelectListItem> valueWriter = (from x in wm.GetList()
                select new SelectListItem
             {
                    Text = x.WriterName + " " +x.WriterSurName,
                    Value = x.WriterID.ToString()
            } ).ToList();
            ViewBag.vlc = valueCatagory;
            ViewBag.vlw = valueWriter;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            
            
           p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }



        public ActionResult DeleteHeading(int id)
        {
            var headingValue = hm.GeyByID(id);
            hm.HeadingDelete(headingValue);
            return RedirectToAction("Index");
        }

       
    }
}