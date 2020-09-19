namespace NewsSystem.Domain.ArticleCreation.Factories.Articles
{
    using Common;
    using Models.Articles;

    public interface IArticleFactory : IFactory<Article>
    {
        IArticleFactory WithCategory(string name, string description);

        IArticleFactory WithCategory(Category category);

        IArticleFactory WithComment(string title, string content, string createdBy);

        IArticleFactory WithComment(Comment manufacturer);

        //IArticleFactory WithModel(string model);

        IArticleFactory WithImageUrl(string imageUrl);

        IArticleFactory WithArticlePriority(ArticlePriority priority)

        //IArticleFactory WithPricePerDay(decimal pricePerDay);

        //IArticleFactory WithOptions(
        //    bool hasClimateControl,
        //    int numberOfSeats,
        //    TransmissionType transmissionType);
    }
}
