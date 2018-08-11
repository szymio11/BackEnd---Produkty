using System;
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
            var product = await _repository.GetAsync(productId);
            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }

        public async Task<ProductDto> CreateProductAsync(UploadProductDto productDto)
        {
            var product = _mapper.Map<UploadProductDto, Product>(productDto);
            await _repository.AddAsyn(product);
            return await GetProductAsync(product.Id);
        }


    }
}