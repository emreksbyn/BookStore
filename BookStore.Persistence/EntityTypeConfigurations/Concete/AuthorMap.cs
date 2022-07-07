using BookStore.Domain.Entities.Concrete;
using BookStore.Persistence.EntityTypeConfigurations.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Persistence.EntityTypeConfigurations.Concete
{
    public class AuthorMap : BaseMap<Author>
    {
        public override void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).HasMaxLength(200).IsRequired(true);
            builder.Property(x => x.LastName).HasMaxLength(200).IsRequired(true);
            base.Configure(builder);
        }
    }
}