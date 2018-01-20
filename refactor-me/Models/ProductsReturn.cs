using RefactorMe.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace refactor_me.Models
{
    public class ProductsReturn
    {
        public ProductsReturn(IEnumerable<ProductModel> products)
        {
            this.Items = products;
        }

        public IEnumerable<ProductModel> Items { get; private set; }
    }
}