using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RefactorMe.Services.Models;

namespace refactor_me.Models
{  
    public class ProductOptionsReturn
    {
        public ProductOptionsReturn(IEnumerable<ProductModel.ProductOptionModel> options)
        {
            this.Items = options;
        }

        public IEnumerable<ProductModel.ProductOptionModel> Items { get; private set; }
    }
}