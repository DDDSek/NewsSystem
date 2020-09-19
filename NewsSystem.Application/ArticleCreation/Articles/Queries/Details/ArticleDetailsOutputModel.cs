namespace NewsSystem.Application.ArticleCreation.Articles.Queries.Details
{
    using AutoMapper;
    using Common;
    using NewsSystem.Domain.ArticleCreation.Models.Articles;

    public class ArticleDetailsOutputModel : ArticleOutputModel
    {
        public bool HasClimateControl { get; private set; }

        public int NumberOfSeats { get; private set; }

        public string TransmissionType { get; private set; } = default!;

        public DealerOutputModel Dealer { get; set; } = default!;

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<Article, ArticleDetailsOutputModel>()
                .IncludeBase<Article, ArticleOutputModel>()
                .ForMember(c => c.HasClimateControl, cfg => cfg
                    .MapFrom(c => c.Options.HasClimateControl))
                .ForMember(c => c.NumberOfSeats, cfg => cfg
                    .MapFrom(c => c.Options.NumberOfSeats))
                .ForMember(c => c.TransmissionType, cfg => cfg
                    .MapFrom(c => Enumeration.NameFromValue<TransmissionType>(
                        c.Options.TransmissionType.Value)));
    }
}
