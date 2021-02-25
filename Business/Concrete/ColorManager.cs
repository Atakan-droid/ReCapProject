using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using CORE.Aspects.Autofac.Validation;
using CORE.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager :IColorService
    {
        IColorService _colorService;
        public ColorManager(IColorService colorService)
        {
            _colorService = colorService;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color entity)
        {
            _colorService.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Color entity)
        {
            _colorService.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Color>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Color> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Color>> GetDataPhotoId(int Id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Color entity)
        {
            _colorService.Update(entity);
           return new SuccessResult();
        }
    }
}
