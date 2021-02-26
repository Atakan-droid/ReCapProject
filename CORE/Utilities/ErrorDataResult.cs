﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Utilities
{
    public class ErrorDataResult<T>:DataResult<T>
    {
        private string message;

        public ErrorDataResult(T data,string message):base(data,false,message)
        {

        }
        public ErrorDataResult(T data):base(data,false)
        {

        }

       
    }
}
