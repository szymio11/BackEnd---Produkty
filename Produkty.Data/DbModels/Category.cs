using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Produkty.Data.DbModels
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public ICollection<Product> Product { get; set; }
        public Category()
        {
            Product = new Collection<Product>();
        }
    }
}