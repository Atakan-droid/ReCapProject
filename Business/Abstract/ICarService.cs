using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarService:IBusinessService<Car>
    {
        
        List<Car> GetAllByBrandId(int id);
        List<Car> GetAllByColorId(int id);

        
        List<CarDTOs> GetAllDetails();
        
    }
}
