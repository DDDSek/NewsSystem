namespace NewsSystem.Domain.ArticleCreation.Models.Articles
{
    using NewsSystem.Domain.Common.Models;

    public class SubComment : Entity<int>
    {
        //TO DO VALIDATE - COMMENT VALIDATION IN CONSTRUCTOR
        internal SubComment(
            string title,
            string content,
            string createdBy,
            int articleId,
            int commentId
            )
        {
            //this.Validate(title, Content);

            this.Title = title;
            this.Content = content;
            this.CreatedBy = createdBy;
            this.ArticleId = articleId;
            this.CommentId = commentId;
        }
        private SubComment(

            string content,
            string createdBy,
            int articleId,
            int commentId
            )
        {
            this.Title = default!;
            this.Content = content;
            this.CreatedBy = createdBy;
            this.ArticleId = articleId;
            this.CommentId = commentId;
        }

        public string Title { get; private set; } = default!;

        public string Content { get; private set; } = default!;

        public string CreatedBy { get; private set; } = default!;

        public int CommentId { get; set; }

        public Comment Comment { get; set; } = default!;

        public int ArticleId { get; private set; }

        public Article Article { get; private set; } = default!;
    }
}
