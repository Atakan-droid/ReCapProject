using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Utilities.Security.JWT
{
   public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public int user { get; set; }
    }
}
