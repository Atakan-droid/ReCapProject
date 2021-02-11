using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Utilities
{
   public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data,string message):base(data,true,message)
        {

        }
        public SuccessDataResult(T data):base(data,true)
        {

        }
    }
}
