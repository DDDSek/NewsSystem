namespace NewsSystem.Application.ArticleCreation.Articles.Queries.Common
{
    using System;
    using System.Linq.Expressions;

    using Domain.ArticleCreation.Models.Articles;
    using Domain.Common;

    public class ArticleByCategorySpecification : Specification<Article>
    {
        private readonly int? category;

        public ArticleByCategorySpecification(int? category)
            => this.category = category;

        protected override bool Include => this.category != null;

        public override Expression<Func<Article, bool>> ToExpression()
            => article => article.Category.Id == this.category;
    }
}