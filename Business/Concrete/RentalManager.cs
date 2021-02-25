using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
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
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rentals entity)
        {
            if (entity.RentDate == null)
            {
                return new ErrorResult(Messages.RentalAddFail);
            }
            else
            {
                rentalDal.Add(entity);
                return new SuccessResult("Başarılı bir şekilde eklendi");
            };
           
        }

        public IResult Delete(Rentals entity)
        {

            rentalDal.Delete(entity);
            return new SuccessResult();
           
        }

        public IDataResult<List<Rentals>> GetAll()
        {
            return new SuccessDataResult<List<Rentals>>(rentalDal.GetAll(),Messages.RentalListed);
        }

        public IDataResult<Rentals> GetById(int Id)
        {
            return new SuccessDataResult<Rentals>(rentalDal.Get(p=>p.Id==Id),Messages.RentalListedById);
        }

        public IDataResult<List<Rentals>> GetDataPhotoId(int Id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rents_Cars_CustomersDTOs>> GetRentDetail()
        {
            return new SuccessDataResult<List<Rents_Cars_CustomersDTOs>>(rentalDal.GetDetails(),Messages.RentalListed);
        }

        public IResult RentalBack (int Id)
        {
            var result = rentalDal.Get(p => p.Id==Id);
            result.ReturnDate = DateTime.Now;
            rentalDal.Update(result);
            return new SuccessResult(Messages.RentalBackSuccess);
        }

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
