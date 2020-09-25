namespace NewsSystem.Domain.Statistics.Models
{
    using Domain.Common.Models;

    public class ArticleView : Entity<int>
    {
        internal ArticleView(int аrticleId, string? userId)
        {
            this.ArticleId = аrticleId;
            this.UserId = userId;
        }

        private ArticleView()
        {
            this.ArticleId = default!;
            this.UserId = default!;
        }

        public int ArticleId { get; }

        public string? UserId { get; }
    }
}
