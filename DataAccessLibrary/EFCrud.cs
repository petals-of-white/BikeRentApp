using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLibrary
{
    public class EFCrud : IBicycleCrud
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

        public List<Bicycle> GetAllBicycles()
        {
            using (var db = new BicycleContext())
            {
                List<Bicycle> output = (db.Bicycles
                    .Include(b => b.BicycleType)).ToList();
                return output;
            }
        }

        public Bicycle GetBicycle(int id)
        {
            using (var db = new BicycleContext())
            {
                return db.Bicycles.Find(id);
            }
        }

        public void AddBicycle(Bicycle bicycle)
        {
            using (var db = new BicycleContext())
            {
                bicycle.BicycleType = db.BicycleTypes.Where(b => b.Id == bicycle.BicycleType.Id).FirstOrDefault();
                db.Bicycles.Add(bicycle);
                db.SaveChanges();
            }
        }

        public void RemoveBicycle(int id)
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

        public void Rent(int id)
        {
            using (var db = new BicycleContext())
            {
                //how does this work???
                var bicycle = db.Bicycles.Find(id);
                bicycle.IsRented = true;
                db.SaveChanges();
            }
        }

        public void Rent(Bicycle bicycle)
        {
            using (var db = new BicycleContext())
            {
                //how does this work???
                db.Bicycles.Where(b => b.Id == bicycle.Id).FirstOrDefault().IsRented = true;
                db.SaveChanges();
            }
        }

        public void CancelRent(int id)
        {
            using (var db = new BicycleContext())
            {
                //how does this work??? 
                var bicycle = db.Bicycles.Find(id);
                bicycle.IsRented = false;
                db.SaveChanges();
            }
        }

        public List<BicycleType> GetAllBicycleTypes()
        {
            using (var db = new BicycleContext())
            {
                var types = db.BicycleTypes.ToList();
                return types;
            }
        }

    }
}
