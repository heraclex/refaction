using RefactorMe.Data.Entities;
using RefactorMe.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.Services.Profiles
{
    public class ProductModelProfile : AutoMapper.Profile
    {
        public ProductModelProfile()
        {
            CreateMap<ProductModel, Product>();
            CreateMap<Product, ProductModel>();

            CreateMap<ProductModel.ProductOptionModel, ProductOption>();
            CreateMap<ProductOption, ProductModel.ProductOptionModel>();
        }
    }
}
