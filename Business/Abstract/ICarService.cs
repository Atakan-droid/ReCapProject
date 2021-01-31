using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarService
    {
        List<Car> GetAll();
        void Update(Car car);
        void Delete(int carId);
        void Add(Car car);
        void GetById(Car car);
    }
}
