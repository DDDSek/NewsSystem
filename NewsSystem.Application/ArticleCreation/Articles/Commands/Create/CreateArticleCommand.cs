namespace NewsSystem.Application.ArticleCreation.Articles.Commands.Create
{
    using System.Threading;
    using System.Threading.Tasks;

    using Common;
    using MediatR;

    using Application.Common.Contracts;
    using NewsSystem.Application.ArticleCreation.Journalist;

    public class CreateArticleCommand : ArticleCommand<CreateArticleCommand>, IRequest<CreateArticleOutputModel>
    {
        public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, CreateArticleOutputModel>
        {
            private readonly ICurrentUser currentUser;
            private readonly IJournalistRepository journalistRepository;
            private readonly IArticleRepository articleRepository;
            private readonly IArticleFactory articleFactory;

            public CreateArticleCommandHandler(
                ICurrentUser currentUser,
                IJournalistRepository journalistRepository,
                IArticleRepository articleRepository,
                IArticleFactory articleFactory)
            {
                this.currentUser = currentUser;
                this.journalistRepository = journalistRepository;
                this.articleRepository = articleRepository;
                this.articleFactory = articleFactory;
            }

            public async Task<CreateArticleOutputModel> Handle(
                CreateArticleCommand request,
                CancellationToken cancellationToken)
            {
                var journalist = await this.journalistRepository.FindByUser(
                    this.currentUser.UserId,
                    cancellationToken);

                var category = await this.articleRepository.GetCategory(
                    request.Category,
                    cancellationToken);

                var manufacturer = await this.articleRepository.GetManufacturer(
                    request.Manufacturer,
                    cancellationToken);

                var factory = manufacturer == null
                    ? this.articleFactory.WithManufacturer(request.Manufacturer)
                    : this.articleFactory.WithManufacturer(manufacturer);

                var article = factory
                    .WithModel(request.Model)
                    .WithCategory(category)
                    .WithImageUrl(request.ImageUrl)
                    .WithPricePerDay(request.PricePerDay)
                    .WithOptions(
                        request.HasClimateControl,
                        request.NumberOfSeats,
                        Enumeration.FromValue<TransmissionType>(request.TransmissionType))
                    .Build();

                journalist.AddArticle(article);

                await this.articleRepository.Save(article, cancellationToken);

                return new CreateArticleOutputModel(article.Id);
            }
        }
    }
}
