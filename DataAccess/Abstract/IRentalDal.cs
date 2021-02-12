using CORE.DataAccess;
using CORE.DataAccess.EntityFramework;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public interface IRentalDal:IEntityRepository<Rentals>
    {
        List<Rents_Cars_CustomersDTOs> GetDetails();
    }
}
