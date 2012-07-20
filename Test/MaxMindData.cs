using System.Configuration;
using MaxMindData;
using Xunit;

namespace Test
{
    public class MaxMindData
    {
        [Fact]
        public void CountryNamesNotEmpty()
        {
            var filePath = ConfigurationManager.AppSettings["MaxMind_CountriesPath"];
            var countries = Data.GetCountryNames(filePath);
            Assert.NotEmpty(countries);
        }

        [Fact]
        public void NonNorthAmericaRegionNamesNotEmpty()
        {
            var filePath = ConfigurationManager.AppSettings["MaxMind_NonNorthAmericaRegionsPath"];
            var regions = Data.GetNonNorthAmericaRegionNames(filePath);
            Assert.NotEmpty(regions);
        }

        [Fact]
        public void NorthAmericaRegionNamesNotEmpty()
        {
            var filePath = ConfigurationManager.AppSettings["MaxMind_NorthAmericaRegionsPath"];
            var regions = Data.GetNorthAmericaRegionNames(filePath);
            Assert.NotEmpty(regions);
        }

        [Fact]
        public void CityNamesNotEmpty()
        {
            var filePath = ConfigurationManager.AppSettings["MaxMind_CitiesPath"];
            var cities = Data.GetCityNames(filePath);
            Assert.NotEmpty(cities);
        }
    }
}
