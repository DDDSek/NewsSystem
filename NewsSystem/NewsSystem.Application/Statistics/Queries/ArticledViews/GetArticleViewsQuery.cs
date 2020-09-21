namespace NewsSystem.Application.Statistics.Queries.CarAdViews
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class GetArticleViewsQuery : IRequest<int>
    {
        public int CarAdId { get; set; }

        public class GetCarAdViewsQueryHandler : IRequestHandler<GetArticleViewsQuery, int>
        {
            private readonly IStatisticsRepository statistics;

            public GetCarAdViewsQueryHandler(IStatisticsRepository statistics)
                => this.statistics = statistics;

            public Task<int> Handle(
                GetArticleViewsQuery request,
                CancellationToken cancellationToken)
                => this.statistics.GetCarAdViews(request.CarAdId, cancellationToken);
        }
    }
}
