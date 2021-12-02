using System;
using System.Collections.Generic;
using System.Linq;
using HotelApplication.Models;
using HotelApplication.Services.Interfaces;

namespace HotelApplication.Services
{
    public class InMemoryRoomsData : IRoomsData
    {
        private static readonly List<Room> _rooms = new()
        {
            new Room() { Id = 1, Capacity = 2, Comfort = "Luxe", Price = 1000 },
        };

        private int _currentMaxId;

        public InMemoryRoomsData()
        {
            _currentMaxId = _rooms.Max(i => i.Id);
        }

        public IEnumerable<Room> GetAll() => _rooms;

        public Room Get(int id) => _rooms.SingleOrDefault(room => room.Id == id);

        public int Add(Room room)
        {
            if (room is null) throw new ArgumentNullException(nameof(room));

            if (_rooms.Contains(room)) return room.Id;

            room.Id = ++_currentMaxId;
            _rooms.Add(room);

            return room.Id;
        }

        public void Update(Room room)
        {
            if (room is null) throw new ArgumentNullException(nameof(room));

            if(_rooms.Contains(room)) return;

            var db_item = Get(room.Id);

            if (db_item is null) return;

            db_item.Id = room.Id;
            db_item.Capacity = room.Capacity;
            db_item.Comfort = room.Comfort;
            db_item.Price = room.Price;
        }

        public bool Delete(int id)
        {
            var db_item = Get(id);
            if (db_item is null) return false;
            return _rooms.Remove(db_item);
        }
    }
}
