﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Produkty.Data.DbModels;
using Produkty.Data.ModelsDto;
using Produkty.Repository.Interfaces;
using Produkty.Service.Interfaces;

namespace Produkty.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> IsExist(Guid productId)
            => await _repository.ExistAsync(a=>a.Id==productId);

        public async Task<ProductDto> GetProductAsync(Guid productId)
        {
            var product = await _repository.GetAsyn(productId);
            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }

        public async Task<ProductDto> CreateProductAsync(UploadProductDto productDto)
        {
            var product = _mapper.Map<UploadProductDto, Product>(productDto);
            await _repository.AddAsyn(product);
            return await GetProductAsync(product.Id);
        }

        public async Task UploadProduct(UploadProductDto productDto, Guid productId)
        {
            var product = await _repository.FindAsync(a => a.Id == productId);
            _mapper.Map(productDto, product);
            await _repository.SaveAsync();
        }

        public async Task DeleteProduct(Guid productId)
        {
            var product = await _repository.GetAsyn(productId);
            await _repository.DeleteAsyn(product);
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var product = await _repository.GetAllAsyn();
            var result = _mapper.Map<IEnumerable<ProductDto>>(product);
            return result;
        }
        public async Task<bool> IsAnyExistAsync() => await _repository.IsAnyExistAsyn();

        public async Task<bool> IsCategoryExistAsync(Guid categoryId)
        {
            return await _repository.IsCategoryExistAsyn(categoryId);
        }

    }
}