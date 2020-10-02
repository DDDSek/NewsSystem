﻿namespace NewsSystem.Domain.ArticleCreation.Factories.Articles
{
    using Exceptions;
    using NewsSystem.Domain.ArticleCreation.Models.Articles;

    internal class ArticleFactory : IArticleFactory
    {
        private string articleTitle = default!;
        private string articleContent = default!;
        private Category articleCategory = default!;
        private string articleImageUrl = default!;

        private bool categorySet = false;

        public IArticleFactory WithTitle(string title)
        {
            this.articleTitle = title;
            return this;
        }

        public IArticleFactory WithContent(string content)
        {
            this.articleContent = content;
            return this;
        }

        public IArticleFactory WithCategory(string name, string description)
            => this.WithCategory(new Category(name, description));

        public IArticleFactory WithCategory(Category category)
        {
            this.articleCategory = category;
            this.categorySet = true;
            return this;
        }

        public IArticleFactory WithImageUrl(string imageUrl)
        {
            this.articleImageUrl = imageUrl;
            return this;
        }

        public Article Build()
        {
            if (!this.categorySet)
            {
                throw new InvalidArticleException("Category  must have a value.");
            }

            return new Article(
                this.articleTitle,
                this.articleContent,
                this.articleCategory,
                this.articleImageUrl,
                true);
        }
    }
}
