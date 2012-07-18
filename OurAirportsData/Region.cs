using FileHelpers;

namespace OurAirportsData
{
    /// <summary>
    /// this class maps the "regions.csv" file found at 
    /// http://www.ourairports.com/data/ using FileHelpers
    /// </summary>
    [DelimitedRecord(",")]
    [IgnoreFirst(1)]
    [IgnoreEmptyLines]
    public class Region
    {
        public int Id;
        [FieldQuoted]
        public string Code;
        [FieldQuoted(QuoteMode.OptionalForBoth)]
        public string LocalCode;
        [FieldQuoted]
        public string Name;
        [FieldQuoted]
        public string Continent;
        [FieldQuoted]
        public string CountryIso;
        [FieldQuoted]
        public string WikipediaLink;
        [FieldQuoted]
        public string Keywords;
    }
}