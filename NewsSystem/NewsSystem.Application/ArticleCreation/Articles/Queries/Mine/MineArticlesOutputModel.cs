namespace NewsSystem.Application.ArticleCreation.Articles.Queries.Mine
{
    using System.Collections.Generic;
    using Common;

    public class MineArticlesOutputModel : ArticlesOutputModel<MineArticleOutputModel>
    {
        public MineArticlesOutputModel(
            IEnumerable<MineArticleOutputModel> articles,
            int page,
            int totalPages)
            : base(articles, page, totalPages)
        {
        }
    }
}
