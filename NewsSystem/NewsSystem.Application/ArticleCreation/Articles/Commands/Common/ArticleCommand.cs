namespace NewsSystem.Application.ArticleCreation.Articles.Commands.Common
{
    using Application.Common;

    public abstract class ArticleCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public string Title { get; set; } = default!;

        public string Content { get; set; } = default!;

        public int Category { get; set; }

        public string ImageUrl { get; set; } = default!;

        public int ArticlePriority { get; set; } 
    }
}
