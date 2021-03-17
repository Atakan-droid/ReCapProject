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
                var result = from c in carRent.Cars
                             join color in carRent.Colors on c.BrandId equals color.Id
                             join b in carRent.Brands on c.BrandId equals b.Id 
                             select new CarDTOs {Id=c.Id,BrandName=b.BrandName,ColorName=color.ColorName,Description=c.Description,DailyPrice=c.DailyPrice,ModelYear=c.ModelYear };

                return result.ToList();
            }
        }

        public List<CarDTOs> GetAllDetailsByBrand(int brandId)
        {
            using (CarRentContext carRent = new CarRentContext())
            {
                var result = from c in carRent.Cars
                             join color in carRent.Colors on c.ColorId equals color.Id
                             join b in carRent.Brands on c.BrandId equals b.Id 
                             where c.BrandId==brandId
                             select new CarDTOs { Id = c.Id, BrandName = b.BrandName, ColorName = color.ColorName, Description = c.Description, DailyPrice = c.DailyPrice, ModelYear = c.ModelYear };

                return result.ToList();
            }
        }

        public List<CarDTOs> GetAllDetailsByColor(int colorId)
        {
            using (CarRentContext carRent = new CarRentContext())
            {
                var result = from c in carRent.Cars
                             join color in carRent.Colors on c.ColorId equals color.Id
                             join b in carRent.Brands on c.BrandId equals b.Id
                             where c.ColorId == colorId
                             select new CarDTOs { Id = c.Id, BrandName = b.BrandName, ColorName = color.ColorName, Description = c.Description, DailyPrice = c.DailyPrice, ModelYear = c.ModelYear};

                return result.ToList();
            }
        }

        public List<CarDTOs> GetDetail(int carId)
        {
            using (CarRentContext carRent = new CarRentContext())
            {
                var result = from c in carRent.Cars
                             join color in carRent.Colors on c.ColorId equals color.Id
                             join b in carRent.Brands on c.BrandId equals b.Id
                             
                             where c.Id == carId
                             select new CarDTOs { Id = c.Id, BrandName = b.BrandName, ColorName = color.ColorName, Description = c.Description, DailyPrice = c.DailyPrice, ModelYear = c.ModelYear};

                return result.ToList();
            }
        }
    }
}
