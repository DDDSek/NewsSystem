namespace NewsSystem.Application.ArticleCreation.Articles.Commands.Edit
{
    using System.Threading;
    using System.Threading.Tasks;

    using Application.Common;
    using Application.Common.Contracts;
    using Common;

    using MediatR;
    using NewsSystem.Application.ArticleCreation.Journalist;

    public class EditArticleCommand : ArticleCommand<EditArticleCommand>, IRequest<Result>
    {
        public class EditArticleCommandHandler : IRequestHandler<EditArticleCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly IArticleRepository articleRepository;
            private readonly IJournalistRepository dealerRepository;

            public EditArticleCommandHandler(
                ICurrentUser currentUser,
                IArticleRepository articleRepository,
                IJournalistRepository dealerRepository)
            {
                this.currentUser = currentUser;
                this.articleRepository = articleRepository;
                this.dealerRepository = dealerRepository;
            }

            public async Task<Result> Handle(
                EditArticleCommand request,
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

                var category = await this.articleRepository.GetCategory(
                    request.Category,
                    cancellationToken);

                var article = await this.articleRepository
                    .Find(request.Id, cancellationToken);

                article
                    .UpdateManufacturer(request.Manufacturer)
                    .UpdateModel(request.Model)
                    .UpdateCategory(category)
                    .UpdateImageUrl(request.ImageUrl)
                    .UpdatePricePerDay(request.PricePerDay)
                    .UpdateOptions(
                        request.HasClimateControl,
                        request.NumberOfSeats,
                        Enumeration.FromValue<TransmissionType>(request.TransmissionType));

                await this.articleRepository.Save(article, cancellationToken);

                return Result.Success;
            }
        }
    }
}
