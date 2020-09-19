namespace NewsSystem.Application.ArticleCreation.Articles.Queries.Details
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common; 
    using MediatR;

    public class ArticleDetailsQuery : EntityCommand<int>, IRequest<ArticleDetailsOutputModel>
    {
        public class ArticleDetailsQueryHandler : IRequestHandler<ArticleDetailsQuery, ArticleDetailsOutputModel>
        {
            private readonly IArticleRepository articleRepository;
            private readonly IDealerRepository dealerRepository;

            public ArticleDetailsQueryHandler(
                IArticleRepository articleRepository,
                IDealerRepository dealerRepository)
            {
                this.articleRepository = articleRepository;
                this.dealerRepository = dealerRepository;
            }

            public async Task<ArticleDetailsOutputModel> Handle(
                ArticleDetailsQuery request,
                CancellationToken cancellationToken)
            {
                var articleDetails = await this.articleRepository.GetDetails(
                    request.Id,
                    cancellationToken);

                articleDetails.Dealer = await this.dealerRepository.GetDetailsByArticleId(
                    request.Id,
                    cancellationToken);

                return articleDetails;
            }
        }
    }
}
