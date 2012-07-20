using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Places
{
    internal class PlacesLoader
    {
        /// <summary>
        /// generates a database with Countries, Regions and Airports
        /// </summary>
        internal static void GeneratePlacesDataBase()
        {
            // drop and re-create the database
            Database.SetInitializer(new DropCreateDatabaseAlways<Context>());

            // gets and saves Countries
            var ourAirportsHandler = new OurAirportsHandler();
            var countries = ourAirportsHandler.GetCountries();
            SaveCountries(countries);
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
            Console.WriteLine("All countries have been added.");
        }
    }
}
