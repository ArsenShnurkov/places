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
        public int Id;
        [FieldQuoted]
        public string Ident;
        [FieldQuoted]
        public string Type;
        [FieldQuoted]
        public string Name;
        [FieldQuoted(QuoteMode.OptionalForBoth)]
        public double Latitude;
        [FieldQuoted(QuoteMode.OptionalForBoth)]
        public double Longitude;
        public int? Elevation;
        [FieldQuoted]
        public string Continent;
        [FieldQuoted]
        public string CountryIso;
        [FieldQuoted]
        public string RegionIso;
        [FieldQuoted]
        public string Municipality;
        [FieldQuoted]
        public string ScheduledService;
        [FieldQuoted]
        public string GpsCode;
        [FieldQuoted]
        public string IataCode;
        [FieldQuoted]
        public string LocalCode;
        [FieldQuoted]
        public string HomeLink;
        [FieldQuoted]
        public string WikipediaLink;
        [FieldQuoted]
        public string Keywords;
    }
}