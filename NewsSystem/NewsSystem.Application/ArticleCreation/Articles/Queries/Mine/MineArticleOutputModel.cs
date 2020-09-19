namespace NewsSystem.Application.ArticleCreation.Articles.Queries.Mine
{
    using AutoMapper;
    using Common;
    using NewsSystem.Domain.ArticleCreation.Models.Articles;

    public class MineArticleOutputModel : ArticleOutputModel
    {
        public bool IsAvailable { get; private set; }

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Article, MineArticleOutputModel>()
                .IncludeBase<Article, ArticleOutputModel>();
    }
}
