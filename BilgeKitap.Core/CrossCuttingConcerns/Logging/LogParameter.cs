using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKitap.Core.CrossCuttingConcerns.Logging
{
    //Metodun değerlerini tutuyor.
    public class LogParameter
    {
        //Parametrenini ismi
        public string Name { get; set; }
        //Parametrenini değeri
        public object Value { get; set; }

        //Parametrenini tipi
        public string Type { get; set; }
    }
}
