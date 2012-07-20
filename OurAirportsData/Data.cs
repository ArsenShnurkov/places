using System.Collections.Generic;
using System.Text;
using FileHelpers;

namespace OurAirportsData
{
    /// <summary>
    /// gets the data from the OurAirports files
    /// </summary>
    public static class Data
    {
        /// <summary>
        /// gets the Countries from the OurAirports file
        /// </summary>
        /// <param name="filePath">the file path</param>
        /// <returns>Country list</returns>
        public static IEnumerable<Country> GetCountries(string filePath)
        {
            var engine = new FileHelperEngine(typeof(Country)) { Encoding = new UTF8Encoding() };
            var countries = engine.ReadFile(filePath) as IEnumerable<Country>;
            return countries;
        }

        /// <summary>
        /// gets the Regions from the OurAirports file
        /// </summary>
        /// <param name="filePath">the file path</param>
        /// <returns>Region list</returns>
        public static IEnumerable<Region> GetRegions(string filePath)
        {
            var engine = new FileHelperEngine(typeof(Region)) { Encoding = new UTF8Encoding() };
            var regions = engine.ReadFile(filePath) as IEnumerable<Region>;
            return regions;
        }

        /// <summary>
        /// gets the Airports from the OurAirports file
        /// </summary>
        /// <param name="filePath">the file path</param>
        /// <returns>Airport list</returns>
        public static IEnumerable<Airport> GetAirports(string filePath)
        {
            var engine = new FileHelperEngine(typeof(Airport)) { Encoding = new UTF8Encoding() };
            var airports = engine.ReadFile(filePath) as IEnumerable<Airport>;
            return airports;
        }
    }
}