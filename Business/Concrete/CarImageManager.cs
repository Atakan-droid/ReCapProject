using Business.Abstract;
using CORE.Utilities;
using CORE.Utilities.BusinessRules;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
       
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        public IResult Add(CarImage entity)
        {
            IResult result = BusinessRules.Run(CheckIfCarHaveMoreThan5Images(entity.CarId)
                ,CheckIfCarImagePathTypeCorrect(entity.ImagePath));

            if (result!=null)
            {
                return result;
            }
            string createPath = ImagePath(entity);
            File.Copy(entity.ImagePath, createPath);
            entity.ImagePath = createPath;
            entity.Date = DateTime.Now;
            _carImageDal.Add(entity);
            return new SuccessResult("resim eklendi");

        }

       

        public IResult Delete(CarImage entity)
        {

            var ImageDelete = _carImageDal.Get(p => p.Id == entity.Id);
            File.Delete(ImageDelete.ImagePath);
            _carImageDal.Delete(entity);
            return new SuccessResult("Image Deleted");
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(),"Hepsi geldi");
        }

        public IDataResult<CarImage> GetById(int Id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == Id), "Başarılı");
        }

        public IDataResult<List<CarImage>> GetDataPhotoId(int Id)
        {
           
           
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.Id==Id));

        }

        public IResult Update(CarImage entity)
        {
            IResult result = BusinessRules.Run(CheckIfCarHaveMoreThan5Images(entity.CarId));
            if (result != null)
            {
                return result;
            }

            var updatePath = ImagePath(entity);
            File.Copy(entity.ImagePath, updatePath);
            File.Delete(entity.ImagePath);
            entity.ImagePath = updatePath;
            _carImageDal.Update(entity);
            return new SuccessResult("Image updated...");
        }
        private IResult CheckIfCarHaveMoreThan5Images(int image)
        {
            var result = _carImageDal.GetAll(p=>p.CarId==image).Count;
            if (result > 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IDataResult<List<CarImage>> CheckIfCarHavePhoto(int id)
        {
            var result = _carImageDal.GetAll(p => p.CarId == id).Any();
            if (!result)
            {
                return new ErrorDataResult<List<CarImage>>(new List<CarImage>
                { new CarImage {ImagePath = "logo.jpg"} }
                );

            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == id));
        }
        private IResult CheckIfCarImagePathTypeCorrect(string imagePath)
        {
            string acceptableExtensions = ".jpg";
            if (string.Compare(imagePath, acceptableExtensions) == 0)
            {
                return new ErrorResult("Hatalı form");
            }
            return new SuccessResult();
        }
        private string ImagePath(CarImage entity)
        {
            string namePathRule = "CarImages-" + entity.CarId + "-" + DateTime.Now;
            return AppDomain.CurrentDomain.BaseDirectory + "Images\\" + namePathRule + ".jpg";
        }
    }
}
