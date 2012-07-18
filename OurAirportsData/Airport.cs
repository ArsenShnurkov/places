using FileHelpers;

namespace OurAirportsData
{
    /// <summary>
    /// this class maps the "airports.csv" file found at 
    /// http://www.ourairports.com/data/ using FileHelpers
    /// </summary>
    [DelimitedRecord(",")]
    [IgnoreFirst(1)]
    [IgnoreEmptyLines]
    public class Airport
    {
        [FieldQuoted] public string Continent;
        [FieldQuoted] public string CountryIso;
        public int? Elevation;
        [FieldQuoted] public string GpsCode;
        [FieldQuoted] public string HomeLink;
        [FieldQuoted] public string IataCode;
        public int Id;
        [FieldQuoted] public string Ident;
        [FieldQuoted] public string Keywords;
        [FieldQuoted] public double Latitude;
        [FieldQuoted] public string LocalCode;
        public double Longitude;
        [FieldQuoted] public string Municipality;
        [FieldQuoted] public string Name;
        [FieldQuoted] public string RegionIso;
        [FieldQuoted] public string ScheduledService;
        [FieldQuoted] public string Type;
        [FieldQuoted] public string WikipediaLink;
    }
}