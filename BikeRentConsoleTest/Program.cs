using System;
using DataAccessLibrary;
using DataAccessLibrary.Models;
namespace BikeRentConsoleTest
{
    internal class Program
    {
        static void Main(string [] args)
        {

            BicycleType mountainType = new BicycleType()
            {
                Name = "Mountain"
            };

            BicycleType racingType = new BicycleType()
            {
                Name = "Racing"
            };

            Bicycle racingBycicle1 = new Bicycle()
            {
                Name = "MyMegaBike",
                IsRented = false,
                RentPrice = 14m,
                BicycleType = racingType
            };

            Bicycle mountainBicycle1 = new Bicycle()
            {
                Name = "AwesomeBIke",
                IsRented = false,
                RentPrice = 15m,
                BicycleType = mountainType
            };

            Bicycle mountainBicycle2 = new Bicycle()
            {
                Name = "Very good bike",
                IsRented = false,
                RentPrice = 11m,
                BicycleType = mountainType
            };

            Bicycle racingBicycle2 = new Bicycle()
            {
                Name = "MyMegaBike",
                IsRented = false,
                RentPrice = 20m,
                BicycleType = racingType
            };

            EFCrud.AddBicycle(racingBycicle1);
            EFCrud.AddBicycle(racingBicycle2);
            EFCrud.AddBicycle(mountainBicycle1);
            EFCrud.AddBicycle(mountainBicycle1);

            Console.WriteLine("Done!");
        }
    }
}
