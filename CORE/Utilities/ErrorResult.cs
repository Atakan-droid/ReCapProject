using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Utilities
{
    public class ErrorResult:Result
    {
        public ErrorResult(string message):base(false,message)
        {

        }
        public ErrorResult():base(false)
        {
               
        }
    }
}
