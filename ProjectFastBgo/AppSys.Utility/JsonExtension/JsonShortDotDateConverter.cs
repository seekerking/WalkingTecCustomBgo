using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Converters;

namespace AppSys.Utility.JsonExtension
{
    public class JsonShortDotDateConverter: IsoDateTimeConverter
    {
        public JsonShortDotDateConverter()
        {
            DateTimeFormat = "yyyy-MM-dd";
        }
    }
}
