using System.Threading.Tasks;
using Produkty.Data.DbModels;

namespace Produkty.Repository.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<bool> IsAnyExistAsyn();
    }
}