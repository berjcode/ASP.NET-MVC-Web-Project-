using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class WriterPanelMessageController : Controller
    {

        MessageManager messageManager = new MessageManager(new EFMessageDal());
        MessageValidator _messageValidator = new MessageValidator();
        public ActionResult Inbox()
        {
            var messageList = messageManager.GetListInbox();

            return View(messageList);
        }
        public ActionResult SendBox()
        {
            var messageList = messageManager.GetListSendBox();
            return View(messageList);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

        public ActionResult GetInBoxMessageDetails(int id)
        {
            var ınBoxValues = messageManager.GeyByID(id);

            return View(ınBoxValues);
        }
        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var sendBoxValues = messageManager.GeyByID(id);
            return View(sendBoxValues);
        }


        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult result = _messageValidator.Validate(p);
            if (result.IsValid)
            {
                p.SenderMail = "abdblk@hotmail.com";
                p.Messagedate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.MessageAdd(p);

                return RedirectToAction("SendBox");
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
    }
}