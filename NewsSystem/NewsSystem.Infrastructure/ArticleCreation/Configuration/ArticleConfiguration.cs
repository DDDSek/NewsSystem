namespace NewsSystem.Infrastructure.ArticleCreation.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Domain.ArticleCreation.Models.Articles; 

    using static Domain.ArticleCreation.Models.ModelConstants.Common;
    using static Domain.ArticleCreation.Models.ModelConstants.Article;

    internal class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(MaxTitleLength);

            builder
                .Property(c => c.Content)
                .IsRequired()
                .HasMaxLength(MaxContentLength);

            builder
                .Property(c => c.ImageUrl)
                .IsRequired()
                .HasMaxLength(MaxUrlLength);

            //  builder
            //    .Property(c => c.PricePerDay)
            //    .IsRequired()
            //    .HasColumnType("decimal(18,2)");

            builder
                .Property(c => c.IsAvailable)
                .IsRequired();

            // builder
            //    .HasOne(c => c.Manufacturer)
            //    .WithMany()
            //    .HasForeignKey("ManufacturerId")
            //    .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Category)
                .WithMany()
                .HasForeignKey("CategoryId")
                .OnDelete(DeleteBehavior.Restrict);

            //  builder
            //    .OwnsOne(c => c.Options, o =>
            //    {
            //        o.WithOwner();

            //        o.Property(op => op.NumberOfSeats);
            //        o.Property(op => op.HasClimateControl);

            //        o.OwnsOne(
            //            op => op.TransmissionType,
            //            t =>
            //            {
            //                t.WithOwner();

            //                t.Property(tr => tr.Value);
            //            });
            //    });
        }
    }
}
