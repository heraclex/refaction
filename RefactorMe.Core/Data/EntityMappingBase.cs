
using System.Data.Entity.ModelConfiguration;

namespace RefactorMe.Core.Data
{
    public abstract class EntityMappingBase<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        protected EntityMappingBase()
        {
            this.HasKey(x => x.Id);
        }
    }
}
