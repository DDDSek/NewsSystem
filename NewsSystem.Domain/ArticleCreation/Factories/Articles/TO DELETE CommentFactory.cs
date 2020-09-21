//namespace NewsSystem.Domain.ArticleCreation.Factories.Articles
//{
//    using Exceptions;
//    using NewsSystem.Domain.ArticleCreation.Models.Articles;

//    internal class CommentFactory : ICommentFactory
//    {
//        private string commentTitle = default!;
//        private string commentContent = default!;
//        private string commentCreatedBy = default!;
//        private int commentArticleId = default!; 

//        public ICommentFactory WithTitle(string title)
//        {
//            this.commentTitle = title;
//            return this;
//        }

//        public ICommentFactory WithContent(string content)
//        {
//            this.commentContent = content;
//            return this;
//        }

//        public ICommentFactory WithCreatedBy(string createdBy)
//        {
//            this.commentCreatedBy = createdBy;
//            return this;
//        }

//        public ICommentFactory WithArticleId(int articleId)
//        {
//            this.commentArticleId = articleId;
//            return this;
//        }

//        public Comment Build() => new Comment(this.commentTitle, this.commentContent, this.commentCreatedBy, this.commentArticleId);

//        public Comment Build(string title, string content, string createdBy, int articleId)
//            => this
//                .WithTitle(title)
//                .WithContent(content)
//                .WithCreatedBy(createdBy)
//                .WithArticleId(articleId)
//                .Build();
//    }
//}
