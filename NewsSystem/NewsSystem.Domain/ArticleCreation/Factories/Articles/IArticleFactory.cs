namespace NewsSystem.Domain.ArticleCreation.Factories.Articles
{
    using Common;
    using Models.Articles;

    public interface IArticleFactory : IFactory<Article>
    {
        IArticleFactory WithTitle(string title);
        
        IArticleFactory WithContent(string content);

        IArticleFactory WithCategory(string name, string description);

        IArticleFactory WithCategory(Category category);

        //IArticleFactory WithComment(string title, string content, string createdBy);

        //IArticleFactory AddComment(Comment comment);

        IArticleFactory WithImageUrl(string imageUrl);

        IArticleFactory WithArticlePriority(ArticlePriority priority);
    }
}
