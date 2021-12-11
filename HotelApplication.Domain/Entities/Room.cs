namespace HotelApplication.Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public string Comfort { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
