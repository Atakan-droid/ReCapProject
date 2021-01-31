using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            _carDal.Add(car);
        }

        public void Delete(int carId)
        {
            _carDal.Delete(carId);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public void GetById(Car car)
        {
            _carDal.GetById(car.Id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
