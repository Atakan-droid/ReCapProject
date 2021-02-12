using CORE.DataAccess;
using CORE.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CarRentContext>, IUserDal
    {
        public List<User_CustomerDTOs> GetAllUserInformation()
        {
            using (CarRentContext userDetail = new CarRentContext())
            {
                var result = from u in userDetail.User
                             join
                             c in userDetail.Customers on
                             u.Id equals c.UserId
                             select new User_CustomerDTOs 
                             { Id = u.Id, UserName = u.FirstName, UserLastName = u.LastName, UserEmail = u.Email, UserPassword = u.Password,UserCompanyName=c.CompanyName };
                              

                return result.ToList();
                              
            }
        }
    }
}
