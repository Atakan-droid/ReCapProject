using CORE.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rentals, CarRentContext>, IRentalDal
    {
        public List<Rents_Cars_CustomersDTOs> GetDetails()
        {
            using (CarRentContext carRent= new CarRentContext())
            {
                var result = from c in carRent.Customers
                             join u in carRent.Users
                             on c.UserId equals u.Id
                             join r in carRent.Rentals on c.Id equals r.CustomerId
                             join car in carRent.Car on r.CarId equals car.Id 
                             select new Rents_Cars_CustomersDTOs {Id=r.Id,CarName=car.Description,CustomerName=u.FirstName,RentDate=r.RentDate };

                return result.ToList();

                            
            }
        }
    }
}
