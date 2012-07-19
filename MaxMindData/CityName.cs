using FileHelpers;

namespace MaxMindData
{
    /// <summary>
    /// this class maps the "GeoIPCity-localized.csv" file found at
    /// http://www.maxmind.com/app/faq#localization using Filehelpers
    /// </summary>
    [DelimitedRecord(",")]
    [IgnoreFirst(2)]
    [IgnoreEmptyLines]
    public class CityName
    {
        public int MaxMindId;
        public string LanguageCode;
        [FieldQuoted(QuoteMode.OptionalForBoth)]
        public string LocalName;
        public int GeonamesId;
    }
}
