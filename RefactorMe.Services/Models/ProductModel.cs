using System;

namespace RefactorMe.Services.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal DeliveryPrice { get; set; }

        public partial class ProductOptionModel
        {
            public Guid Id { get; set; }

            public string Name { get; set; }

            public string Description { get; set; }
        }
    }
}