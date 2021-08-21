using BilgeKitap.Core.CrossCuttingConcerns.Logging;
using BilgeKitap.Core.CrossCuttingConcerns.Logging.Log4Net;
using BilgeKitap.Core.Utilities.Interceptors;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKitap.Core.Aspects.Logging
{
    public class LogAspect: MethodInterception
    {
        private LoggerService _loggerService;
        public LogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerService))
            {
                throw new System.Exception("Wrong logger type");
            }

            _loggerService = (LoggerService)Activator.CreateInstance(loggerService);
        }
        protected override void OnBefore(IInvocation invocation)
        {
            _loggerService.Info(GetLogDetail(invocation));
        }
        private LogDetail GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name
                });
            }

            var logDetail = new LogDetail
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters
            };

            return logDetail;
        }
    }
}
