namespace NewsSystem.Application.ArticleCreation.Articles.Queries.Mine
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Contracts;
    using Common; 
    using MediatR;

    public class MineArticlesQuery : ArticlesQuery, IRequest<MineArticlesOutputModel>
    {
        public class MineArticlesQueryHandler : ArticlesQueryHandler, IRequestHandler<
            MineArticlesQuery,
            MineArticlesOutputModel>
        {
            private readonly IDealerRepository dealerRepository;
            private readonly ICurrentUser currentUser;

            public MineArticlesQueryHandler(
                IArticleRepository articleRepository,
                IDealerRepository dealerRepository,
                ICurrentUser currentUser)
                : base(articleRepository)
            {
                this.currentUser = currentUser;
                this.dealerRepository = dealerRepository;
            }

            public async Task<MineArticlesOutputModel> Handle(
                MineArticlesQuery request,
                CancellationToken cancellationToken)
            {
                var dealerId = await this.dealerRepository.GetDealerId(
                    this.currentUser.UserId,
                    cancellationToken);

                var mineCarAdListings = await base.GetCarAdListings<MineArticleOutputModel>(
                    request,
                    onlyAvailable: false,
                    dealerId,
                    cancellationToken);

                var totalPages = await base.GetTotalPages(
                    request,
                    onlyAvailable: false,
                    dealerId,
                    cancellationToken);

                return new MineArticlesOutputModel(mineArticleListings, request.Page, totalPages);
            }
        }
    }
}
