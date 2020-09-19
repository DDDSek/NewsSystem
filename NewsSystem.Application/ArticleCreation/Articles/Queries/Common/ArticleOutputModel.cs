namespace NewsSystem.Application.ArticleCreation.Articles.Queries.Common
{
    using Application.Common.Mapping;
    using AutoMapper;
    using NewsSystem.Domain.ArticleCreation.Models.Articles;

    public class ArticleOutputModel : IMapFrom<Article>
    {
        public int Id { get; private set; }

        public string Manufacturer { get; private set; } = default!;

        public string Model { get; private set; } = default!;

        public string ImageUrl { get; private set; } = default!;

        public string Category { get; private set; } = default!;

        public decimal PricePerDay { get; private set; }

        public virtual void Mapping(Profile mapper)
            => mapper
                .CreateMap<Article, ArticleOutputModel>()
                .ForMember(ad => ad.Manufacturer, cfg => cfg
                    .MapFrom(ad => ad.Manufacturer.Name))
                .ForMember(ad => ad.Category, cfg => cfg
                    .MapFrom(ad => ad.Category.Name));
    }
}
