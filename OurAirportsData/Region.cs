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
        [FieldQuoted] public string Code;
        [FieldQuoted] public string Continent;
        public int Id;
        [FieldQuoted] public string IsoCountry;
        [FieldQuoted] public string Keywords;
        [FieldQuoted] public string LocalCode;
        [FieldQuoted] public string Name;
        [FieldQuoted] public string WikipediaLink;
    }
}