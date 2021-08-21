using Autofac;
using Autofac.Extras.DynamicProxy;
using BilgeKitap.Business.Abstract;
using BilgeKitap.Business.Concrete;
using BilgeKitap.Core.Utilities.Interceptors;
using BilgeKitap.Core.Utilities.Security.JWT;
using BilgeKitap.Data.Abstract;
using BilgeKitap.Data.Concrete;
using BilgeKitap.Data.Concrete.EntityFramework;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKitap.Business.Dependency_Resolvers.Autofac
{
    /// <summary>
    /// 
    /// Autofac ve Autofac.Extras.DynamicProxy indirildi.
    /// Farklı bir IoC Container'ı kullanamak istenirse Program.cs 'e ekleme yapmamız gerekir.Devamı Program.cs..
    /// 
    /// Birden fazla API,farklı servis yapıları veya başka bir servis mimarisi kullanmak gerekirse Autofac'in Business
    /// katmanında kurulu olması daha faydalıdır.
    /// 
    /// Bir servis mimarisi kullanmak istenirse bağlılıkları tek bir API içindeki Startup'a bağlamamak gerekir.
    /// Bu yüzden Autofac kullanılır.
    /// 
    /// </summary>
    public class AutofacBusinessModule:Module
    {

        //Proje çalıştığında çalışacak kısım.
        protected override void Load(ContainerBuilder builder)
        {
            // Startup'da yazılan Services.AddSingleton karşılığıdır.        
            builder.RegisterType<AuthorManager>().As<IAuthorService>().SingleInstance();
            builder.RegisterType<EFAuthorDal>().As<IAuthorDal>().SingleInstance();


            builder.RegisterType<AccountManager>().As<IAccountService>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();

            builder.RegisterType<EFUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();

           




            builder.RegisterType<BookManager>().As<IBookService>().SingleInstance();
            builder.RegisterType<EFBookDal>().As<IBookDal>().SingleInstance();

            builder.RegisterType<OrderDetailManager>().As<IOrderDetailService>().SingleInstance();
            builder.RegisterType<EFOrderDetailDal>().As<IOrderDetailDal>().SingleInstance();

            builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
            builder.RegisterType<EFOrderDal>().As<IOrderDal>().SingleInstance();

            

            builder.RegisterType<BookCategoriesManager>().As<IBookCategoryService>().SingleInstance();
            builder.RegisterType<EFBookCategoriesDal>().As<IBookCategoryDal>().SingleInstance();


            //builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();

            //builder.RegisterType<IHttpContextAccessor>().As<HttpContextAccessor>().SingleInstance();




            //GetExecutingAssembly(Çalışan Uygulama içerisinde reflectionları bul)
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            //İmplemente edilmiş interfaceleri bul
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                //Bulunan interfaceleri AspectIntercopterSelector'i çağır.
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
        }
    }
}
