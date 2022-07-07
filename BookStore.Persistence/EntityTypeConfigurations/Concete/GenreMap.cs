using BookStore.Domain.Entities.Concrete;
using BookStore.Persistence.EntityTypeConfigurations.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Persistence.EntityTypeConfigurations.Concete
{
    public class GenreMap : BaseMap<Genre>
    {
        public override void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(25).IsRequired(true);
            base.Configure(builder);
        }
    }
}