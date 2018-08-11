using System;
using System.Threading.Tasks;
using Produkty.Data.ModelsDto;

namespace Produkty.Service.Interfaces
{
    public interface IProductService
    {
        Task<bool> IsExist(Guid productId);
        Task<ProductDto> GetProduct(Guid productId);
    }
}