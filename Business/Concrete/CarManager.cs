using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
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

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
                _carDal.Add(car);
                return new SuccessResult();
           
        }

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

        public IDataResult<List<Car>> GetAll()
        {
            
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),"Başarıyla Listelendi");
        }

        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id),Messages.IdyeGore);
        }

        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id),"Renge göre Idler");
        }

        public IDataResult<List<CarDTOs>> GetAllDetails()
        {
            if (DateTime.Now.Hour == 21) { return new ErrorDataResult<List<CarDTOs>>(_carDal.GetAllDetails(), "Hatalı liste"); };

            return new SuccessDataResult<List<CarDTOs>>(_carDal.GetAllDetails(),"Tüm detaylar listlendi");
        }

        public IDataResult<Car> GetById(int Id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p=>p.Id==Id));
        }

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
