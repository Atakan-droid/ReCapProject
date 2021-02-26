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
            _carImageDal.Add(entity);
            return new SuccessResult("resim eklendi");

        }

        public IResult Add2(CarImage carImage, string extension)
        {
            IResult result = BusinessRules.Run(CheckIfCarHaveMoreThan5Images(carImage.CarId)
               , CheckIfCarImagePathTypeCorrect(carImage.ImagePath));

            if (result != null)
            {
                return result;
            }
            var addedCarImage = CreatedFile(carImage, extension).Data;
            _carImageDal.Add(addedCarImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage entity)
        {
            IResult result = BusinessRules.Run(CarImageDelete(entity));
            if (result != null)
            {
                return result;
            }
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

            var carImageUpdate = UpdatedFile(entity).Data;
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
        private IDataResult<CarImage> CreatedFile(CarImage carImage,string extension)
        {            

            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images");           

            var creatingUniqueFilename = Guid.NewGuid().ToString("N")
                + "_" + DateTime.Now.Month + "_"
                + DateTime.Now.Day + "_"
                + DateTime.Now.Year + extension;

            string source = Path.Combine(carImage.ImagePath);

            string result = $@"{path}\{creatingUniqueFilename}";

           File.Move(source, path + @"\" + creatingUniqueFilename);
           
        
            return new SuccessDataResult<CarImage>(new CarImage { Id = carImage.Id, CarId = carImage.CarId, ImagePath = result, Date = DateTime.Now }, "Image added");
        }
        private IDataResult<CarImage> UpdatedFile(CarImage carImage)
        {
            var creatingUniqueFilename = Guid.NewGuid().ToString("N") + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + ".jpeg";

            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images");

            string result = $"{path}\\{creatingUniqueFilename}";

            File.Copy(carImage.ImagePath, path + "\\" + creatingUniqueFilename);

            File.Delete(carImage.ImagePath);

            return new SuccessDataResult<CarImage>(new CarImage { Id = carImage.Id, CarId = carImage.CarId, ImagePath = result, Date = DateTime.Now });
        }
        private IResult CarImageDelete(CarImage carImage)
        {
            try
            {
                File.Delete(carImage.ImagePath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }

    }
}
