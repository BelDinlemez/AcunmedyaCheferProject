using AutoMapper;
using Chefer.API.DTOs.ProductDtos;
using Chefer.API.Entities;

namespace Chefer.API.Mappings
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
                CreateMap<Product,CreateProductDto>().ReverseMap();
                CreateMap<Product,UpdateProductDto>().ReverseMap();

        }
    }
}
