namespace NewsSystem.Application.ArticleCreation.Articles.Commands.Delete
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Application.Common;
    using Application.Common.Contracts;
    using Application.ArticleCreation.Articles.Commands.Common;

    public class DeleteCommentCommand : CommentCommand<DeleteCommentCommand>, IRequest<Result>
    {
        public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, Result>
        {
            private readonly IArticleRepository articleRepository; 

            public DeleteCommentCommandHandler(
                IArticleRepository articleRepository
                )
            {
                this.articleRepository = articleRepository; 
            }

            public async Task<Result> Handle(
                DeleteCommentCommand request,
                CancellationToken cancellationToken)
            {
                return await this.articleRepository.DeleteComment(
                    request.Id,
                    request.ArticleId,
                    cancellationToken);
            }
        }
    }
}
