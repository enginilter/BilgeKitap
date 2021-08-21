using BilgeKitap.Core.CrossCuttingConcerns.Validation;
using BilgeKitap.Core.Utilities.Interceptors;
using Castle.DynamicProxy;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BilgeKitap.Core.Aspects.Autofac.Validation
{

    //Burada MetotInterception'da virtual olan metotlardan hangisini kullanıp ezmek istiyorsak.Onu dolduruyoruz.
    //OnBefore(Metodun başında çalışacak)
    public class ValidationAspect : MethodInterception //Aspect(Metodun başında,sonunda hata verdiğinde çalışacak yapı)
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //Gönderilen validatorType eğer bir IValidator değilse 
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            //Çalışma anında instance oluşturmak için CreateInstance.
            //Gelen validatoru new ledi(productvalidator s =new productvalidator)
            var validator = (IValidator)Activator.CreateInstance(_validatorType);

            //Gelen Validatorun çalışma tipini buluyor.
            //validatorType=  ProductValidator(vs.).
            //BaseType= Product Validatorun BaseType'ı  yani AbstractValidator(Business Katmanı)
            //GetGenericArguments = Tipini yakala.(Product).
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];


            //Gelen validatorun parametrelerini buluyor.
            //invocation(Metot)
            //Argumetns = Metodun parametrelerini gez.Eğer oradaki tip entityType eşitse foreachle validate et.

            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);

            //Paramatereleri gez ve validate et.
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
