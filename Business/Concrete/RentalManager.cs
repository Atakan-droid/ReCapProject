using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using CORE.Aspects.Autofac.Caching;
using CORE.Aspects.Autofac.Performance;
using CORE.Aspects.Autofac.Validation;
using CORE.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal rentalDal;
        public RentalManager(IRentalDal _rentalDal)
        {
            rentalDal = _rentalDal;
        }
       // [SecuredOperation("user,admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rentals entity)
        {
            entity.RentDate = DateTime.Now;
      
                rentalDal.Add(entity);
                return new SuccessResult("Başarılı bir şekilde eklendi");
            
           
        }
        [PerformanceAspect(5)]
        [CacheRemoveAspect("IRentalService.Get")]
       // [SecuredOperation("user,admin")]
        public IResult Delete(Rentals entity)
        {

            rentalDal.Delete(entity);
            return new SuccessResult();
           
        }
        [PerformanceAspect(5)]
        [CacheAspect]
      //  [SecuredOperation("user,admin")]
        public IDataResult<List<Rentals>> GetAll()
        {
            return new SuccessDataResult<List<Rentals>>(rentalDal.GetAll(),Messages.RentalListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        [SecuredOperation("user,admin")]
        public IDataResult<Rentals> GetById(int Id)
        {
            return new SuccessDataResult<Rentals>(rentalDal.Get(p=>p.Id==Id),Messages.RentalListedById);
        }

        [PerformanceAspect(5)]
        public IDataResult<List<Rentals>> GetDataPhotoId(int Id)
        {
            throw new NotImplementedException();
        }

        [PerformanceAspect(5)]
        public IDataResult<List<Rents_Cars_CustomersDTOs>> GetRentDetail()
        {
            return new SuccessDataResult<List<Rents_Cars_CustomersDTOs>>(rentalDal.GetDetails(),Messages.RentalListed);
        }

        [PerformanceAspect(5)]
        [SecuredOperation("user,admin")]
        public IResult RentalBack (int Id)
        {
            var result = rentalDal.Get(p => p.Id==Id);
            result.ReturnDate = DateTime.Now;
            rentalDal.Update(result);
            return new SuccessResult(Messages.RentalBackSuccess);
        }

        [PerformanceAspect(5)]
        [SecuredOperation("admin")]
       [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rentals entity)
        {
            if (entity.ReturnDate == null)
            {
            rentalDal.Update(entity);
            return new SuccessResult("Başarılı bir şekilde güncellendi");
            }else
            {
                return new ErrorResult(Messages.RentalUpdateFail);
            }
           
        }
    }
}
