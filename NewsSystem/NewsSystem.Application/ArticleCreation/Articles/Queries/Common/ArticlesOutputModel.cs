namespace NewsSystem.Application.ArticleCreation.Articles.Queries.Common
{
    using System.Collections.Generic;

    public abstract class ArticlesOutputModel<TArticleOutputModel>
    {
        internal ArticlesOutputModel(
            IEnumerable<TArticleOutputModel> articles,
            int page,
            int totalPages)
        {
            this.Articles = articles;
            this.Page = page;
            this.TotalPages = totalPages;
        }

        public IEnumerable<TArticleOutputModel> Articles { get; }

        public int Page { get; }

        public int TotalPages { get; }
    }
}
