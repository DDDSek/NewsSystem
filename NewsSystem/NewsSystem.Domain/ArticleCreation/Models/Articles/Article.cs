namespace NewsSystem.Domain.ArticleCreation.Models.Articles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Common;
    using Exceptions;
    using Domain.Common.Models;

    public class Article : Entity<int>, IAggregateRoot
    {
        private static readonly IEnumerable<Category> AllowedCategories
            = new CategoryData().GetData().Cast<Category>();

        private readonly HashSet<Comment> comments;

        internal Article(
            string title,
            string content,
            Category category, 
            string imageUrl,
            //DateRange dateRange,
            ArticlePriority аrticlePriority,
            //Status status,
            bool isAvailable
            )
        {
            this.Validate(title, imageUrl, content);
            this.ValidateCategory(category);

            this.Title = Title;
            this.Content = content;   
            this.Category = category; 
            this.ImageUrl = imageUrl;
            //this.DateRange = dateRange;
            this.ArticlePriority = аrticlePriority;
            //this.Status = status;
            this.IsAvailable = isAvailable;

            this.comments = new HashSet<Comment>();
        }

        private Article(
            string title,
            string content, 
            string imageUrl,
            Category category,
            bool isAvailable
            )
        {
            this.Title = title;
            this.Content = content; 
            this.ImageUrl = imageUrl;
            //this.DateRange = dateRange;
            this.Category = category;
            this.IsAvailable = isAvailable;

            this.ArticlePriority = default!;
            //this.Status = default!;

            this.comments = new HashSet<Comment>();
        }

        public string Title { get; private set; }

        public string Content { get; private set; }

        public Category Category { get; private set; }

        public string ImageUrl { get; private set; }

        public Comment Comment { get; private set; } = default!;

        //public DateRange DateRange { get; private set; }

        //public Status Status { get; private set; } = Status.Waiting;

        public ArticlePriority ArticlePriority { get; private set; } //= ArticlePriority.Daily;

        public bool IsAvailable { get; private set; } 

        public IReadOnlyCollection<Comment> Comments => this.comments.ToList().AsReadOnly(); 

        //TO DO: new CommentAddedEvent + Handler

        public void AddComment(string title, string content, string createdBy, int articleId)
        {
            this.comments.Add(new Comment(title, content, createdBy, articleId));

            //this.AddEvent(new CommentAddedEvent());
        }

        public Article UpdateComment(Comment comment)
        {
            this.Comment = comment;

            return this;
        }

        //public void UpdateComment(string title, string content, string createdBy, int articleId)
        //{
        //    this.comments.
        //    //this.comments.Add(new Comment(title, content, createdBy, articleId));

        //    //this.AddEvent(new CommentAddedEvent());
        //}

        public Article ChangeAvailability()
        {
            this.IsAvailable = !this.IsAvailable;

            return this;
        }

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

        //public Article UpdateDateRange(
        //    DateTime lastModify,
        //    DateTime deletedOn)
        //{
        //    this.DateRange = new DateRange(lastModify, deletedOn);

        //    return this;
        //}

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

        public Article UpdateArticlePriority(ArticlePriority articlePriority)
        {
            this.ArticlePriority = articlePriority;

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
                ModelConstants.Article.MinTitleLength,
                ModelConstants.Article.MaxTitleLength,
                nameof(this.Title));

        private void ValidateContent(string content)
            => Guard.ForStringLength<InvalidArticleException>(
                content,
                ModelConstants.Article.MinContentLength,
                ModelConstants.Article.MaxContentLength,
                nameof(this.Content));

        private void ValidateImageUrl(string imageUrl)
            => Guard.ForValidUrl<InvalidArticleException>(
                imageUrl,
                nameof(this.ImageUrl));

        //private void ValidateCommentTitle(string title)
        //    => Guard.ForStringLength<InvalidCommentException>(
        //        title,
        //        ModelConstants.Comment.MinContentLength,
        //        ModelConstants.Comment.MaxContentLength,
        //        nameof(this.Content));

        //private void ValidateCommentContent(string content)
        //    => Guard.ForStringLength<InvalidCommentException>(
        //        content,
        //        ModelConstants.Comment.MinContentLength,
        //        ModelConstants.Comment.MaxContentLength,
        //        nameof(this.Content));

        //private void ValidateCommentUserId(string userId)
        //    => Guard.ForStringLength<InvalidCommentException>(
        //        userId,
        //        ModelConstants.Comment.MinContentLength,
        //        ModelConstants.Comment.MaxContentLength,
        //        nameof(this.Content));

        //private void ValidateCommentArticleId(int articleId)
        //{
        //    if (Enumerable.Range(1, Int32.MaxValue).Contains(articleId))
        //    {
        //        return;
        //    }

        //    throw new InvalidCommentException($"'{articleId}' is not a valid articleId. Allowed values are between {Int32.MinValue} & {Int32.MaxValue}.");
        //} 

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
