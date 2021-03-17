using CORE.Utilities;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarImageService:IBusinessService<CarImage>
    {
        IResult Add2(IFormFile file, CarImage carImage);
        IResult Update2(IFormFile file, CarImage carImage);
        IResult Delete2(IFormFile file, CarImage carImage);
        IDataResult <List<CarImage>> GetByCarId(int carId);
    }
}
