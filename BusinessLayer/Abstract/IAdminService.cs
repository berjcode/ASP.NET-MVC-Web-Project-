using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public  interface IAdminService
    {
        List<Admin> GetList();
        Admin GeyByID(int id);
        void AdminAdd(Admin admin);
        
        void AdminDelete(Admin admin);

        void AdminUpdate(Admin admin);
    }
}
