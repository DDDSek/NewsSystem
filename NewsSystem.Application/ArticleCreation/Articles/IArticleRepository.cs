namespace NewsSystem.Application.ArticleCreation.Articles
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Contracts;
    using Domain.Common;
    using NewsSystem.Application.ArticleCreation.Articles.Queries.Categories;
    using NewsSystem.Application.ArticleCreation.Articles.Queries.Common;
    using NewsSystem.Application.ArticleCreation.Articles.Queries.Details;
    using NewsSystem.Domain.ArticleCreation.Models.Articles;

    public interface IArticleRepository : IRepository<Article>
    {
        Task<Article> Find(int id, CancellationToken cancellationToken = default);

        Task<bool> Delete(int id, CancellationToken cancellationToken = default);

        Task<Category> GetCategory(
            int categoryId,
            CancellationToken cancellationToken = default);

        Task<Manufacturer> GetManufacturer(
            string manufacturer,
            CancellationToken cancellationToken = default);

        Task<IEnumerable<TOutputModel>> GetArticleListings<TOutputModel>(
            Specification<Article> articleSpecification,
            Specification<Journalist> dealerSpecification,
            ArticlesSortOrder articlesSortOrder,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default);

        Task<ArticleDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);

        Task<IEnumerable<GetArticleCategoryOutputModel>> GetArticleCategories(
            CancellationToken cancellationToken = default);

        Task<int> Total(
            Specification<Article> articleSpecification,
            Specification<Journalist> dealerSpecification,
            CancellationToken cancellationToken = default);
    }
}
