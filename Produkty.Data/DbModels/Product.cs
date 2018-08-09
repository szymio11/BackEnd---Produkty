using System;
using System.ComponentModel.DataAnnotations;

namespace Produkty.Data.DbModels
{
    public class Product : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }

        [Required]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public Decimal Price { get; set; }
    }
}