using System;

namespace HotelApplication.Domain.Entities
{
    public class Checkin
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string Notes { get; set; }
    }
}
