using RefactorMe.Data.Entities;
using RefactorMe.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.Services
{
    public interface IProductService : IService
    {
        /*
         There should be these endpoints:

    GET /products - gets all products.
    GET /products?name={name} - finds all products matching the specified name.
    GET /products/{id} - gets the project that matches the specified ID - ID is a GUID.
    POST /products - creates a new product.
    PUT /products/{id} - updates a product.
    DELETE /products/{id} - deletes a product and its options.
    GET /products/{id}/options - finds all options for a specified product.
    GET /products/{id}/options/{optionId} - finds the specified product option for the specified product.
    POST /products/{id}/options - adds a new product option to the specified product.
    PUT /products/{id}/options/{optionId} - updates the specified product option.
    DELETE /products/{id}/options/{optionId} - deletes the specified product option.

         */

        #region products

        /// <summary>
        /// gets all products.
        /// </summary>
        /// <returns></returns>
        IList<ProductModel> GetAllProducts();

        /// <summary>
        /// Find Products ByName
        /// </summary>
        /// <returns></returns>
        IList<ProductModel> FindProductsByName();

        /// <summary>
        /// Get Product By Id
        /// </summary>
        /// <returns></returns>
        ProductModel GetProductById(Guid id);

        /// <summary>
        /// Get Product By Id
        /// </summary>
        /// <returns></returns>
        ProductModel SaveOrUpdateProduct(ProductModel model);

        /// <summary>
        /// Get Product By Id
        /// </summary>
        /// <returns></returns>
        ProductModel DeleteProduct(ProductModel model);

        #endregion

        #region product options

        /// <summary>
        /// gets options relate to product.
        /// </summary>
        /// <returns></returns>
        IList<ProductModel.ProductOptionModel> GetAllProductOptions(Guid id);

        /// <summary>
        /// Get Product By Id
        /// </summary>
        /// <returns></returns>
        ProductModel.ProductOptionModel GetProductOptionById(Guid id);

        /// <summary>
        /// Get Product By Id
        /// </summary>
        /// <returns></returns>
        ProductModel.ProductOptionModel SaveOrUpdateProductOption(ProductModel.ProductOptionModel model);

        #endregion
    }
}
