using CORE.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentContext>, ICarDal
    {
        public List<CarDTOs> GetAllDetails()
        {
            using (CarRentContext carRent=new CarRentContext())
            {
                var result = from c in carRent.Car
                             join color in carRent.Color on c.ColorId equals color.Id
                             join b in carRent.Brand on c.BrandId equals b.Id
                             select new CarDTOs {Id=c.Id,BrandName=b.BrandName,ColorName=color.ColorName,Description=c.Description,DailyPrice=c.DailyPrice,ModelYear=c.ModelYear };

                return result.ToList();
            }
        }
    }
}
