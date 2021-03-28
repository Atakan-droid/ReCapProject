using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using CORE.Aspects.Autofac.Performance;
using CORE.Aspects.Autofac.Transaction;
using CORE.Aspects.Autofac.Validation;
using CORE.CrossCuttingConcerns.Validation;
using CORE.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("admin")]
        [PerformanceAspect(5)]
       [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
                _carDal.Add(car);
                return new SuccessResult();
           
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice<10)
            {
                throw new Exception("");
            }
            Add(car);
            return null;
        }

        [SecuredOperation("admin")]
        public IResult Delete(Car car)
        {
            if (car.Id==0)
            {
                return new ErrorResult("Hatalı Araba Silinmedi");
            }
            else
            {
                _carDal.Delete(car);

                return new SuccessResult("Araç Silindi");
            };
        }
       // [PerformanceAspect(5)]
       // [SecuredOperation("user,admin")]
        public IDataResult<List<Car>> GetAll()
        {
            
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),"Başarıyla Listelendi");
        }

        [SecuredOperation("user,admin")]
        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id),Messages.IdyeGore);
        }
        [PerformanceAspect(5)]
        [SecuredOperation("user,admin")]
        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id),"Renge göre Idler");
        }

       // [SecuredOperation("user,admin")]
        public IDataResult<List<CarDTOs>> GetAllDetails()
        {
           

            return new SuccessDataResult<List<CarDTOs>>(_carDal.GetAllDetails(),"Tüm detaylar listlendi");
        }

        public IDataResult<List<CarDTOs>> GetAllDetailsByBrand(int brandId)
        {
            return new SuccessDataResult<List<CarDTOs>>(_carDal.GetAllDetailsByBrand(brandId), "Tüm detaylar listlendi");
        }

        public IDataResult<List<CarDTOs>> GetAllDetailsByColor(int colorId)
        {
            return new SuccessDataResult<List<CarDTOs>>(_carDal.GetAllDetailsByColor(colorId), "Tüm detaylar listlendi");
        }

       // [SecuredOperation("user,admin")]
        public IDataResult<Car> GetById(int Id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p=>p.Id==Id));
        }

        [SecuredOperation("user,admin")]
        public IDataResult<List<Car>> GetDataPhotoId(int Id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarDTOs>> GetDetail(int carId)
        {
            return new SuccessDataResult<List<CarDTOs>>(_carDal.GetDetail(carId), "Tek araç listlendi");
        }

        [SecuredOperation("admin")]
        public IResult Update(Car car)
        {
            if (car.ModelYear > 2021)
            {
                return new ErrorResult("Model Yılı Hatalı");
            }
            else
            {
                _carDal.Update(car);

                return new SuccessResult("Araç Eklendi");
            }
           

           
        }
    }
}
