using FileHelpers;

namespace MaxMindData
{
    /// <summary>
    /// this class maps the "iso-3166-2-localized.csv" file found at
    /// http://www.maxmind.com/app/faq#localization using Filehelpers
    /// </summary>
    [DelimitedRecord(",")]
    [IgnoreEmptyLines]
    public class NorthAmericaRegionName
    {
        public string CountryCode;
        public string RegionCode;
        public string LanguageCode;
        [FieldQuoted(QuoteMode.OptionalForBoth)]
        public string LocalizedRegionName;
        public int GeonamesId;
    }
}