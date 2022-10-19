using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager _imageFileManager = new ImageFileManager(new EFImageFileDal());
        public ActionResult Index()
        {
            var files = _imageFileManager.GetList();
            return View(files);
        }
    }
}