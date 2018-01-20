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

        bool IsProductExist(Guid id);

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
        /// InsertProduct
        /// </summary>
        /// <returns></returns>
        ProductModel InsertProduct(ProductModel model);

        /// <summary>
        /// UpdateProduct
        /// </summary>
        /// <returns></returns>
        ProductModel UpdateProduct(ProductModel model);

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <returns></returns>
        void DeleteProduct(Guid id);

        #endregion

        #region product options

        bool IsProductOptionExist(Guid productId, Guid productOptionId);

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
        /// InsertProductOption
        /// </summary>
        /// <returns></returns>
        ProductModel.ProductOptionModel InsertProductOption(Guid productId, ProductModel.ProductOptionModel model);

        /// <summary>
        /// UpdateProductOption
        /// </summary>
        /// <returns></returns>
        ProductModel.ProductOptionModel UpdateProductOption(ProductModel.ProductOptionModel model);

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <returns></returns>
        void DeleteProductOption(Guid id);

        #endregion
    }
}
