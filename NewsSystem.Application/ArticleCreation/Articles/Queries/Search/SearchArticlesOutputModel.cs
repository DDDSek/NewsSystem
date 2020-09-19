namespace NewsSystem.Application.ArticleCreation.Articles.Queries.Search
{
    using System.Collections.Generic;
    using Common;

    public class SearchArticlesOutputModel : ArticlesOutputModel<ArticleOutputModel>
    {
        public SearchArticlesOutputModel(
            IEnumerable<ArticleOutputModel> articles,
            int page,
            int totalPages)
            : base(articles, page, totalPages)
        {
        }
    }
}
