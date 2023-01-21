namespace CleanArchitectureBoilerplate.Application.Products
{
    public record ProductAdd
    {
        public string? PartNumber { get; init; }
        public string Name { get; init; }
        public string? Description { get; init; }
        public int? Stock { get; init; }
        public decimal? Price { get; init; }
        public decimal? Weight { get; init; }
    }
    
    // Presentation Layer "Response"
    public record ProductResponse
    {
        public Guid Id { get; init; }
        public string? PartNumber { get; init; }
        public string Name { get; init; }
        public string? Description { get; init; }
        public int? Stock { get; init; }
        public decimal? Price { get; init; }
        public decimal? Weight { get; init; }
    }

    // Service Layer "Result".
    public record ProductResult
    {
        public Guid Id { get; init; }
        public string? PartNumber { get; init; }
        public string Name { get; init; }
        public string? Description { get; init; }
        public int? Stock { get; init; }
        public decimal? Price { get; init; }
        public decimal? Weight { get; init; }
    }
}