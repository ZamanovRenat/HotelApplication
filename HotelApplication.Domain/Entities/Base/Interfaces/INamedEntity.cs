namespace HotelApplication.Domain.Entities.Base.Interfaces
{
    public interface INamedEntity : IEntity
    {
        public string Name { get; }
    }
}
