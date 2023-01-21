using CleanArchitectureBoilerplate.Domain.Common;

namespace CleanArchitectureBoilerplate.Domain.Entities
{
    public class Product : Entity, IAggregateRoot
    {
        public const int MinNameLength = 3;
        public const int MaxNameLength = 50;

        public const int MinDescriptionLength = 50;
        public const int MaxDescriptionLength = 150;


        //public Guid Id { get; private set; }
        public string? PartNumber { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public int? Stock { get; private set; }
        public decimal? Price { get; private set; }
        public decimal? Weight { get; private set; }


        // May be used by EF Core
        // Had to make public for Mapster? TODO fix, don't want people instantiating it like this.
        public Product() {}

        private Product(Guid id, string partNumber, string name, string description, int stock, decimal price, decimal weight)
        {
            this.Id = id;
            this.PartNumber = partNumber;
            this.Name = name;
            this.Description = description;
            this.Stock = stock;
            this.Price = price;
            this.Weight = weight;
        }
    }
}