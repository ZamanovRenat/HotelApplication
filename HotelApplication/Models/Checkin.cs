using System;

namespace HotelApplication.Models
{
    public class Checkin
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public Room Room { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string Notes { get; set; }
    }
}
