using RefactorMe.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorMe.Data.Entities
{
    public class ProductOption : BaseEntity
    {
        public ProductOption()
        {
            this.Id = new Guid();
        }

        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Product Product { get; set; }
    }
}
