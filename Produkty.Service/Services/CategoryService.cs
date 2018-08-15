using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Produkty.Data.DbModels;
using Produkty.Data.ModelsDto;
using Produkty.Repository;
using Produkty.Repository.Repositories;
using Produkty.Service.Interfaces;

namespace Produkty.Service.Services
{
    public class CategoryService : Repository<Category>, ICategoryService
    {
        private readonly IMapper _mapper;

        public CategoryService(DataContext context,IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            var result = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return result;

        }
    }
}