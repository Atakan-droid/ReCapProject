using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using CORE.Aspects.Autofac.Validation;
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

        public IDataResult<List<Brand>> GetDataPhotoId(int Id)
        {
            throw new NotImplementedException();
        }

        [ValidationAspect(typeof(BrandValidator))]
        IResult IBusinessService<Brand>.Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        IResult IBusinessService<Brand>.Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult();
        }

        [SecuredOperation("user,admin")]
        IDataResult<List<Brand>> IBusinessService<Brand>.GetAll()
        {

            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),"Tüm Brand'lar getirildi");
        }

        [SecuredOperation("user,admin")]
        IDataResult<Brand> IBusinessService<Brand>.GetById(int Id)
        {
            
            return new SuccessDataResult<Brand>(_brandDal.Get(p => p.Id == Id),"Id ye göre getirildi");
        }

        [SecuredOperation("admin")]
        IResult IBusinessService<Brand>.Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult();
        }
    }
}
