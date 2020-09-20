namespace NewsSystem.Application.ArticleCreation.Articles.Commands.Edit
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Common;
    using Application.Common.Contracts;
    using NewsSystem.Application.Common;

    public class EditCommentCommand : CommentCommand<EditCommentCommand>, IRequest<Result>
    { 
        public class EditCommentCommandHandler : IRequestHandler<EditCommentCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly IArticleRepository articleRepository;

            public EditCommentCommandHandler(
                ICurrentUser currentUser,
                IArticleRepository articleRepository,
                ICommentRepository commentRepository
                )
            {
                this.currentUser = currentUser;
                this.articleRepository = articleRepository;
            }

            public async Task<Result> Handle(
                EditCommentCommand request,
                CancellationToken cancellationToken)
            {
                var article = await this.articleRepository.Find(
                    request.ArticleId,
                    cancellationToken);

                //var article = await this.articleRepository.Find(
                //    request.ArticleId,
                //    cancellationToken);

                var comment = article.Comments.Where(c => c.Id == request.Id);

                article
                    .UpdateComment(request.Title, request.Content, currentUser.UserId, article.Id);

                await this.articleRepository.Save(article, cancellationToken);

                return Result.Success;
            }
        }
    }
}
