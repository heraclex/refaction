using System;
using System.Net;
using System.Web.Http;
using RefactorMe.Services;
using System.Collections.Generic;
using RefactorMe.Services.Models;
using refactor_me.Attributes;
using System.Threading.Tasks;

namespace refactor_me.Controllers
{
    [ExceptionHandling]
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        #region products

        //GET /products - gets all products.
        public IHttpActionResult Get()
        {
            return Ok(new
            {
                Items = this.productService.GetAllProducts()
            });
        }

        // GET /products/{id} - gets the project that matches the specified ID - ID is a GUID.
        public ProductModel Get(Guid id)
        {
            var productModel = this.productService.GetProductById(id);
            if (productModel == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return productModel;
        }

        //GET /products? name = { name } -- finds all products matching the specified name.
        public IHttpActionResult Get(string name)
        {
            //return this.productService.FindProductsByName(name);

            return Ok(new
            {
                Items = this.productService.FindProductsByName(name)
            });
        }

        // POST /products - creates a new product.
        public ProductModel Post(ProductModel model)
        {
            // return new one
            return this.productService.InsertProduct(model);
        }

        // PUT /products/{id} - updates a product.
        public ProductModel Put(Guid id, ProductModel model)
        {
            if (!id.Equals(model.Id))
                throw new HttpResponseException(HttpStatusCode.NotAcceptable);

            if (!this.productService.IsProductExist(id))
                throw new HttpResponseException(HttpStatusCode.NotFound);

            // return latest updates
            return this.productService.UpdateProduct(model);
        }

        // DELETE /products/{id} - deletes a product and its options.
        public IHttpActionResult Delete(Guid id)
        {
            if (!this.productService.IsProductExist(id))
                throw new HttpResponseException(HttpStatusCode.NotFound);

            this.productService.DeleteProduct(id);

            return Ok(new { Message = "Delete Success" });
        }

        #endregion

        #region Product Options

        //GET /products/{ id}/options - finds all options for a specified product.
        [Route("{productId}/options")]
        [HttpGet]
        public IEnumerable<ProductModel.ProductOptionModel> GetOptions(Guid productId)
        {
            return this.productService.GetAllProductOptions(productId);
        }

        //GET /products/{id}/options/{optionId} - finds the specified product option for the specified product.
        [Route("{productId:guid}/options/{optionId}")]
        public ProductModel.ProductOptionModel GetOption(Guid productId, Guid optionId)
        {
            if (!this.productService.IsProductOptionExist(productId, optionId))
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return this.productService.GetProductOptionById(productId, optionId);
        }

        // POST /products/{id}/options - adds a new product option to the specified product.
        [HttpPost]
        [Route("{productId:guid}/options")]
        public ProductModel.ProductOptionModel CreateOption(Guid productId, ProductModel.ProductOptionModel optionModel)
        {
            if (!this.productService.IsProductExist(productId))
                throw new HttpResponseException(HttpStatusCode.NotFound);
            // return new added-option
            return this.productService.InsertProductOption(productId, optionModel);
        }

        // PUT /products/{ productId}/options/{optionId} - updates the specified product option.
        [HttpPut]
        [Route("{productId:guid}/options/{optionId}")]
        public ProductModel.ProductOptionModel UpdateOption(Guid productId, Guid optionId, ProductModel.ProductOptionModel optionModel)
        {
            if (!this.productService.IsProductOptionExist(productId, optionId))
                throw new HttpResponseException(HttpStatusCode.NotFound);
            // return latest update
            return this.productService.UpdateProductOption(optionModel);
        }

        // DELETE /products/{productId}/options/{optionId} - deletes the specified product option.
        [HttpDelete]
        [Route("{productId}/options/{optionId}")]
        public IHttpActionResult DeleteOption(Guid productId, Guid optionId)
        {
            if (!this.productService.IsProductOptionExist(productId, optionId))
                throw new HttpResponseException(HttpStatusCode.NotFound);

            this.productService.DeleteProductOption(optionId);

            return Ok(new { Message = "Delete Success" });
        }

        #endregion
    }
}
