using AutoMapper;
using eshop.Entities;
using eshop.Services.DataTransferObjects.Request;
using eshop.Services.DataTransferObjects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Services.MapProfiler
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductCardResponse>();
            CreateMap<CreateNewProductRequest, Product>();
            CreateMap<UpdateProductRequest, Product>();

        }

    }
}
