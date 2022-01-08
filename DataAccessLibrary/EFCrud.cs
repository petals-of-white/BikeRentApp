using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLibrary
{
    public class EFCrud
    {
        public static void CreateSampleData()
        {
            Console.WriteLine("Creating sample bikes...");
            using (var db = new BicycleContext())
            {
                db.Bicycles.Add(new Bicycle
                {
                    Name = "SuperBike",
                    IsRented = false,
                    BicycleType = new BicycleType { Name = "Mountain" },
                    RentPrice = 12.99m
                });
                db.Bicycles.Add(new Bicycle
                {
                    Name = "SuperBike",
                    IsRented = false,
                    BicycleType = new BicycleType { Name = "Racing" },
                    RentPrice = 12.99m
                });
                db.SaveChanges();
            }
        }

        public static List<Bicycle> GetAllBicycles()
        {
            using (var db = new BicycleContext())
            {
                return db.Bicycles.ToList();
            }
        }

        public static Bicycle GetBycicle(int id)
        {
            using (var db = new BicycleContext())
            {
                return db.Bicycles.Find(id);
            }
        }

        public static void AddBicycle(Bicycle bicycle)
        {
            using (var db = new BicycleContext())
            {
                db.Bicycles.Add(bicycle);
                db.SaveChanges();
            }
        }

        public static void RemoveBicycle(int id)
        {
            using (var db = new BicycleContext())
            {
                Bicycle bicycle = db.Bicycles.Where(b => b.Id == id)
                    .Include(b => b.BicycleType)
                    .FirstOrDefault();
                var bycicles = db.Bicycles.Remove(bicycle);
                db.SaveChanges();
            }
        }

        public static void Rent(int id)
        {
            using (var db = new BicycleContext())
            {
                //how does this work???
                var bicycle = db.Bicycles.Find(id);
                bicycle.IsRented = true;
                db.SaveChanges();
            }
        }

        public static void CancelRent(int id)
        {
            using (var db = new BicycleContext())
            {
                //how does this work??? 
                var bicycle = db.Bicycles.Find(id);
                bicycle.IsRented = false;
                db.SaveChanges();
            }
        }

        public static List<BicycleType> GetAllBicycleTypes()
        {
            using (var db = new BicycleContext())
            {
                var types = db.BicycleTypes.ToList();
                return types;
            }
        }

    }
}
