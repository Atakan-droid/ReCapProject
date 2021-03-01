using CORE.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Utilities.Security.JWT
{
   public interface ITokenHelper
    {
        AccessToken CreateToken(User user,List<OperationClaim> operationClaims);
    }
}
