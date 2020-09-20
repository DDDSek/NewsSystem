namespace NewsSystem.Application.ArticleCreation.Articles.Queries.Details
{
    using AutoMapper;

    using Common;
    using Application.ArticleCreation.Journalist.Queries.Common;

    using Domain.ArticleCreation.Models.Articles;
    using Domain.Common.Models;

    public class ArticleDetailsOutputModel : ArticleOutputModel
    {

        public JournalistOutputModel Journalist { get; set; } = default!;

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Article, ArticleDetailsOutputModel>()
                .IncludeBase<Article, ArticleOutputModel>()
                .ForMember(c => c.ArticlePriority, cfg => cfg
                    .MapFrom(c => Enumeration.NameFromValue<ArticlePriority>(
                        c.ArticlePriority.Value)));
    }
}
