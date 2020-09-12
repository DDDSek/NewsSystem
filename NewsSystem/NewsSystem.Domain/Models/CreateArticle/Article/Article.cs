namespace NewsSystem.Domain.Models.CreateArticle.Article
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Common;
    using Exceptions; 

    using static ModelConstants.Article;

    public class Article : Entity<int>, IAggregateRoot
    {
        private static readonly IEnumerable<Category> AllowedCategories
            = new CategoryData().GetData().Cast<Category>();

        internal Article(
            string title,
            string content,
            Category category,
            Comment comment,
            string imageUrl,
            DateRange dateRange,
            ArticlePriority articlePriority,
            Status status
            )
        {
            this.Validate(title, imageUrl, content);
            this.ValidateCategory(category);
            this.Title = Title;
            this.Content = Content;
            this.Comment = comment;
            this.Category = category;
            this.ImageUrl = imageUrl;
            this.DateRange = dateRange;
            this.ArticlePriority = articlePriority;
            this.Status = status;
        }

        private Article(
            string title,
            string content,
            Comment comment,
            string imageUrl,
            DateRange dateRange)
        {
            this.Title = title;
            this.Content = content;
            this.Comment = comment;
            this.ImageUrl = imageUrl;
            this.DateRange = dateRange;

            this.Category = default!;
            this.ArticlePriority = default!;
            this.Status = default!;
        }

        public string Title { get; private set; }

        public string Content { get; private set; }

        public Category Category { get; private set; }

        public string ImageUrl { get; private set; }

        public DateRange DateRange { get; private set; }

        public ArticlePriority ArticlePriority { get; private set; }

        public Status Status { get; private set; }

        public Comment Comment { get; private set; }

        public ICollection<Comment> Comments { get; } = new List<Comment>();

        public void AddComment(string comment, string userId)
            => this.Comments.Add(new Comment(comment, userId));

        public Article UpdateTitle(string title)
        {
            this.ValidateTitle(title);
            this.Title = title;

            return this;
        }

        public Article UpdateContent(string content)
        {
            this.ValidateContent(content);
            this.Content = content;

            return this; 
        }

        public Article UpdateDateRange(
            DateTime lastModify,
            DateTime deletedOn)
        {
            this.DateRange = new DateRange(lastModify, deletedOn, deletedOn);

            return this;
        }

        public Article UpdateImageUrl(string imageUrl)
        {
            this.ValidateImageUrl(imageUrl);
            this.ImageUrl = imageUrl;

            return this;
        }

        public Article UpdateCategory(Category category)
        {
            this.ValidateCategory(category);
            this.Category = category;

            return this;
        }

        private void Validate(string title, string content, string imageUrl)
        {
            this.ValidateTitle(title);
            this.ValidateContent(content);
            this.ValidateImageUrl(imageUrl);
        }

        private void ValidateTitle(string title)
            => Guard.ForStringLength<InvalidArticleException>(
                title,
                MinTitleLength,
                MaxTitleLength,
                nameof(this.Title));

        private void ValidateContent(string content)
            => Guard.ForStringLength<InvalidArticleException>(
                content,
                MinContentLength,
                MaxContentLength,
                nameof(this.Content));

        private void ValidateImageUrl(string imageUrl)
            => Guard.ForValidUrl<InvalidArticleException>(
                imageUrl,
                nameof(this.ImageUrl));

        private void ValidateCategory(Category category)
        {
            var categoryName = category?.Name;

            if (AllowedCategories.Any(c => c.Name == categoryName))
            {
                return;
            }

            var allowedCategoryNames = string.Join(", ", AllowedCategories.Select(c => $"'{c.Name}'"));

            throw new InvalidArticleException($"'{categoryName}' is not a valid category. Allowed values are: {allowedCategoryNames}.");
        }
    }
}
