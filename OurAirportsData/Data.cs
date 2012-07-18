using System.Collections.Generic;
using FileHelpers;

namespace OurAirportsData
{
    /// <summary>
    /// gets the data form the OurAirports files
    /// </summary>
    public static class Data
    {
        /// <summary>
        /// gets the countries from the OurAirports file
        /// </summary>
        /// <returns>countries list</returns>
        public static IEnumerable<Country> GetCountries(string filePath)
        {
            var engine = new FileHelperEngine(typeof (Country));
            var countries = engine.ReadFile(filePath) as IEnumerable<Country>;
            return countries;
        }

        /// <summary>
        /// gets the regions from the OurAirports file
        /// </summary>
        /// <returns>regions list</returns>
        public static IEnumerable<Region> GetRegions(string filePath)
        {
            var engine = new FileHelperEngine(typeof (Region));
            var regions = engine.ReadFile(filePath) as IEnumerable<Region>;
            return regions;
        }

        /// <summary>
        /// gets the airports from the OurAirports file
        /// </summary>
        /// <returns>airports list</returns>
        public static IEnumerable<Airport> GetAirports(string filePath)
        {
            var engine = new FileHelperEngine(typeof (Airport));
            var airports = engine.ReadFile(filePath) as IEnumerable<Airport>;
            return airports;
        }
    }
}