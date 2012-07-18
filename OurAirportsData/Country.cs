using FileHelpers;

namespace OurAirportsData
{
    /// <summary>
    /// this class maps the "countries.csv" file found at 
    /// http://www.ourairports.com/data/ using FileHelpers
    /// </summary>
    [DelimitedRecord(",")]
    [IgnoreFirst(1)]
    [IgnoreEmptyLines]
    public class Country
    {
        public int Id;
        [FieldQuoted]
        public string Code;
        [FieldQuoted]
        public string Name;
        [FieldQuoted]
        public string Continent;
        [FieldQuoted]
        public string WikipediaLink;
        [FieldQuoted]
        public string Keywords;
    }
}