using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Utilities
{
    public interface IDataResult<T>:IResult
    {
        T Data { get; }
    }
}
