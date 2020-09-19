namespace NewsSystem.Infrastructure.ArticleCreation.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Domain.ArticleCreation.Models.Journalists;
    using Domain.ArticleCreation.Models;

    internal class JournalistConfiguration : IEntityTypeConfiguration<Journalist>
    {
        public void Configure(EntityTypeBuilder<Journalist> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder
                .Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(ModelConstants.Journalist.MaxNameLength);

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
