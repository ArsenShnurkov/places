﻿using System.Configuration;
using MaxMindData;
using Xunit;

namespace Test
{
    public class OurAirportsData
    {
        [Fact]
        public void NonNorthAmericaRegionsNotEmpty()
        {
            var filePath = ConfigurationManager.AppSettings["MaxMind_NonNorthAmericaRegionsPath"];
            var regions = Data.GetNonNorthAmericaRegionNames(filePath);
            Assert.NotEmpty(regions);
        }

        [Fact]
        public void NorthAmericaRegionsNotEmpty()
        {
            var filePath = ConfigurationManager.AppSettings["MaxMind_NorthAmericaRegionsPath"];
            var regions = Data.GetNorthAmericaRegionNames(filePath);
            Assert.NotEmpty(regions);
        }

        [Fact]
        public void CitiesNamesNotEmpty()
        {
            var filePath = ConfigurationManager.AppSettings["MaxMind_CitiesPath"];
            var cities = Data.GetCityNames(filePath);
            Assert.NotEmpty(cities);
        }
    }
}