namespace NewsSystem.Domain.Models.Article
{
    using Common;
    public class Visibility : ValueObject
    {
        internal Visibility(bool approved, bool deleted, ArticlePriority articlePriority)
        {
            this.Approved = approved;
            this.Deleted = deleted;
            this.ArticlePriority = articlePriority;
        }
        private Visibility(bool approved, bool deleted)
        {
            this.Approved = approved;
            this.Deleted = deleted;

            this.ArticlePriority = default!;
        }

        public bool Approved { get; }

        public bool Deleted { get; }

        public ArticlePriority ArticlePriority { get; }
    }
}
