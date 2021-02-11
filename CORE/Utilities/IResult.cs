using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Utilities
{
   public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
