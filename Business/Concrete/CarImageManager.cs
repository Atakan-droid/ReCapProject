using Business.Abstract;
using CORE.Utilities;
using CORE.Utilities.BusinessRules;
using CORE.Utilities.FileHelper;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
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
            _carImageDal.Add(entity);
            return new SuccessResult("resim eklendi");

        }

        public IResult Add2(IFormFile file,CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarHaveMoreThan5Images(carImage.CarId)
               , CheckIfCarImagePathTypeCorrect(carImage.ImagePath));

            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = Filehelper.AddAsync(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage entity)
        {
            IResult result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }
            _carImageDal.Delete(entity);
            return new SuccessResult("Image Deleted");
        }

        public IResult Delete2(IFormFile file, CarImage carImage)
        {
            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _carImageDal.Get(p => p.Id == carImage.Id).ImagePath;

            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }
            Filehelper.DeleteAsync(oldpath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
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

           
            _carImageDal.Update(entity);
            return new SuccessResult("Image updated...");
        }

        public IResult Update2(IFormFile file, CarImage carImage)
        {
            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _carImageDal.Get(p => p.Id == carImage.Id).ImagePath;
            carImage.ImagePath = Filehelper.UpdateAsync(oldpath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();

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
       
        

    }
}
