namespace NewsSystem.Infrastructure.Statistics.Configuration
{
    using Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Domain.ArticleCreation.Models.Articles;
    using Domain.Statistics.Models;

    public class ArticleViewConfiguration : IEntityTypeConfiguration<ArticleView>
    {
        public void Configure(EntityTypeBuilder<ArticleView> builder)
        {
            builder
                .HasKey(cav => cav.Id);

            builder
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<Article>()
                .WithMany()
                .HasForeignKey(c => c.ArticleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
