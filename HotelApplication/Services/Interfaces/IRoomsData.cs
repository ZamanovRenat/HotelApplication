using System.Collections.Generic;
using HotelApplication.Models;

namespace HotelApplication.Services.Interfaces
{
    public interface IRoomsData
    {
        IEnumerable<Room> GetAll();
        Room Get(int id);
        int Add(Room room);
        void Update(Room room);
        bool Delete(int id);
    }
}
