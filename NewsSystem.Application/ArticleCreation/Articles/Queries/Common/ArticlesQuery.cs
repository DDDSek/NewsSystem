namespace NewsSystem.Application.ArticleCreation.Articles.Queries.Common
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Common; 

    public abstract class ArticlesQuery
    {
        private const int ArticlesPerPage = 10;

        public string? Manufacturer { get; set; }

        public int? Category { get; set; }

        public string? Dealer { get; set; }

        public decimal? MinPricePerDay { get; set; }

        public decimal? MaxPricePerDay { get; set; }

        public string? SortBy { get; set; }

        public string? Order { get; set; }

        public int Page { get; set; } = 1;

        public abstract class CarAdsQueryHandler
        {
            private readonly IArticleRepository articleRepository;

            protected CarAdsQueryHandler(IArticleRepository articleRepository)
                => this.articleRepository = articleRepository;

            protected async Task<IEnumerable<TOutputModel>> GetArticleListings<TOutputModel>(
                ArticlesQuery request,
                bool onlyAvailable = true,
                int? dealerId = default,
                CancellationToken cancellationToken = default)
            {
                var articleSpecification = this.GetArticleSpecification(request, onlyAvailable);

                var dealerSpecification = this.GetDealerSpecification(request, dealerId);

                var searchOrder = new ArticlesSortOrder(request.SortBy, request.Order);

                var skip = (request.Page - 1) * ArticlesPerPage;

                return await this.articleRepository.GetArticleListings<TOutputModel>(
                    articleSpecification,
                    dealerSpecification,
                    searchOrder,
                    skip,
                    take: ArticlesPerPage,
                    cancellationToken);
            }

            protected async Task<int> GetTotalPages(
                ArticlesQuery request,
                bool onlyAvailable = true,
                int? dealerId = default,
                CancellationToken cancellationToken = default)
            {
                var articleSpecification = this.GetArticleSpecification(request, onlyAvailable);

                var dealerSpecification = this.GetDealerSpecification(request, dealerId);

                var totalArticles = await this.articleRepository.Total(
                    articleSpecification,
                    dealerSpecification,
                    cancellationToken);

                return (int)Math.Ceiling((double)totalArticles / ArticlesPerPage);
            }

            private Specification<Article> GetArticleSpecification(ArticlesQuery request, bool onlyAvailable)
                => new ArticleByManufacturerSpecification(request.Manufacturer)
                    .And(new ArticleByCategorySpecification(request.Category))
                    .And(new ArticleByPricePerDaySpecification(request.MinPricePerDay, request.MaxPricePerDay))
                    .And(new ArticleOnlyAvailableSpecification(onlyAvailable));

            private Specification<Dealer> GetDealerSpecification(ArticlesQuery request, int? dealerId)
                => new DealerByIdSpecification(dealerId)
                    .And(new DealerByNameSpecification(request.Dealer));
        }
    }
}
