using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKitap.Core.Utilities.Interceptors
{

    //Attribute classıyla kendi attributlerimizi oluşturabiliriz.

    //AllowMultiple(birden fazla) ve inherit edilen yerde bu attiribute birden fazla çalışsın.
    //Neden birden fazla çalışssın.(Örnek olarak Loglama yapılacaksa hem veritabanına hem de dosyaya loglamak istersek birden fazla kullanılmasına izin verilmeli
    //
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        //(Priority=Öncelik// Hangi attribute önce çalışsın.)
        public int Priority { get; set; }


        //Çalıştırmak istediğin metod(invocation)
        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
