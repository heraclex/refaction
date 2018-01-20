using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefactorMe.Data.Entities;
using RefactorMe.Data;
using RefactorMe.Core.Exceptions;
using RefactorMe.Services.Models;

namespace RefactorMe.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> productRepo;

        public ProductService(IRepository<Product> productRepo)
        {
            this.productRepo = productRepo;
        }

        public ProductModel DeleteProduct(ProductModel model)
        {
            if (model == null)
            {
                throw new CoreException("ProductModel is null");
            }

            throw new NotImplementedException();
        }

        public IList<ProductModel> FindProductsByName()
        {
            throw new NotImplementedException();
        }

        public IList<ProductModel.ProductOptionModel> GetAllProductOptions(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<ProductModel> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public ProductModel GetProductById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ProductModel.ProductOptionModel GetProductOptionById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ProductModel SaveOrUpdateProduct(ProductModel model)
        {
            throw new NotImplementedException();
        }

        public ProductModel.ProductOptionModel SaveOrUpdateProductOption(ProductModel.ProductOptionModel model)
        {
            throw new NotImplementedException();
        }
    }
}
