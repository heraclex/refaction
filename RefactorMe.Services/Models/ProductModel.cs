using System;
using System.ComponentModel.DataAnnotations;

namespace RefactorMe.Services.Models
{
    public class ProductModel
    {
        public Guid? Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "MaxLength 100")]
        public string Name { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "MaxLength 100")]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal DeliveryPrice { get; set; }

        public partial class ProductOptionModel
        {
            public Guid? Id { get; set; }            

            [Required]
            [MaxLength(100, ErrorMessage = "MaxLength 100")]
            public string Name { get; set; }

            [Required]
            [MaxLength(100, ErrorMessage = "MaxLength 100")]
            public string Description { get; set; }
        }
    }
}