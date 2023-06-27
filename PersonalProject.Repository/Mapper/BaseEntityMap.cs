using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalProject.Domain.Entities;

namespace PersonalProject.Repository.Mapper
{
    public abstract class BaseEntityMap<T> where T : Entity
    {
        protected abstract void Map(EntityTypeBuilder<T> eb);

        public void BaseMap(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T>(bi =>
            {
                //bi.Property(b => b.Status)./*HasColumnType*/("bit");
                bi.HasKey(b => b.Id);
                Map(bi);
            });
        }
    }
}
