namespace NewsSystem.Infrastructure.ArticleCreation.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Domain.ArticleCreation.Models.Articles;

    using Infrastructure.Identity;
    using static Domain.ArticleCreation.Models.ModelConstants.Comment;

    internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
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
                .Property(c => c.CreatedBy)
                .IsRequired();

            builder
                .HasOne(typeof(User))
                .WithMany("Comments")
                .HasForeignKey("CreatedBy")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

