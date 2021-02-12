using CORE.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IRentalService:IBusinessService<Rentals>
    {
        IDataResult<List<Rents_Cars_CustomersDTOs>> GetRentDetail();
    }
}
