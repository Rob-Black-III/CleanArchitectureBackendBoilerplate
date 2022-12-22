namespace CleanArchitectureBoilerplate.Contracts.Products
{
    public class ProductResponse
    {
        public Guid Id { get; private set; }
        public string PartNumber { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public int? Stock { get; private set; }
        public decimal? Price { get; private set; }
        public decimal? Weight { get; private set; }
    }
}