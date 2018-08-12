using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Produkty.Data.DbModels;
using Produkty.Data.ModelsDto;

namespace Produkty.Service.Interfaces
{
    public interface IProductService
    {
        Task<bool> IsCategoryExistAsync(Guid categoryId);
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task DeleteProduct(Guid productId);
        Task<ProductDto> CreateProductAsync(UploadProductDto productDto);
        Task<bool> IsExist(Guid productId);
        Task<ProductDto> GetProductAsync(Guid productId);
        Task UploadProduct(UploadProductDto productDto, Guid productId);
        Task<bool> IsAnyExistAsync();
    }
}