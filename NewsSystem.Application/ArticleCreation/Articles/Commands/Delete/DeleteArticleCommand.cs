namespace NewsSystem.Application.ArticleCreation.Articles.Commands.Delete
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common;
    using Application.Common.Contracts;
    using Common; 
    using MediatR;

    public class DeleteArticleCommand : EntityCommand<int>, IRequest<Result>
    {
        public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly IArticleRepository articleRepository;
            private readonly IDealerRepository dealerRepository;

            public DeleteArticleCommandHandler(
                ICurrentUser currentUser,
                IArticleRepository articleRepository,
                IDealerRepository dealerRepository)
            {
                this.currentUser = currentUser;
                this.articleRepository = articleRepository;
                this.dealerRepository = dealerRepository;
            }

            public async Task<Result> Handle(
                DeleteArticleCommand request,
                CancellationToken cancellationToken)
            {
                var dealerHasArticle = await this.currentUser.DealerHasArticle(
                    this.dealerRepository,
                    request.Id,
                    cancellationToken);

                if (!dealerHasArticle)
                {
                    return dealerHasArticle;
                }

                return await this.articleRepository.Delete(
                    request.Id,
                    cancellationToken);
            }
        }
    }
}
