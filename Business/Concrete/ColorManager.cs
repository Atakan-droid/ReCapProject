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
    public class ColorManager :IColorService
    {
        IColorDal _colorService;
        public ColorManager(IColorDal colorService)
        {
            _colorService = colorService;
        }

       // [SecuredOperation("admin")]
       // [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color entity)
        {
            _colorService.Add(entity);
            return new SuccessResult();
        }

        [SecuredOperation("admin")]
        public IResult Delete(Color entity)
        {
            _colorService.Delete(entity);
            return new SuccessResult();
        }

       // [SecuredOperation("user,admin")]
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorService.GetAll(),"Başarılı");
        }

        [SecuredOperation("user,admin")]
        public IDataResult<Color> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        [SecuredOperation("user,admin")]
        public IDataResult<List<Color>> GetDataPhotoId(int Id)
        {
            throw new NotImplementedException();
        }

        [SecuredOperation("admin")]
        public IResult Update(Color entity)
        {
            _colorService.Update(entity);
           return new SuccessResult();
        }
    }
}
