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
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public List<Heading> GetList()
        {
            return _headingDal.List();
        }

        public List<Heading> GetListByWriter(int id)
        {
            return _headingDal.List_(x => x.WriterID == id);
        }

        public Heading GeyByID(int id)
        {
            return _headingDal.Get(x => x.HeadingID == id);
        }

        public void HeadingAdd(Heading heading)
        {
            _headingDal.Insert(heading);
        }

        public void HeadingDelete(Heading heading)
        {
            if (heading.HeadingStatus == true)
            {
                heading.HeadingStatus = false;
                _headingDal.Update(heading);
            }
            else if (heading.HeadingStatus == false)
            {
                heading.HeadingStatus = true;
                _headingDal.Update(heading);
            }

           
           // heading.HeadingStatus = false;
           // _headingDal.Update(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
           _headingDal.Update(heading);
        }
    }
}
