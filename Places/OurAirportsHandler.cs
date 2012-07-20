using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;

namespace Places
{
    /// <summary>
    /// handler for OurAirports files loading
    /// </summary>
    internal class OurAirportsHandler
    {
        // defaults
        private const string SpanishLangugeCode = "es";

        // file paths
        private readonly string _ourAirportsCountriesFilePath =
            ConfigurationManager.AppSettings["OurAirports_CountriesPath"];
        private readonly string _ourAirportsRegionsFilePath =
            ConfigurationManager.AppSettings["OurAirports_RegionsPath"];
        private readonly string _ourAirportsAirportsFilePath =
            ConfigurationManager.AppSettings["OurAirports_AirportsPath"];

        // MaxMind hanlder
        private readonly MaxMindHandler _maxMindHandler = new MaxMindHandler();

        /// <summary>
        /// get Countries with their Regions and Airports from OurAirports files
        /// </summary>
        /// <returns>Country list</returns>
        internal List<Country> GetCountries()
        {
            // get data from OurAirports
            var ourAirportsCountries = OurAirportsData.Data.GetCountries(_ourAirportsCountriesFilePath).ToList();
            var ourAirportsRegions = OurAirportsData.Data.GetRegions(_ourAirportsRegionsFilePath).ToList();
            var ourAirportsAirports = OurAirportsData.Data.GetAirports(_ourAirportsAirportsFilePath)
                .Where(model => model.ScheduledService == "yes").ToList();

            // build Countries list
            var countries = BuildCountries(ourAirportsCountries);

            // add Regions to their Country
            AddRegionsToCountries(ourAirportsRegions, ref countries);

            // add Airports to their Region
            AddAirportsToCountryRegions(ourAirportsAirports, ref countries);

            return countries;
        }

        /// <summary>
        /// add Regions to their Country
        /// </summary>
        /// <param name="ourAirportsRegions">OurAirports regions</param>
        /// <param name="countries">Country list</param>
        private void AddRegionsToCountries(List<OurAirportsData.Region> ourAirportsRegions,
            ref List<Country> countries)
        {
            foreach (var country in countries)
            {
                var ourAirportsCountryRegions = ourAirportsRegions
                    .Where(model => country.Code == model.CountryIso);

                var regions = ourAirportsCountryRegions.Select(model => BuildRegion(model, country.Continent, country.Code));
                foreach (var region in regions)
                {
                    region.Country = country;
                    country.Regions.Add(region);
                }
            }
        }

        /// <summary>
        /// add Airports to their Region
        /// </summary>
        /// <param name="ourAirportsAirports">OurAirports airports</param>
        /// <param name="countries">Country list</param>
        private void AddAirportsToCountryRegions(List<OurAirportsData.Airport> ourAirportsAirports,
            ref List<Country> countries)
        {
            var regions = countries.SelectMany(model => model.Regions).ToList();
            foreach (var region in regions)
            {
                var ourAirportsRegionAirports = ourAirportsAirports
                    .Where(model => region.Code == model.RegionIso && region.Country.Code == model.CountryIso);

                foreach (var airport in ourAirportsRegionAirports.Select(BuildAirport))
                {
                    airport.Region = region;
                    region.Airports.Add(airport);
                }
            }
        }

        /// <summary>
        /// build an Airport
        /// </summary>
        /// <param name="ourAirportsRegionAirport">OurAirports airport</param>
        /// <returns>the Airport</returns>
        private Airport BuildAirport(OurAirportsData.Airport ourAirportsRegionAirport)
        {
            var airport = new Airport
                {
                    Elevation = ourAirportsRegionAirport.Elevation,
                    GpsCode = ourAirportsRegionAirport.GpsCode,
                    HomeLink = ourAirportsRegionAirport.HomeLink,
                    IataCode = ourAirportsRegionAirport.IataCode,
                    Ident = ourAirportsRegionAirport.Ident,
                    Latitude = ourAirportsRegionAirport.Latitude,
                    LocalCode = ourAirportsRegionAirport.LocalCode,
                    Longitude = ourAirportsRegionAirport.Longitude,
                    Municipality = ourAirportsRegionAirport.Municipality,
                    MunicipalityEs = _maxMindHandler.GetCityName(ourAirportsRegionAirport.Municipality, SpanishLangugeCode),
                    Name = ourAirportsRegionAirport.Name,
                    ScheduledService = ourAirportsRegionAirport.ScheduledService == "yes",
                    Type = ourAirportsRegionAirport.Type,
                    WikipediaLink = ourAirportsRegionAirport.WikipediaLink
                };
            return airport;
        }

        /// <summary>
        /// build a Region
        /// </summary>
        /// <param name="ourAirportsCountryRegion">>OurAirports region</param>
        /// <param name="continent">the continent code</param>
        /// <param name="countryCode">the Country code</param>
        /// <returns>the Region</returns>
        private Region BuildRegion(OurAirportsData.Region ourAirportsCountryRegion,
            string continent, string countryCode)
        {
            var region = new Region
            {
                Code = ourAirportsCountryRegion.Code,
                LocalCode = ourAirportsCountryRegion.LocalCode,
                Name = ourAirportsCountryRegion.Name,
                NameEs = continent == "NA" ?
                    _maxMindHandler.GetNorthAmericaRegionName(countryCode, ourAirportsCountryRegion.LocalCode, SpanishLangugeCode) :
                    _maxMindHandler.GetNonNorthAmericaRegionName(countryCode, ourAirportsCountryRegion.Name, SpanishLangugeCode),
                WikipediaLink = ourAirportsCountryRegion.WikipediaLink,
                Airports = new Collection<Airport>()
            };
            return region;
        }

        /// <summary>
        /// build a Countries list
        /// </summary>
        /// <param name="ourAirportsCountries">OurAirports airports</param>
        /// <returns>Airport list</returns>
        private List<Country> BuildCountries(
            IEnumerable<OurAirportsData.Country> ourAirportsCountries)
        {
            var countries = ourAirportsCountries
                .Select(model => new Country
                    {
                        Code = model.Code,
                        Continent = model.Continent,
                        Name = model.Name,
                        NameEs = _maxMindHandler.GetCountryName(model.Code, SpanishLangugeCode),
                        WikipediaLink = model.WikipediaLink,
                        Regions = new Collection<Region>()
                    })
                .ToList();
            return countries;
        }
    }
}