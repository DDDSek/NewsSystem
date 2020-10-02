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
                .HasKey(j => j.Id);

            builder
                .Property(j => j.Name)
                .IsRequired();

            //builder
            //    .OwnsOne(
            //        d => d.PhoneNumber,
            //        p =>
            //        {
            //            p.WithOwner();

            //            p.Property(pn => pn.Number);
            //        });

            builder
                .Property(j => j.UserId)
                .IsRequired();

            builder
                .HasMany(j => j.Articles)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("articles");
        }
    }
}
