using log4net;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKitap.Core.CrossCuttingConcerns.Logging.Log4Net
{
    public class LoggerService
    {
        ILog _log;
        public LoggerService(ILog log)
        {
            _log = log;
        }

        //Çağırılan metodun saati,kimin çağırdığı
        public bool IsInfoEnabled => _log.IsInfoEnabled;
        //Debug Logları açık mı
        public bool IsDebugEnabled => _log.IsDebugEnabled;
        public bool IsWarnEnabled => _log.IsWarnEnabled;
        public bool IsFatalEnabled => _log.IsFatalEnabled;

        //Bir hata olduğunda 
        public bool IsErrorEnabled => _log.IsErrorEnabled;

        public void Info(object logMessage)
        {
            if (IsInfoEnabled)
                _log.Info(logMessage);
        }

        public void Debug(object logMessage)
        {
            if (IsDebugEnabled)
                _log.Debug(logMessage);
        }

        public void Warn(object logMessage)
        {
            if (IsWarnEnabled)
                _log.Warn(logMessage);
        }

        public void Fatal(object logMessage)
        {
            if (IsFatalEnabled)
                _log.Fatal(logMessage);
        }

        public void Error(object logMessage)
        {
            if (IsErrorEnabled)
                _log.Error(logMessage);
        }


    }
}
