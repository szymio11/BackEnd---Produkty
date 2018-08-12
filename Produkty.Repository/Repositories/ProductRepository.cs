using System;
using System.Collections.Generic;
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

        public override async Task<Product> GetAsyn(Guid id)
        {
            return await _context.Products.Include(c => c.Category).FirstOrDefaultAsync(a => a.Id == id);
        }

        public override async Task<ICollection<Product>> GetAllAsyn()
        {
            return await _context.Products.Include(c => c.Category).ToArrayAsync();
        }

        public async Task<bool> IsCategoryExistAsyn(Guid categoryId) =>
            await _context.Set<Category>().AnyAsync(a=>a.Id==categoryId);
  
        public async Task<bool> IsAnyExistAsyn() => await _context.Products.AnyAsync();
    }
}