namespace NewsSystem.Application.ArticleCreation.Articles.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Common;
    using Application.Common.Contracts;

    public class CreateCommentCommand : CommentCommand<CreateCommentCommand>, IRequest<CreateCommentOutputModel>
    {
        public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CreateCommentOutputModel>
        {
            private readonly ICurrentUser currentUser; 
            private readonly IArticleRepository articleRepository;

            public CreateCommentCommandHandler(
                ICurrentUser currentUser, 
                IArticleRepository articleRepository
                )
            {
                this.currentUser = currentUser; 
                this.articleRepository = articleRepository;
            }

            public async Task<CreateCommentOutputModel> Handle(
                CreateCommentCommand request,
                CancellationToken cancellationToken)
            {
                var article = await this.articleRepository.Find(
                    request.ArticleId,
                    cancellationToken);

                article
                    .AddComment(request.Title, request.Content, currentUser.UserId, request.ArticleId);

                await this.articleRepository.Save(article, cancellationToken);

                return new CreateCommentOutputModel(article.Id);
            }
        }
    }
}
