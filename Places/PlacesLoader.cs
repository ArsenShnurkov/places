using System.Data.Entity;

namespace Places
{
    class PlacesLoader
    {
        internal static void Start()
        {
            // drop and re-create the database
            Database.SetInitializer(new DropCreateDatabaseAlways<Context>());

            // load places from OurAirports
            OurAirportsLoader.LoadPlaces();

            // sets places names
            MaxMindLoader.SetPlacesNames();
        }
    }
}
