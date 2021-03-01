using CORE.Entities.Concrete;
using CORE.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IUserService:IBusinessService<User>
    {
       IDataResult<List<OperationClaim>> GetClaim(User user);
        User GetByEmail(string email);
    }
}
