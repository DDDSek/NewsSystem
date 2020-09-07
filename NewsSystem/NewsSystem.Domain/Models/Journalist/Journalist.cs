namespace NewsSystem.Domain.Models.Journalist
{
    using System.Collections.Generic;
    using System.Linq;
    using Article;
    using Common;
    using Exceptions;

    using static ModelConstants.Journalist;
    public class Journalist : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<Article> articles;

        internal Journalist(string name)
        {
            this.ValidateName(name);

            this.Name = name; 

            this.articles = new HashSet<Article>();
        }

        public string Name { get; private set; }

        private void ValidateName(string name)
            => Guard.ForStringLength<InvalidJournalistException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));

        public Journalist UpdateTitle(string name)
        {
            this.ValidateName(name);
            this.Name = name;

            return this;
        }
    }
}
