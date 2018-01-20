using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefactorMe.Data.Entities;

namespace RefactorMe.Services
{
    public class ProductService : IProductService
    {
        public Product DeletePtoduct(Product entity)
        {
            throw new NotImplementedException();
        }

        public IList<Product> FindProductsByName()
        {
            throw new NotImplementedException();
        }

        public IList<ProductOption> GetAllProductOptions(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ProductOption GetProductOptionById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ProductOption SaveOrUpdateProductOption(ProductOption entity)
        {
            throw new NotImplementedException();
        }

        public Product SaveOrUpdatePtoduct(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
