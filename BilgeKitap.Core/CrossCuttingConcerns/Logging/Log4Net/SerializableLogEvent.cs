using log4net.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKitap.Core.CrossCuttingConcerns.Logging.Log4Net
{

    //Logları JSON formatında tutacağız.Bir nesnenin JSON formatına dönüştürülebilmesi için Serializable edilmesi gerek
    [Serializable]
    public class SerializableLogEvent
    {
        private LoggingEvent _loggingEvent;

        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }

        //Log Mesajı
        public object Message => _loggingEvent.MessageObject;
        //Log işlemine sebeb olan kişi
        public string UserName
        {
            get
            {
                return _loggingEvent.UserName;
            }
        }
 
    }
}
