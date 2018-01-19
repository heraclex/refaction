using RefactorMe.Core.Data;
using RefactorMe.Data.Entities;

namespace RefactorMe.Data.Mappings
{
    public class ProductMap : EntityMappingBase<Product>
    {
        public ProductMap()
        {
            this.ToTable("Product");

            // Properties
            this.Property(p => p.Name);
            this.Property(p => p.Price);
            this.Property(p => p.Description);
            this.Property(p => p.DeliveryPrice);

            // Delete list options related on delete products
            this.HasMany(p => p.Options)
                .WithOptional(b => b.Product)
                .HasForeignKey(j => j.ProductId)
                .WillCascadeOnDelete(true);
        }
    }
}
