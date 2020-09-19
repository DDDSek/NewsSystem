namespace NewsSystem.Infrastructure.ArticleCreation.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks; 

    using Microsoft.EntityFrameworkCore;

    using AutoMapper;
    using Identity;

    using Common.Persistence;

    using Application.ArticleCreation.Journalists;
    using Application.ArticleCreation.Journalist.Queries.Details;
    using Application.ArticleCreation.Journalist.Queries.Common;

    using Domain.Exceptions;
    using Domain.ArticleCreation.Models.Journalists;

    internal class JournalistRepository : DataRepository<IArticleCreationDbContext, Journalist>, IJournalistRepository
    {
        private readonly IMapper mapper;

        public JournalistRepository(IArticleCreationDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<bool> HasArticle(int journalistId, int articleId, CancellationToken cancellationToken = default)
            => await this
                .All()
                .Where(j => j.Id == journalistId)
                .AnyAsync(j => j.Articles
                    .Any(c => c.Id == articleId), cancellationToken);

        public async Task<JournalistDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<JournalistDetailsOutputModel>(this
                    .All()
                    .Where(d => d.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<JournalistOutputModel> GetDetailsByArticleId(int articleId, CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<JournalistOutputModel>(this
                    .All()
                    .Where(d => d.Articles.Any(c => c.Id == articleId)))
                .SingleOrDefaultAsync(cancellationToken);

        public Task<int> GetJournalistId(
            string userId,
            CancellationToken cancellationToken = default)
            => this.FindByUser(userId, user => user.Journalist!.Id, cancellationToken);

        public Task<Journalist> FindByUser(
            string userId,
            CancellationToken cancellationToken = default)
            => this.FindByUser(userId, user => user.Journalist!, cancellationToken);

        private async Task<T> FindByUser<T>(
            string userId,
            Expression<Func<User, T>> selector,
            CancellationToken cancellationToken = default)
        {
            var journalistData = await this
                .Data
                .Users
                .Where(u => u.Id == userId)
                .Select(selector)
                .FirstOrDefaultAsync(cancellationToken);

            if (journalistData == null)
            {
                throw new InvalidJournalistException("This user is not a journalist.");
            }

            return journalistData;
        }
    }
}
