using Newtonsoft.Json.Converters;

namespace EcoJardimPro.Util.Converters
{
    public class OnlyDateConverter : IsoDateTimeConverter
    {
        public OnlyDateConverter()
        {
            base.DateTimeFormat = "yyyy-MM-dd";
        }
    }
}
