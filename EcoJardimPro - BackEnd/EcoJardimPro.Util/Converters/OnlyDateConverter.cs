using Newtonsoft.Json.Converters;

namespace EcoJardimPro.UTIL.Converters
{
    public class OnlyDateConverter : IsoDateTimeConverter
    {
        public OnlyDateConverter()
        {
            base.DateTimeFormat = "yyyy-MM-dd";
        }
    }
}
