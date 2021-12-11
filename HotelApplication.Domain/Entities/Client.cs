namespace HotelApplication.Domain.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string PassportData { get; set; }
        public string Notes { get; set; }
    }
}
