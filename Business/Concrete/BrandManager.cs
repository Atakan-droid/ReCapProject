using Business.Abstract;
using CORE.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBusinessService<Brand>
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        IResult IBusinessService<Brand>.Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult();
        }

        IResult IBusinessService<Brand>.Delete(Brand brand)
        {
            throw new NotImplementedException();
        }

        IDataResult<List<Brand>> IBusinessService<Brand>.GetAll()
        {
            throw new NotImplementedException();
        }

        IDataResult<Brand> IBusinessService<Brand>.GetById(int Id)
        {
            throw new NotImplementedException();
        }

        IResult IBusinessService<Brand>.Update(Brand brand)
        {
            throw new NotImplementedException();
        }
    }
}
