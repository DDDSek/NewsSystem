namespace NewsSystem.Application.ArticleCreation.Journalist
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Contracts; 
    using Queries.Common;
    using Queries.Details;
    using Domain.ArticleCreation.Models.Journalists;

    public interface IJournalistRepository : IRepository<Journalist>
    {
        Task<Journalist> FindByUser(string userId, CancellationToken cancellationToken = default);

        Task<int> GetJournalistId(string userId, CancellationToken cancellationToken = default);

        Task<bool> HasArticle(int journalistId, int articleId, CancellationToken cancellationToken = default);

        Task<JournalistDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);

        Task<JournalistOutputModel> GetDetailsByArticle(int articleId, CancellationToken cancellationToken = default);
    }
}
