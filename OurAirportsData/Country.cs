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
        [FieldQuoted] public string Code;
        [FieldQuoted] public string Continent;
        public int Id;
        [FieldQuoted] public string Keywords;
        [FieldQuoted] public string Name;
        [FieldQuoted] public string WikipediaLink;
    }
}