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
        IList<ProductModel> FindProductsByName(string prodName);

        /// <summary>
        /// Get Product By Id
        /// </summary>
        /// <returns></returns>
        ProductModel GetProductById(Guid id);

        /// <summary>
        /// SaveOrUpdateProduct
        /// </summary>
        /// <returns></returns>
        ProductModel SaveOrUpdateProduct(ProductModel model);

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <returns></returns>
        void DeleteProduct(Guid id);

        #endregion

        #region product options

        /// <summary>
        /// gets options relate to product.
        /// </summary>
        /// <returns></returns>
        IList<ProductModel.ProductOptionModel> GetAllProductOptions(Guid id);

        /// <summary>
        /// Get ProductOption By Id
        /// </summary>
        /// <returns></returns>
        ProductModel.ProductOptionModel GetProductOptionById(Guid productId, Guid productOptionId);

        /// <summary>
        /// Save Or Update Product Option
        /// </summary>
        /// <returns></returns>
        ProductModel.ProductOptionModel SaveOrUpdateProductOption(Guid productId, ProductModel.ProductOptionModel model);

        #endregion
    }
}
