using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Utilities.Security.Hashing
{
   public class HashingHelper
    {
        public static void CreatePasswordHash(string password,
          out  byte[] passwordHash,
          out  byte[] passwordSalt)
        {
            using (var Hmac=new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = Hmac.Key;
                passwordHash = Hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VeriyPasswordHash(string password,
          byte[] passwordHash,
          byte[] passwordSalt)
        {
            using (var Hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = Hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!=passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
