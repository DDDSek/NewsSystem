namespace NewsSystem.Infrastructure.ArticleCreation.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using NewsSystem.Domain.ArticleCreation.Models.Journalists;

    internal class DealerConfiguration : IEntityTypeConfiguration<Journalist>
    {
        public void Configure(EntityTypeBuilder<Journalist> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder
                .Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);

            builder
                .OwnsOne(
                    d => d.PhoneNumber,
                    p =>
                    {
                        p.WithOwner();

                        p.Property(pn => pn.Number);
                    });

            builder
                .HasMany(d => d.Articles)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("articles");
        }
    }
}
