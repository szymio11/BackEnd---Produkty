using System;
using System.ComponentModel.DataAnnotations;

namespace Produkty.Data.ModelsDto
{
    public class UploadProductDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        public Decimal Price { get; set; }
    }
}
