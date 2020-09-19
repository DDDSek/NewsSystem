namespace NewsSystem.Domain.ArticleCreation.Specifications.Articles
{
    using System;
    using System.Linq.Expressions;
    using Common;
    using Models.Articles;

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
