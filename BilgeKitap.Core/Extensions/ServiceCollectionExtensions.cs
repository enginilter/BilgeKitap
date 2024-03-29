﻿using BilgeKitap.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKitap.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {

        //IServiceCollection=API mizin servis bağlılıklarını eklediğimiz yer
        public static IServiceCollection AddDependencyResolvers
            (this IServiceCollection services, ICoreModule[] modules)

        {
            foreach (var module in modules)
            {
                module.Load(services);
            }

            return ServiceTool.Create(services);
        }
    }
}
