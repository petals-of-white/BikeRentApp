using System.Collections.Generic;
using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface IBicycleCrud
    {
        void AddBicycle(Bicycle bicycle);
        void CancelRent(int id);
        List<Bicycle> GetAllBicycles();
        List<BicycleType> GetAllBicycleTypes();
        Bicycle GetBicycle(int id);
        void RemoveBicycle(int id);
        void Rent(Bicycle bicycle);
        void Rent(int id);
    }
}