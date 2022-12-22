using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureBoilerplate.Application.Products
{
    public class ProductResult
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