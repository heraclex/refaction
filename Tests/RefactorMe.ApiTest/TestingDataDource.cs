using RefactorMe.Data.Entities;
using RefactorMe.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.ApiTest
{
    public class TestingDataDource
    {
        public static ProductModel InvalidNewProductModel
        {
            get
            {
                return new ProductModel()
                {
                    Id = Guid.Empty,
                    Name = string.Empty,
                    Description = string.Empty
                };
            }
        }

        public static ProductModel ValidNewProductModel
        {
            get
            {
                return new ProductModel()
                {
                    Id = Guid.Empty,
                    Name = "iPhone tripple X",
                    Description = "New phone come from Apple",
                    Price = 1000,
                    DeliveryPrice = 99
                };
            }
        }

        public static ProductModel ExistingProductModel
        {
            get
            {
                return ProductModelList.First();
            }
        }

        public static List<ProductModel> ProductModelList
        {
            get
            {
                return Products.Select(x => new ProductModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,             
                    Price = x.Price,
                    DeliveryPrice = x.DeliveryPrice
                }).ToList();
            }
        }
        
        public static List<Product> Products
        {
            get
            {
                return new List<Product>
                {
                    new Product() { Id = Guid.NewGuid(), Name = "Phone 1", Price = 101, DeliveryPrice = 9.99m, Description = "New Product of Samsung" },
                    new Product() { Id = Guid.NewGuid(), Name = "Phone 2", Price = 102, DeliveryPrice = 9.99m, Description = "New Product of Apple" },
                    new Product() { Id = Guid.NewGuid(), Name = "Phone 3", Price = 103, DeliveryPrice = 9.99m, Description = "New Product of LG" },
                    new Product() { Id = Guid.NewGuid(), Name = "Phone 4", Price = 104, DeliveryPrice = 9.99m, Description = "New Product of Nokia" },
                    new Product() { Id = Guid.NewGuid(), Name = "Phone 5", Price = 105, DeliveryPrice = 9.99m, Description = "New Product of Test" },
                };
            }
        }

        public static List<ProductOption> ProductOptions
        {
            get
            {
                return new List<ProductOption>
                {
                    new ProductOption() { Id = Guid.NewGuid(), ProductId = Products[0].Id, Name = "B&W", Description    = "Option 1" },
                    new ProductOption() { Id = Guid.NewGuid(), ProductId = Products[0].Id, Name = "Colour", Description = "Option 2"},
                    new ProductOption() { Id = Guid.NewGuid(), ProductId = Products[1].Id, Name = "Green", Description  = "Option 3"},
                    new ProductOption() { Id = Guid.NewGuid(), ProductId = Products[1].Id, Name = "Red", Description    = "Option 4"},
                    new ProductOption() { Id = Guid.NewGuid(), ProductId = Products[2].Id, Name = "Gold", Description   = "Option 5"},
                    new ProductOption() { Id = Guid.NewGuid(), ProductId = Products[2].Id, Name = "Black", Description  = "Option 6"},
                    new ProductOption() { Id = Guid.NewGuid(), ProductId = Products[3].Id, Name = "White", Description  = "Option 7" },
                    new ProductOption() { Id = Guid.NewGuid(), ProductId = Products[3].Id, Name = "Red & Gold", Description     = "Option 8" },
                    new ProductOption() { Id = Guid.NewGuid(), ProductId = Products[4].Id, Name = "Blue", Description           = "Option 9" },
                    new ProductOption() { Id = Guid.NewGuid(), ProductId = Products[4].Id, Name = "Red", Description = "Option 10" },
                    new ProductOption() { Id = Guid.NewGuid(), ProductId = Products[4].Id, Name = "Black", Description = "Option 11" }
                };
            }
        }

    }
}
