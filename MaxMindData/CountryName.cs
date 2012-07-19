using FileHelpers;

namespace MaxMindData
{
    /// <summary>
    /// this class maps the "iso-3166-localized.csv" file found at
    /// http://www.maxmind.com/app/faq#localization using Filehelpers
    /// </summary>
    [DelimitedRecord(",")]
    [IgnoreEmptyLines]
    public class CountryName
    {
        public string CountryCode;
        public string LanguageCode;
        [FieldQuoted(QuoteMode.OptionalForBoth)]
        public string LocalizedCountryName;
        public int GeonamesId;
    }
}