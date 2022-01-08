using System;
using DataAccessLibrary;
using DataAccessLibrary.Models;
using System.Threading;
using System.Linq;

namespace BikeRentConsoleTest
{
    internal class Program
    {
        static void Main(string [] args)
        {
            //ListAllTypes();
            //ListAllBikes();

            //Thread.Sleep(1000);

            ////AddBikes();

            //Thread.Sleep(1000);

            //RentBike(32);
            //RentBike(34);


            //ListAllBikes();

            //CancelBikeRent(32);
            //CancelBikeRent(34);


            Console.WriteLine("Done!");
        }

        //private static void CancelBikeRent(int id)
        //{
        //    Console.WriteLine("Cancelling rent for bike with id "+ id);
        //    EFCrud.CancelRent(id);
        //}

        //static void ListAllTypes()
        //{
        //    Console.WriteLine("All types: ----");

        //    foreach (var b in EFCrud.GetAllBicycleTypes())
        //    {
        //        Console.WriteLine($"{b.Id} {b.Name}");
        //    }
        //}

        //static void ListAllBikes()
        //{
        //    Console.WriteLine("All the bikes: ");
        //    foreach (var b in EFCrud.GetAllBicycles())
        //    {
        //        Console.WriteLine($"{b.Id} {b.Name} {b.BicycleType.Name} {b.RentPrice}. is Rented: {b.IsRented}");
        //    }
        //}
        //static void AddBikes()
        //{
        //    Console.WriteLine("adding bikes");

        //    var bicycleTypes = EFCrud.GetAllBicycleTypes();
        //    BicycleType racingType = bicycleTypes.Find(x=>x.Name == "Racing");
        //    BicycleType mountainType = bicycleTypes.Find(x => x.Name == "Mountain");

        //    Bicycle racingBycicle1 = new Bicycle()
        //    {
        //        Name = "MySuperBike",
        //        IsRented = false,
        //        RentPrice = 14m,
        //        BicycleType = racingType
        //    };

        //    Bicycle mountainBicycle1 = new Bicycle()
        //    {
        //        Name = "AwesomeBIke",
        //        IsRented = false,
        //        RentPrice = 15m,
        //        BicycleType = mountainType
        //    };

        //    Bicycle mountainBicycle2 = new Bicycle()
        //    {
        //        Name = "Very good bike",
        //        IsRented = false,
        //        RentPrice = 11m,
        //        BicycleType = mountainType
        //    };

        //    Bicycle racingBicycle2 = new Bicycle()
        //    {
        //        Name = "MyMegaBike",
        //        IsRented = false,
        //        RentPrice = 20m,
        //        BicycleType = racingType
        //    };

        //    EFCrud.AddBicycle(racingBycicle1);
        //    EFCrud.AddBicycle(racingBicycle2);
        //    EFCrud.AddBicycle(mountainBicycle1);
        //    EFCrud.AddBicycle(mountainBicycle2);


        //}

        //static void RentBike(int id)
        //{
        //    EFCrud.Rent(id);
        //    Console.WriteLine($"Bike with id {id} is rented.");
        //}
    }
}
