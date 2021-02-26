using CORE.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarImageService:IBusinessService<CarImage>
    {
        IResult Add2(CarImage carImage, string extension);
    }
}
