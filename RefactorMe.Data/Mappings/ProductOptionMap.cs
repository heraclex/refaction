using RefactorMe.Core.Data;
using RefactorMe.Data.Entities;

namespace RefactorMe.Data.Mappings
{
    public class ProductOptionMap : EntityMappingBase<ProductOption>
    {
        public ProductOptionMap()
        {
            this.ToTable("ProductOption");

            // Properties
            this.Property(t => t.Name);
            this.Property(t => t.ProductId);
            this.Property(t => t.Description);
        }
    }
}
