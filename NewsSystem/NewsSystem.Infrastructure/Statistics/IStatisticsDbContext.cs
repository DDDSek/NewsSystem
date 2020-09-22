namespace NewsSystem.Infrastructure.Statistics
{
    using Microsoft.EntityFrameworkCore;

    using Domain.Statistics.Models;
    using Common.Persistence;

    public interface IStatisticsDbContext : IDbContext
    {
        DbSet<Statistics> Statistics { get; }

        DbSet<ArticleView> ArticleViews { get; }
    }
}
