﻿using CORE.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public interface IUserDal:IEntityRepository<User>
    {
        List<User_CustomerDTOs> GetAllUserInformation();
    }
}
