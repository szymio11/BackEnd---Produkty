﻿using AutoMapper;
using Produkty.Data.DbModels;
using Produkty.Data.ModelsDto;

namespace Produkty.API.Helpers
{
    public class AutoMapperProduct : Profile
    {
        public AutoMapperProduct()
        {
            CreateMap<Product, ProductDto>().ForMember(c=>c.Category,opt=>opt.MapFrom(
                c=>new CategoryDto
                {
                    Id=c.Category.Id,
                    Name = c.Category.Name
                }));
            CreateMap<UploadProductDto, Product>()
                .ForMember(i=>i.Id,opt=>opt.Ignore());
            CreateMap<Category,CategoryDto>();
        }
    }
}
