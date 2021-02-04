using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            new Car{Id=1,BrandId=1,ColorId=2,DailyPrice=500,Description="Fiyat",ModelYear=1998},
            new Car{Id=2,BrandId=1,ColorId=4,DailyPrice=5000,Description="Meireless",ModelYear=1980},
            new Car{Id=3,BrandId=2,ColorId=10,DailyPrice=400,Description="İkea",ModelYear=2012},
            new Car{Id=4,BrandId=4,ColorId=4,DailyPrice=200,Description="Evinizin",ModelYear=2009},
            new Car{Id=5,BrandId=5,ColorId=5,DailyPrice=700,Description="Herşeyi",ModelYear=2003},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(int carId)
        {
            Car tempList = null;
            tempList = _cars.SingleOrDefault(c => c.Id == carId);
            _cars.Remove(tempList);

        }

        public void Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.Id==carId).ToList();
        }

        public void Update(Car car)
        {
            Car tempList = null;
            tempList = _cars.SingleOrDefault(c => c.Id == car.Id);
            tempList.ColorId = car.ColorId;
            tempList.DailyPrice = car.DailyPrice;
            tempList.Description = car.Description;
            tempList.BrandId = car.BrandId;
            tempList.ModelYear = car.ModelYear;
            tempList.Id = car.Id;
        }
    }
}
