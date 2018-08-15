using System.Collections.Generic;
using System.Threading.Tasks;
using Produkty.Data.DbModels;
using Produkty.Data.ModelsDto;
using Produkty.Repository.Interfaces;

namespace Produkty.Service.Interfaces
{
    public interface ICategoryService : IRepository<Category>
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
    }
}