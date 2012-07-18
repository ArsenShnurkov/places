using System.Collections.Generic;
using System.Configuration;
using OurAirportsData;
using Xunit;

namespace Test
{
    public class OurAirportsData
    {
        [Fact]
        public void CountriesNotEmpty()
        {
            string filePath = ConfigurationManager.AppSettings["OurAirports_CountriesPath"];
            IEnumerable<Country> countries = Data.GetCountries(filePath);
            Assert.NotEmpty(countries);
        }

        [Fact]
        public void RegionsNotEmpty()
        {
            string filePath = ConfigurationManager.AppSettings["OurAirports_RegionsPath"];
            IEnumerable<Region> regions = Data.GetRegions(filePath);
            Assert.NotEmpty(regions);
        }

        [Fact]
        public void AirportsNotEmpty()
        {
            string filePath = ConfigurationManager.AppSettings["OurAirports_AirportsPath"];
            IEnumerable<Airport> airports = Data.GetAirports(filePath);
            Assert.NotEmpty(airports);
        }
    }
}