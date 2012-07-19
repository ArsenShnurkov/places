﻿using System.Collections.Generic;
using FileHelpers;

namespace MaxMindData
{
    /// <summary>
    /// gets the data from the MaxMind files
    /// </summary>
    public static class Data
    {
        /// <summary>
        /// gets the CountryNames from the MaxMind file
        /// </summary>
        /// <param name="filePath">the file path</param>
        /// <returns>CountryName list</returns>
        public static IEnumerable<CountryName> GetCountryNames(string filePath)
        {
            var engine = new FileHelperEngine(typeof(CountryName));
            var countryNames = engine.ReadFile(filePath) as IEnumerable<CountryName>;
            return countryNames;
        }

        /// <summary>
        /// gets the NonNorthAmericaRegionName from the MaxMind file
        /// </summary>
        /// <param name="filePath">the file path</param>
        /// <returns>NonNorthAmericaRegionName list</returns>
        public static IEnumerable<NonNorthAmericaRegionName> GetNonNorthAmericaRegionNames(string filePath)
        {
            var engine = new FileHelperEngine(typeof(NonNorthAmericaRegionName));
            var regionNames = engine.ReadFile(filePath) as IEnumerable<NonNorthAmericaRegionName>;
            return regionNames;
        }

        /// <summary>
        /// gets the NorthAmericaRegionNames from the MaxMind file
        /// </summary>
        /// <param name="filePath">the file path</param>
        /// <returns>NorthAmericaRegionName list</returns>
        public static IEnumerable<NorthAmericaRegionName> GetNorthAmericaRegionNames(string filePath)
        {
            var engine = new FileHelperEngine(typeof(NorthAmericaRegionName));
            var regionNames = engine.ReadFile(filePath) as IEnumerable<NorthAmericaRegionName>;
            return regionNames;
        }

        /// <summary>
        /// gets the CityNames from the MaxMind file
        /// </summary>
        /// <param name="filePath">the file path</param>
        /// <returns>CityNames list</returns>
        public static IEnumerable<CityName> GetCityNames(string filePath)
        {
            var engine = new FileHelperEngine(typeof(CityName));
            var cityNames = engine.ReadFile(filePath) as IEnumerable<CityName>;
            return cityNames;
        }
    }
}
