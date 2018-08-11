﻿using System;
using System.Threading.Tasks;
using Produkty.Data.ModelsDto;

namespace Produkty.Service.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> CreateProductAsync(UploadProductDto productDto);
        Task<bool> IsExist(Guid productId);
        Task<ProductDto> GetProductAsync(Guid productId);
    }
}