using System;
using System.Net;
using System.Web.Http;
using RefactorMe.Services;
using System.Collections.Generic;
using RefactorMe.Services.Models;
using refactor_me.Attributes;
using System.Threading.Tasks;
using System.Net.Http;
using refactor_me.Models;

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
        public HttpResponseMessage Get()
        {
            var products = this.productService.GetAllProducts();
            return Request.CreateResponse(new ProductsReturn(products));
        }

        // GET /products/{id} - gets the project that matches the specified ID - ID is a GUID.
        public HttpResponseMessage Get(Guid id)
        {
            var productModel = this.productService.GetProductById(id);
            if (productModel == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse(productModel);
        }

        //GET /products? name = { name } -- finds all products matching the specified name.
        public HttpResponseMessage Get(string name)
        {
            var resuts = this.productService.FindProductsByName(name);
            return Request.CreateResponse(new ProductsReturn(resuts));
        }

        // POST /products - creates a new product.
        public HttpResponseMessage Post(ProductModel model)
        {
            if(!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);

            // return new one
            var result = this.productService.InsertProduct(model);
            return Request.CreateResponse(result);
        }

        // PUT /products/{id} - updates a product.
        public HttpResponseMessage Put(Guid id, ProductModel model)
        {
            // Haveto convert error to client
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);

            if (!id.Equals(model.Id))
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Id");

            if (!this.productService.IsProductExist(id))
                return Request.CreateResponse(HttpStatusCode.NotFound);

            // return latest updates
            var result = this.productService.UpdateProduct(model);
            return Request.CreateResponse(result);
        }

        // DELETE /products/{id} - deletes a product and its options.
        public HttpResponseMessage Delete(Guid id)
        {
            if (!this.productService.IsProductExist(id))
                throw new HttpResponseException(HttpStatusCode.NotFound);

            this.productService.DeleteProduct(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        #endregion

        #region Product Options

        //GET /products/{ id}/options - finds all options for a specified product.
        [Route("{productId:guid}/options")]
        public HttpResponseMessage GetOptions(Guid productId)
        {
            var options = this.productService.GetAllProductOptions(productId);
            return Request.CreateResponse(new ProductOptionsReturn(options));
        }

        //GET /products/{id}/options/{optionId} - finds the specified product option for the specified product.
        [Route("{productId:guid}/options/{optionId:guid}")]
        public HttpResponseMessage GetOption(Guid productId, Guid optionId)
        {
            if (!this.productService.IsProductOptionExist(productId, optionId))
                return Request.CreateResponse(HttpStatusCode.NotFound);
            
            var option = this.productService.GetProductOptionById(productId, optionId);
            return Request.CreateResponse(option);
        }

        // POST /products/{id}/options - adds a new product option to the specified product.
        [HttpPost]
        [Route("{productId:guid}/options")]
        public HttpResponseMessage CreateOption(Guid productId, 
            ProductModel.ProductOptionModel optionModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);

            if (!this.productService.IsProductExist(productId))
                return Request.CreateResponse(HttpStatusCode.NotFound);

            // return new one
            var result = this.productService.InsertProductOption(productId, optionModel);
            return Request.CreateResponse(result);
        }

        // PUT /products/{ productId}/options/{optionId} - updates the specified product option.
        [HttpPut]
        [Route("{productId:guid}/options/{optionId}")]
        public HttpResponseMessage UpdateOption(
            Guid productId, Guid optionId, 
            ProductModel.ProductOptionModel optionModel)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);

            if (!this.productService.IsProductOptionExist(productId, optionId))
                return Request.CreateResponse(HttpStatusCode.NotFound);

            // return latest updates
            var result = this.productService.UpdateProductOption(optionModel);
            return Request.CreateResponse(result);
        }

        // DELETE /products/{productId}/options/{optionId} - deletes the specified product option.
        [HttpDelete]
        [Route("{productId:guid}/options/{optionId:guid}")]
        public HttpResponseMessage DeleteOption(Guid productId, Guid optionId)
        {
            if (!this.productService.IsProductOptionExist(productId, optionId))
                return Request.CreateResponse(HttpStatusCode.NotFound);

            this.productService.DeleteProductOption(optionId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        #endregion
    }
}
