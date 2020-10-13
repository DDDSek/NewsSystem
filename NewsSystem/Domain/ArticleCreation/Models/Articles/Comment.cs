namespace NewsSystem.Domain.ArticleCreation.Models.Articles
{
    using Domain.Common.Models;
    using Domain.Exceptions;

    public class Comment : Entity<int>
    {
        internal Comment(
            string title,
            string content,
            string createdBy,
               int articleId,
               int? commentId
            )
        {
            this.Validate(title, content, createdBy, articleId);

            this.Title = title;
            this.Content = content;
            this.CreatedBy = createdBy;
            this.ArticleId = articleId;
            this.CommentId = commentId;
        }
        private Comment(

            string content,
            string createdBy,
               int articleId,
               int? commentId
            )
        {
            this.Title = default!;
            this.Content = content;
            this.CreatedBy = createdBy;
            this.ArticleId = articleId;
            this.CommentId = commentId;
        }

        public string Title { get; private set; }

        public string Content { get; private set; }

        public string CreatedBy { get; private set; }

        public int? CommentId { get; private set; }

        public int ArticleId { get; private set; }

        public Article Article { get; private set; } = default!;

        public Comment UpdateComment(string title, string content, string createdBy, int articleId, int commentId)
        {
            this.Title = title;
            this.Content = content;
            this.CreatedBy = createdBy;
            this.ArticleId = articleId;
            this.CommentId = commentId;

            return this;
        }

        private void Validate(string title, string content, string createdBy, int articleId)
        {
            this.ValidateTitle(title);
            this.ValidateContent(content);
            this.ValidateCreatedBy(createdBy);
            this.ValidateArticleId(articleId);
        }

        private void ValidateTitle(string title)
            => Guard.ForStringLength<InvalidCommentException>(
                title,
                ModelConstants.Comment.MinTitleLength,
                ModelConstants.Comment.MaxTitleLength,
                nameof(this.Title));

        private void ValidateContent(string content)
            => Guard.ForStringLength<InvalidCommentException>(
                content,
                ModelConstants.Comment.MinContentLength,
                ModelConstants.Comment.MaxContentLength,
                nameof(this.Content));

        private void ValidateCreatedBy(string createdBy)
            => Guard.AgainstEmptyString<InvalidCommentException>(
                createdBy,
                nameof(this.CreatedBy));

        private void ValidateArticleId(int articleId)
            => Guard.AgainstOutOfRange<InvalidCommentException>(
                articleId,
                ModelConstants.Common.Zero,
                int.MaxValue,
                nameof(this.ArticleId));
    }
}
