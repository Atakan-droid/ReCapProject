using CORE.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarService:IBusinessService<Car>
    {
        
        IDataResult<List<Car>> GetAllByBrandId(int id);
        IDataResult<List<Car>> GetAllByColorId(int id);

        IResult AddTransactionalTest(Car car);
        IDataResult<List<CarDTOs>> GetAllDetails();
        IDataResult<List<CarDTOs>> GetAllDetailsByBrand(int brandId);
        IDataResult<List<CarDTOs>> GetAllDetailsByColor(int colorId);
        IDataResult<List<CarDTOs>> GetDetail(int carId);
    }
}
