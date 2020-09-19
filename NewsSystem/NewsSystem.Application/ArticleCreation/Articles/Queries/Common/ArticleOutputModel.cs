namespace NewsSystem.Application.ArticleCreation.Articles.Queries.Common
{
    using AutoMapper;

    using Application.Common.Mapping;

    using Domain.ArticleCreation.Models.Articles;

    public class ArticleOutputModel : IMapFrom<Article>
    {
        public int Id { get; private set; }

        public string Title { get; private set; } = default!;

        public string Content { get; private set; } = default!;

        public string Category { get; private set; } = default!;

        public string ImageUrl { get; private set; } = default!;

        public string ArticlePriority { get; private set; } = default!;

        public virtual void Mapping(Profile mapper)
            => mapper
                .CreateMap<Article, ArticleOutputModel>()
                .ForMember(ar => ar.Category, cfg => cfg
                    .MapFrom(ar => ar.Category.Name))
                .ForMember(ar => ar.ArticlePriority, cfg => cfg
                    .MapFrom(ar => ar.ArticlePriority.Name));
    }
}
