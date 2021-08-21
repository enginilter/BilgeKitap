using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKitap.Core.Utilities.IoC
{


    //WebApı de veya autofacde oluşturulan injectionları kullanabilmeye yarıyor.
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

   
        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
