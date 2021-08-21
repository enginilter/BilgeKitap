using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKitap.Core.Utilities.Interceptors
{
    /// <summary>
    /// 
    /// Interceptors:
    /// -------------
    /// İş ihtiyaçlarına göre metoda girmeden önce,işlem bittikten sonra ve hata durumunda gibi durumlarda araya girerek
    /// istediğimiz müdahaleyi yapabilmemizi sağlar.Bu işlemler 2 ye ayrılır CompileTime(Derleme Zamanı) ve Runtime(Çalışma Zamanı)
    /// 
    /// Compile=Uygulama derlendiği an çalışılması istenir(Postsharp)
    /// Runtime=İşlemler çalışma zamanında gerçekleşir(Autofac)
    /// 
    /// </summary>

    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        //invocation :  Buradaki invocation çalıştırmak istediğimiz metot.(add gibi,get,getbyCategoryId)
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }


        //Metotlar çalıştırılmadan önce burada kontrol edilecek.
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }


    }
}
