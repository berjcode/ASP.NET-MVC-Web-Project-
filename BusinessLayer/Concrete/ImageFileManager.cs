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
    public class ImageFileManager : IImageService
    {

        IImageFileDal _imageFileDal;

        public ImageFileManager(IImageFileDal imageFileDal)
        {
            _imageFileDal = imageFileDal;
        }

        public ImageFile GetByID(int id)
        {
            return _imageFileDal.Get(x => x.ImageID==id);
        }

        public List<ImageFile> GetList()
        {
            return _imageFileDal.List();
        }

        public void ImageFileAdd(ImageFile imageFile)
        {
            _imageFileDal.Insert(imageFile);
        }

        public void ImageFileDelete(ImageFile imageFile)
        {
           _imageFileDal.Delete(imageFile);
        }

        public void ImageFileUpdate(ImageFile imageFile)
        {
            _imageFileDal.Update(imageFile);
        }
    }
}
