using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;

namespace Places
{
    /// <summary>
    /// handler for OurAirports files loading
    /// </summary>
    internal static class OurAirportsLoader
    {
        /// <summary>
        /// loads Countries, Regions and Airports from OurAirports files
        /// </summary>
        internal static void LoadPlaces()
        {
            // get data from OurAirports.com
            var ourAirportsCountriesFilePath = ConfigurationManager.AppSettings["OurAirports_CountriesPath"];
            var ourAirportsCountries = OurAirportsData.Data.GetCountries(ourAirportsCountriesFilePath).ToList();
            var ourAirportsRegionsFilePath = ConfigurationManager.AppSettings["OurAirports_RegionsPath"];
            var ourAirportsRegions = OurAirportsData.Data.GetRegions(ourAirportsRegionsFilePath).ToList();
            var ourAirportsAirportsFilePath = ConfigurationManager.AppSettings["OurAirports_AirportsPath"];
            var ourAirportsAirports = OurAirportsData.Data.GetAirports(ourAirportsAirportsFilePath).ToList();

            // build Countries list
            var countries = BuildCountries(ourAirportsCountries);

            // add Regions to their Country
            AddRegionsToCountries(ourAirportsRegions, ref countries);

            // add Airports to their Region
            AddAirportsToCountryRegions(ourAirportsAirports, ref countries);

            // save Countries
            SaveCountries(countries);
        }

        /// <summary>
        /// add Regions to their Country
        /// </summary>
        /// <param name="ourAirportsRegions">OurAirports regions</param>
        /// <param name="countries">Countries list</param>
        private static void AddRegionsToCountries(List<OurAirportsData.Region> ourAirportsRegions,
            ref List<Country> countries)
        {
            foreach (var country in countries)
            {
                var ourAirportsCountryRegions = ourAirportsRegions
                    .Where(model => country.Code == model.CountryIso);

                foreach (var region in ourAirportsCountryRegions.Select(BuildRegion))
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
        /// <param name="countries">Countries list</param>
        private static void AddAirportsToCountryRegions(List<OurAirportsData.Airport> ourAirportsAirports,
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
        private static Airport BuildAirport(OurAirportsData.Airport ourAirportsRegionAirport)
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
                    Name = ourAirportsRegionAirport.Name,
                    ScheduledService = ourAirportsRegionAirport.ScheduledService == "yes" ? true : false,
                    Type = ourAirportsRegionAirport.Type,
                    WikipediaLink = ourAirportsRegionAirport.WikipediaLink
                };
            return airport;
        }

        /// <summary>
        /// build a Region
        /// </summary>
        /// <param name="ourAirportsCountryRegion">OurAirports region</param>
        /// <returns>the Region</returns>
        private static Region BuildRegion(OurAirportsData.Region ourAirportsCountryRegion)
        {
            var region = new Region
            {
                Code = ourAirportsCountryRegion.Code,
                LocalCode = ourAirportsCountryRegion.LocalCode,
                Name = ourAirportsCountryRegion.Name,
                WikipediaLink = ourAirportsCountryRegion.WikipediaLink,
                Airports = new Collection<Airport>()
            };
            return region;
        }

        /// <summary>
        /// build a Countries list
        /// </summary>
        /// <param name="ourAirportsCountries">OurAirports airports</param>
        /// <returns>Airports list</returns>
        private static List<Country> BuildCountries(
            IEnumerable<OurAirportsData.Country> ourAirportsCountries)
        {
            var countries = ourAirportsCountries
                .Select(model => new Country
                    {
                        Code = model.Code,
                        Continent = model.Continent,
                        Name = model.Name,
                        WikipediaLink = model.WikipediaLink,
                        Regions = new Collection<Region>()
                    })
                .ToList();
            return countries;
        }

        /// <summary>
        /// save Countries to database
        /// </summary>
        /// <param name="countries">Countries to save</param>
        private static void SaveCountries(IEnumerable<Country> countries)
        {
            using (var db = new Context())
            {
                foreach (var country in countries)
                {
                    db.Countries.Add(country);
                }
                db.SaveChanges();
            }
            Console.WriteLine("All places have been added");
        }
    }
}