using CORE.DataAccess;
using CORE.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using CORE.Entities.Concrete;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CarRentContext>, IUserDal
    {
       
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new CarRentContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim() {Id=operationClaim.Id,Name=operationClaim.Name };
                return result.ToList();
            }
        }

     
    }
}
