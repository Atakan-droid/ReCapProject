using Business.Abstract;
using Business.Constants;
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
        public IResult Add(Rentals entity)
        {
           
                rentalDal.Add(entity);
                return new SuccessResult("Başarılı bir şekilde eklendi");
           
        }

        public IResult Delete(Rentals entity)
        {

            return new SuccessResult("Başarılı bir şekilde silindi");
           
        }

        public IDataResult<List<Rentals>> GetAll()
        {
            return new SuccessDataResult<List<Rentals>>(rentalDal.GetAll(),Messages.RentalListed);
        }

        public IDataResult<Rentals> GetById(int Id)
        {
            return new SuccessDataResult<Rentals>(rentalDal.Get(p=>p.Id==Id),Messages.RentalListedById);
        }

        public IDataResult<List<Rents_Cars_CustomersDTOs>> GetRentDetail()
        {
            return new SuccessDataResult<List<Rents_Cars_CustomersDTOs>>(rentalDal.GetDetails(),Messages.RentalListed);
        }

        public IResult Update(Rentals entity)
        {
            return new SuccessResult("Başarılı bir şekilde güncellendi");
        }
    }
}
