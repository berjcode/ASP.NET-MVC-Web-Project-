﻿using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> GetListInbox()
        {
            return  _messageDal.List(x =>x.ReceiverMail =="admin@gmail.com");
        }

       
        public List<Message> GetListSendBox()
        {
            return _messageDal.List(x => x.SenderMail == "admin@gmail.com");
        }

        public Message GeyByID(int id)
        {
            return _messageDal.Get(x => x.MessageID == id);
        }

        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            _messageDal.Delete(message);
        }

        public void MessageUpdate(Message message)
        {
           _messageDal.Update(message);
        }
    }
}