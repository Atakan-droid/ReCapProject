using CORE.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IUserService:IBusinessService<User>
    {
        IDataResult<List<User_CustomerDTOs>> GetAllDetails();
    }
}
