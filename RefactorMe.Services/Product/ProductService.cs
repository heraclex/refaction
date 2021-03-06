﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefactorMe.Data.Entities;
using RefactorMe.Data;
using RefactorMe.Core.Exceptions;
using RefactorMe.Services.Models;
using RefactorMe.Services.Extensions;

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

        #region Products

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

        public IList<ProductModel> FindProductsByName(string prodName)
        {
            var products = this.productRepo.Table.Where(x => x.Name.ToLower().Contains(prodName.ToLower())).ToList();
            return products != null ? products.MapTo<ProductModel>() : null;
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

        public ProductModel InsertProduct(ProductModel model)
        {
            var entity = model.MapTo<Product>();
            this.productRepo.Insert(entity);
            return entity.MapTo<ProductModel>();
        }

        public ProductModel UpdateProduct(ProductModel model)
        {
            var entity = this.productRepo.GetById(model.Id);

            if (entity == null)
            {
                throw new CoreException("Product not found");
            }
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.Price = model.Price;
            entity.DeliveryPrice = model.DeliveryPrice;
            this.productRepo.Update(entity);
            return entity.MapTo<ProductModel>();
        }
        
        public bool IsProductExist(Guid id)
        {
            return this.productRepo.Table.Any(x => x.Id == id);
        }

        #endregion

        #region ProductOptions

        public void DeleteProductOption(Guid id)
        {
            var entity = this.productOptionRepo.GetById(id);
            if (entity == null)
            {
                throw new CoreException("ProductOption not found");
            }

            this.productOptionRepo.Delete(entity);
        }

        public ProductModel.ProductOptionModel GetProductOptionById(
            Guid productId, Guid productOptionId)
        {
            var productOptions = this.productRepo.Table.Where(prod => prod.Id == productId)
                .SelectMany(prod => prod.Options.Where(opt => opt.Id == productOptionId)).FirstOrDefault();

            return productOptions != null ? productOptions.MapTo<ProductModel.ProductOptionModel>() : null;
        }

        public ProductModel.ProductOptionModel InsertProductOption(
            Guid productId, ProductModel.ProductOptionModel model)
        {
            var entity = model.MapTo<ProductOption>();
            entity.ProductId = productId;

            this.productOptionRepo.Insert(entity);
            return entity.MapTo<ProductModel.ProductOptionModel>();
        }

        public bool IsProductOptionExist(Guid productId, Guid productOptionId)
        {
            return this.productRepo.Table.Where(x => x.Id == productId).Any(x => x.Options.Any(opt => opt.Id == productOptionId));
        }

        public IList<ProductModel.ProductOptionModel> GetAllProductOptions(Guid id)
        {
            var productOptions = this.productRepo.Table.Where(prod => prod.Id == id)
                .SelectMany(prod => prod.Options).ToList();

            return productOptions != null ? productOptions.MapTo<ProductModel.ProductOptionModel>() : null;
        }
        
        public ProductModel.ProductOptionModel UpdateProductOption(ProductModel.ProductOptionModel model)
        {
            var entity = this.productOptionRepo.GetById(model.Id);

            if (entity == null)
            {
                throw new CoreException("ProductOption not found");
            }

            entity.Name = model.Name;
            entity.Description = model.Description;

            this.productOptionRepo.Update(entity);
            return entity.MapTo<ProductModel.ProductOptionModel>();
        }

        #endregion
    }
}
