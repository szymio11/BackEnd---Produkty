using System;

namespace Produkty.Data.ModelsDto
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryDto Category { get; set; }

        public Decimal Price { get; set; }
    }
}