using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApplication.Domain.Entities;

namespace HotelApplication.Data
{
    public class TestData
    {
        public static IEnumerable<Room> Rooms { get; } = new[]
        {
            new Room()
            {
                Id = 1, 
                Capacity = 2, 
                Comfort = "Luxe", 
                ImageUrl = "Room1.jpg", 
                Price = 1050
            },
            new Room()
            {
                Id = 2, 
                Capacity = 2, 
                Comfort = "HalfLuxe", 
                ImageUrl = "Room2.jpg", 
                Price = 1050
            },
            new Room()
            {
                Id = 3, 
                Capacity = 2, 
                Comfort = "Ordinary", 
                ImageUrl = "Room3.jpg", 
                Price = 1050
            },
        };

        public static IEnumerable<Client> Clients { get; } = new[]
        {
            new Client()
            {
                Id = 1, 
                LastName = "Ivanov", 
                FirstName = "Ivan", 
                Patronymic = "Ivanovich", 
                Notes = "No Smoking", 
                PassportData = "Russian"
            },
            new Client()
            {
                Id = 2,
                LastName = "Petrov",
                FirstName = "Petr",
                Patronymic = "Petrovich",
                Notes = "No Smoking",
                PassportData = "Russian"
            },
            new Client()
            {
                Id = 3,
                LastName = "Sidorov",
                FirstName = "Aleksanrd",
                Patronymic = "Stepanovich",
                Notes = "Smoking",
                PassportData = "Russian"
            },
        };

        public static IEnumerable<Checkin> Checkins { get; } = new[]
        {
            new Checkin()
            {
                Id = 1, 
                ClientId = 1, 
                RoomId = 1, 
                CheckIn = new DateTime(2021, 12, 12,12, 00, 00), 
                CheckOut = new DateTime(2021, 12, 13,12, 00, 00),
                Notes = "Do Not Disturb"
            },
            new Checkin()
            {
                Id = 2,
                ClientId = 2,
                RoomId = 2,
                CheckIn = new DateTime(2021, 12, 12,12, 00, 00),
                CheckOut = new DateTime(2021, 12, 13,12, 00, 00),
                Notes = "Do Not Disturb"
            },
            new Checkin()
            {
                Id = 3,
                ClientId = 3,
                RoomId = 3,
                CheckIn = new DateTime(2021, 12, 12,12, 00, 00),
                CheckOut = new DateTime(2021, 12, 13,12, 00, 00),
                Notes = "Do Not Disturb"
            },
        };
    }
}
