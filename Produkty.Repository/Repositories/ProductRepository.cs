using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Produkty.Data.DbModels;
using Produkty.Repository.Interfaces;

namespace Produkty.Repository.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {
        }

        public override async Task<Product> GetAsync(Guid id)
        {
            return await _context.Products.Include(c => c.Category).FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}