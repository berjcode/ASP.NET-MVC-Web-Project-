using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IImageService
    {

        List<ImageFile> GetList();
        void ImageFileAdd(ImageFile imageFile);
        ImageFile GetByID(int id);
        void ImageFileDelete(ImageFile imageFile);

        void ImageFileUpdate(ImageFile imageFile);
    }
}
