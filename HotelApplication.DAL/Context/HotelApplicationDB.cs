using HotelApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelApplication.DAL.Context
{
    public class HotelApplicationDB : DbContext
    {
        public DbSet<Checkin> Checkins { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public HotelApplicationDB(DbContextOptions<HotelApplicationDB> options) : base(options) { }
    }
}
