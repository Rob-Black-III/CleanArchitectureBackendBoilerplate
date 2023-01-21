using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureBoilerplate.Domain.Entities;

namespace CleanArchitectureBoilerplate.API.Products
{
    public class ProductsPresentationDTOs
    {
        public record ProductAdd
        {
            public string? PartNumber { get; private set; }
            public string Name { get; private set; }
            public string? Description { get; private set; }
            public int? Stock { get; private set; }
            public decimal? Price { get; private set; }
            public decimal? Weight { get; private set; }

        }
        public record ProductUpdate
        {

        }

        public record ProductResponse{
            
        }
    }
}