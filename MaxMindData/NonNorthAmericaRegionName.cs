using FileHelpers;

namespace MaxMindData
{
    /// <summary>
    /// this class maps the "fips10-4-localized.csv" file found at
    /// http://www.maxmind.com/app/faq#localization using Filehelpers
    /// </summary>
    [DelimitedRecord(",")]
    [IgnoreEmptyLines]
    public class NonNorthAmericaRegionName
    {
        public string CountryCode;
        public string FipsRegionCode;
        public string LanguageCode;
        [FieldQuoted(QuoteMode.OptionalForBoth)]
        public string LocalizedRegionName;
        public int GeonamesId;
    }
}