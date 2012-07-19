using System;
namespace Places
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            PlacesLoader.LoadPlacesFromOurAirports();
            Console.ReadKey();
        }
    }
}