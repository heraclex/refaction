using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefactorMe.Data.Entities;
using RefactorMe.Data;
using RefactorMe.Core.Exceptions;
using RefactorMe.Services.Models;
using RefactorMe.Services.Extensions;
using RefactorMe.Core.Extensions;

namespace RefactorMe.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> productRepo;

        private readonly IRepository<ProductOption> productOptionRepo;

        public ProductService(
            IRepository<Product> productRepo,
            IRepository<ProductOption> productOptionRepo)
        {
            this.productRepo = productRepo;
            this.productOptionRepo = productOptionRepo;
        }

        public void DeleteProduct(Guid id)
        {
            var entity = this.productRepo.GetById(id);
            if (entity == null)
            {
                throw new CoreException("Product not found");
            }

            this.productRepo.Delete(entity);
        }

        public IList<ProductModel> FindProductsByName(string prodName)
        {
            var products = this.productRepo.Table.Where(x => x.Name.ToLower().Contains(prodName.ToLower())).ToList();
            return products != null ? products.MapTo<ProductModel>() : null;
        }

        public IList<ProductModel.ProductOptionModel> GetAllProductOptions(Guid id)
        {
            var productOptions = this.productRepo.Table.Where(prod=>prod.Id == id)
                .SelectMany(prod => prod.Options).ToList();

            return productOptions != null ? productOptions.MapTo<ProductModel.ProductOptionModel>() : null;
        }

        public IList<ProductModel> GetAllProducts()
        {
            var product = this.productRepo.Table.ToList();

            return product != null ? product.MapTo<ProductModel>() : null;
        }

        public ProductModel GetProductById(Guid id)
        {
            var product = this.productRepo.GetById(id);

            return product != null ? product.MapTo<ProductModel>() : null;
        }

        public ProductModel.ProductOptionModel GetProductOptionById(
            Guid productId, Guid productOptionId)
        {
            var productOptions = this.productRepo.Table.Where(prod => prod.Id == productId)
                .SelectMany(prod => prod.Options.Where(opt=>opt.Id == productOptionId)).FirstOrDefault();

            return productOptions != null ? productOptions.MapTo<ProductModel.ProductOptionModel>() : null;
        }

        public ProductModel SaveOrUpdateProduct(ProductModel model)
        {
            var entity = model.Id != null ? this.productRepo.GetById(model.Id) : new Product();
            if (entity == null)
            {
                throw new CoreException("Product not found");
            }

            entity = model.MapTo<Product>();

            if (model.Id != null)
            {
                this.productRepo.Update(entity);
            }
            else
            {
                this.productRepo.Insert(entity);
            }

            return entity.MapTo<ProductModel>();
        }

        public ProductModel.ProductOptionModel SaveOrUpdateProductOption(
            Guid productId, ProductModel.ProductOptionModel model)
        {
            var entity = model.Id != null 
                ? this.productOptionRepo.Table
                        .Where(opt => opt.ProductId == productId && opt.Id == model.Id)
                        .FirstOrDefault()
                : new ProductOption();

            if (entity == null)
            {
                throw new CoreException("ProductOption not found");
            }

            entity = model.MapTo<ProductOption>();

            if (model.Id != null)
            {
                this.productOptionRepo.Update(entity);
            }
            else
            {
                this.productRepo.Insert(entity);
            }

            return entity.MapTo<ProductModel.ProductOptionModel>();
        }
    }
}
