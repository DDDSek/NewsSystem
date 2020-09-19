namespace NewsSystem.Application.ArticleCreation.Articles.Commands.Delete
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common;
    using Application.Common.Contracts;
    using Common; 
    using MediatR;
    using Application.ArticleCreation.Journalists;

    public class DeleteArticleCommand : EntityCommand<int>, IRequest<Result>
    {
        public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly IArticleRepository articleRepository;
            private readonly IJournalistRepository journalistRepository;

            public DeleteArticleCommandHandler(
                ICurrentUser currentUser,
                IArticleRepository articleRepo,
                IJournalistRepository journalistRepo)
            {
                this.currentUser = currentUser;
                this.articleRepository = articleRepo;
                this.journalistRepository = journalistRepo;
            }

            public async Task<Result> Handle(
                DeleteArticleCommand request,
                CancellationToken cancellationToken)
            {
                var journalistHasArticle = await this.currentUser.JournalistHasArticle(
                    this.journalistRepository,
                    request.Id,
                    cancellationToken);

                if (!journalistHasArticle)
                {
                    return journalistHasArticle;
                }

                return await this.articleRepository.Delete(
                    request.Id,
                    cancellationToken);
            }
        }
    }
}
