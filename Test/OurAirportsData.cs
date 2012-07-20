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
            var filePath = ConfigurationManager.AppSettings["OurAirports_CountriesPath"];
            var countries = Data.GetCountries(filePath);
            Assert.NotEmpty(countries);
        }

        [Fact]
        public void RegionsNotEmpty()
        {
            var filePath = ConfigurationManager.AppSettings["OurAirports_RegionsPath"];
            var regions = Data.GetRegions(filePath);
            Assert.NotEmpty(regions);
        }

        [Fact]
        public void AirportsNotEmpty()
        {
            var filePath = ConfigurationManager.AppSettings["OurAirports_AirportsPath"];
            var airports = Data.GetAirports(filePath);
            Assert.NotEmpty(airports);
        }
    }
}