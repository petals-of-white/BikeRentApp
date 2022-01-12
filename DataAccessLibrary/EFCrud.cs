using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLibrary
{
    public class EFCrud : IBicycleCrud
    {
        public void CheckDbExists()
        {
            using(var db = new BicycleContext())
            {
                if (db.Database.EnsureCreated())
                {
                    CreateSampleData();
                }
            }
        }
        public static void CreateSampleData()
        {
            Console.WriteLine("Creating sample bikes...");
            using (var db = new BicycleContext())
            {
                BicycleType [] bikeTypes =
                {
                    new BicycleType {Name = "Road"},
                    new BicycleType {Name = "Touring"},
                    new BicycleType {Name = "City"},
                    new BicycleType {Name = "Shopping"},
                    new BicycleType {Name = "Mountain"},
                };

                db.BicycleTypes.AddRange(bikeTypes);

                db.SaveChanges();


                bikeTypes = db.BicycleTypes.ToArray();

                Bicycle [] bikes =
                {
                    new Bicycle
                    {
                        Name = "Road Fury",
                        RentPrice = 25m,
                        BicycleType = bikeTypes.Where(bt=>bt.Name == "Road").FirstOrDefault()
                    },

                    new Bicycle
                    {
                        Name = "Traveller 3000",
                        RentPrice = 24m,
                        BicycleType = bikeTypes.Where(bt=>bt.Name == "Touring").FirstOrDefault()
                    },

                    new Bicycle
                    {
                        Name = "The Urban Legend",
                        RentPrice = 35.22m,
                        BicycleType = bikeTypes.Where(bt=>bt.Name == "City").FirstOrDefault()
                    },

                    new Bicycle
                    {
                        Name = "Lovely Shop-Bike",
                        RentPrice = 18.88m,
                        BicycleType = bikeTypes.Where(bt=>bt.Name == "Shopping").FirstOrDefault()
                    },

                    new Bicycle
                    {
                        Name = "Mountain Ghost #1",
                        RentPrice = 12m,
                        BicycleType = bikeTypes.Where(bt=>bt.Name == "Mountain").FirstOrDefault()
                    }
                };

                db.Bicycles.AddRange(bikes);

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
