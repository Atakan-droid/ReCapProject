using CORE.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDTOs> GetAllDetails();
        List<CarDTOs> GetAllDetailsByBrand(int brandId);
        List<CarDTOs> GetAllDetailsByColor(int colorId);
        List<CarDTOs> GetDetail(int carId);

    }
}
