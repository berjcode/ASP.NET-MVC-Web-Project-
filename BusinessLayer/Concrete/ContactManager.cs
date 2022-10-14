using BusinessLayer.Abstract;
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
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void ContactAdd(Contact contact)
        {
            _contactDal.Insert(contact);
        }

        public void ContactDelete(Contact contact)
        {
            _contactDal.Delete(contact);    
        }

        public void ContactUpdate(Contact contact)
        {
            _contactDal.Update(contact);
        }

        public List<Contact> GetList()
        {
            return _contactDal.List();
        }

        public Contact GeyByID(int id)
        {
        
           return _contactDal.Get(X=> X.ContactId == id);
        }
    }
}
