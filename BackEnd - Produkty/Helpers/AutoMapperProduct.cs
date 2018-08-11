using AutoMapper;
using Produkty.Data.DbModels;
using Produkty.Data.ModelsDto;

namespace Produkty.API.Helpers
{
    public class AutoMapperProduct : Profile
    {
        public AutoMapperProduct()
        {
            CreateMap<Product, ProductDto>().ForMember(a=>a.Category,opt=>opt.MapFrom(
                c=>c.Category.Name));
        }
    }
}
