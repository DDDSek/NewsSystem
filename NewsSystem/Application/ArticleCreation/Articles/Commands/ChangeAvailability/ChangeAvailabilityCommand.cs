namespace NewsSystem.Application.ArticleCreation.Articles.Commands.ChangeAvailability
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common;
    using Application.Common.Contracts;
    using Common;
    using Journalists;
    using MediatR;

    public class ChangeAvailabilityCommand : EntityCommand<int>, IRequest<Result>
    {
        public class ChangeAvailabilityCommandHandler : IRequestHandler<ChangeAvailabilityCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly IArticleRepository articleRepository;
            private readonly IJournalistRepository journalistRepository;

            public ChangeAvailabilityCommandHandler(
                ICurrentUser currentUser,
                IArticleRepository articleRepository,
                IJournalistRepository journalistRepository)
            {
                this.currentUser = currentUser;
                this.articleRepository = articleRepository;
                this.journalistRepository = journalistRepository;
            }

            public async Task<Result> Handle(
                ChangeAvailabilityCommand request, 
                CancellationToken cancellationToken)
            {
                //var journalistHasArticle = await this.currentUser.JournalistHasArticle(
                //    this.journalistRepository,
                //    request.Id,
                //    cancellationToken);

                //if (!journalistHasArticle)
                //{
                //    return journalistHasArticle;
                //}

                var article = await this.articleRepository
                    .Find(request.Id, cancellationToken);

                article.ChangeAvailability();

                await this.articleRepository.Save(article, cancellationToken);

                return Result.Success;
            }
        }
    }
}
