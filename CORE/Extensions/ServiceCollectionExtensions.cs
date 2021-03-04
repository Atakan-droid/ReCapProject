using CORE.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Extensions
{
   public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependecyResolvers(this IServiceCollection services,
            ICoreModule[] coreModule)
        {
            foreach (var module in coreModule)
            {
                module.Load(services);
            }
            return ServiceTool.Create(services);
        }
    }
}
