namespace NewsSystem.Domain.ArticleCreation.Models.Articles
{
    using Exceptions;
    using NewsSystem.Domain.Common.Models;

    public class Comment : Entity<int>
    {
        internal Comment(
            string title,
            string content,
            string createdBy
            )
        {
            this.Validate(title, content, createdBy);

            this.Title = title;
            this.Content = content;
            this.CreatedBy = createdBy;
        }

        public string Title { get; private set; }

        public string Content { get; private set; }

        public string CreatedBy { get; private set; }

        private void Validate(string title, string content, string createdBy)
        {
            this.ValidateTitle(title);
            this.ValidateContent(content);
            this.ValidateCreatedBy(createdBy);
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
    }
}
