using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EFMessageDal());
        public ActionResult Inbox()
        {
            var messageList = messageManager.GetListInbox();

                return View(messageList);
        }
    }
}