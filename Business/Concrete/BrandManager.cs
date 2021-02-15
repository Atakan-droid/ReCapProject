using Business.Abstract;
using CORE.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
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
            _brandDal.Delete(brand);
            return new SuccessResult();
        }

        IDataResult<List<Brand>> IBusinessService<Brand>.GetAll()
        {

            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),"Tüm Brand'lar getirildi");
        }

        IDataResult<Brand> IBusinessService<Brand>.GetById(int Id)
        {
            
            return new SuccessDataResult<Brand>(_brandDal.Get(p => p.Id == Id),"Id ye göre getirildi");
        }

        IResult IBusinessService<Brand>.Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult();
        }
    }
}
