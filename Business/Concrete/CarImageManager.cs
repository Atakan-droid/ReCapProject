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
        public IResult Add(Images images,CarImage entity)
        {
            IResult result = BusinessRules.Run(CheckIfCarHaveMoreThan5Images(entity.CarId)
                ,CheckIfCarImagePathTypeCorrect(entity.ImagePath));

            if (result!=null)
            {
                return result;
            }
            var path = "\\images\\";
            var currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
            if(images.images!=null && images.images.Length > 0)
            {
                string randomName = Guid.NewGuid().ToString();
                string type = Path.GetExtension(images.images.FileName);

                if (!Directory.Exists(currentDirectory + path))
                {
                    Directory.CreateDirectory(currentDirectory + path);
                }

            }

            entity.Date = DateTime.Now;
            _carImageDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Add(CarImage entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(CarImage entity)
        {
           
            _carImageDal.Delete(entity);
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
