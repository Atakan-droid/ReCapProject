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
    }
}
