namespace NewsSystem.Domain.Models.CreateArticle.Journalist
{
    using System.Collections.Generic;
    using System.Linq;
    using CreateArticle.Article;
    using Common;
    using Exceptions;

    using static ModelConstants.Journalist;
    public class Journalist : Entity<int>, IAggregateRoot
    {
        private readonly HashSet<Article> articles;

        private static readonly IEnumerable<Category> AllowedCategories
            = new CategoryData().GetData().Cast<Category>();

        internal Journalist(string name, string phoneNumber, Category category)
        {
            this.Validate(name);
            this.ValidateCategory(category);

            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.Category = category;
            this.articles = new HashSet<Article>();
        }

        private Journalist(string name)
        {
            this.Name = name;
            this.PhoneNumber = default!;
            this.Category = default!;

            this.articles = new HashSet<Article>();
        }

        public string Name { get; private set; }

        public PhoneNumber PhoneNumber { get; private set; }

        public Category Category { get; private set; }

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
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));

        private void ValidateCategory(Category category)
        {
            var categoryName = category?.Name;

            if (AllowedCategories.Any(c => c.Name == categoryName))
            {
                return;
            }

            var allowedCategoryNames = string.Join(", ", AllowedCategories.Select(c => $"'{c.Name}'"));

            throw new InvalidArticleException($"'{categoryName}' is not a valid category. Allowed values are: {allowedCategoryNames}.");
        }
    }
}
