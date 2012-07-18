using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.Entity;
using System.Linq;

namespace Places
{
    internal static class PlacesLoader
    {
        internal static void Start()
        {
            // drop and re-create the database
            Database.SetInitializer<Context>(new DropCreateDatabaseAlways<Context>());

            // get data from OurAirports
            var ourAirportsCountriesFilePath = ConfigurationManager.AppSettings["OurAirports_CountriesPath"];
            var ourAirportsCountries = OurAirportsData.Data.GetCountries(ourAirportsCountriesFilePath);
            var ourAirportsRegionsFilePath = ConfigurationManager.AppSettings["OurAirports_RegionsPath"];
            var ourAirportsRegions = OurAirportsData.Data.GetRegions(ourAirportsRegionsFilePath);

            // build countries list
            var countries = ourAirportsCountries
                .Select(ourAirportsCountry => new Country
                    {
                        Code = ourAirportsCountry.Code,
                        Continent = ourAirportsCountry.Continent,
                        Name = ourAirportsCountry.Name,
                        WikipediaLink = ourAirportsCountry.WikipediaLink,
                        Regions = new Collection<Region>()
                    }).ToList();

            // add regions to their countries
            foreach (var ourAirportsRegion in ourAirportsRegions)
            {
                var region = new Region
                    {
                        Code = ourAirportsRegion.Code,
                        LocalCode = ourAirportsRegion.LocalCode,
                        Name = ourAirportsRegion.Name,
                        WikipediaLink = ourAirportsRegion.WikipediaLink
                    };
                countries.Single(model => model.Code.Equals(ourAirportsRegion.CountryIso)).Regions.Add(region);
            }

            // add stuff to db
            using (var db = new Context())
            {
                foreach (var country in countries)
                {
                    db.Countries.Add(country);
                }
                db.SaveChanges();
                Console.WriteLine("Saved places to the database.");
            }
        }
    }
}