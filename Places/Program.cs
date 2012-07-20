using System;
namespace Places
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            PlacesLoader.GeneratePlacesDataBase();
            Console.ReadKey();
        }
    }
}