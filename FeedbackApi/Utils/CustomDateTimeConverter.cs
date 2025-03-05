using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace FeedbackApi.Utils
{
    public class CustomDateTimeConverter : IsoDateTimeConverter
    {
        public CustomDateTimeConverter()
        {
            DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        }

        public CustomDateTimeConverter(string format)
        {
            DateTimeFormat = format;
        }
    }
}
