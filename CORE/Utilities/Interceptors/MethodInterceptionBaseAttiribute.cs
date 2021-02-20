using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method,AllowMultiple =true,Inherited =true)]
   public abstract class MethodInterceptionBaseAttiribute:Attribute,IInterceptor
    {
        public int Priority { get; set; }
        public virtual void Intercept(IInvocation ınvocation)
        {

        }
    }
}
