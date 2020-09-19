namespace NewsSystem.Domain.ArticleCreation.Models.Journalists
{
    using System.Collections.Generic;
    using System.Linq; 

    using Common;
    using Exceptions;
    using NewsSystem.Domain.ArticleCreation.Models.Articles;

    public class Journalist : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<Article> articles;

        private static readonly IEnumerable<Category> AllowedCategories
            = new CategoryData().GetData().Cast<Category>();

        internal Journalist(string name, string phoneNumber)
        {
            this.Validate(name); 

            this.Name = name;
            this.PhoneNumber = phoneNumber; 
            this.articles = new HashSet<Article>();
        }

        private Journalist(string name)
        {
            this.Name = name;
            this.PhoneNumber = default!; 

            this.articles = new HashSet<Article>();
        }

        public string Name { get; private set; }

        public PhoneNumber PhoneNumber { get; private set; }

        public Journalist UpdateName(string name)
        {
            this.Validate(name);
            this.Name = name;

            return this;
        }

        public Journalist UpdatePhoneNumber(string phoneNumber)
        {
            this.PhoneNumber = phoneNumber;

            return this;
        }

        public IReadOnlyCollection<Article> Articles => this.Articles.ToList().AsReadOnly();

        public void AddArticle(Article Article) => this.articles.Add(Article);

        private void Validate(string name)
            => Guard.ForStringLength<InvalidJournalistException>(
                name,
                Models.ModelConstants.Journalist.MinNameLength,
                Models.ModelConstants.Journalist.MaxNameLength,
                nameof(this.Name));
    }
}
