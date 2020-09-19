using System;
namespace NewsSystem.Domain.Statistics.Models
{
    using NewsSystem.Domain.Common;

    public class ArticleView : Entity<int>
    {
        internal ArticleView(int аrticleId, string? userId)
        {
            this.ArticleId = аrticleId;
            this.UserId = userId;
        }

        public int ArticleId { get; }

        public string? UserId { get; }
    }
}
