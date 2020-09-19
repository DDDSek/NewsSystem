namespace NewsSystem.Domain.ArticleCreation.Factories.Articles
{
    using Exceptions;
    using NewsSystem.Domain.ArticleCreation.Models.Articles;

    internal class ArticleFactory : IArticleFactory
    {
       // private Manufacturer carAdManufacturer = default!;
        private string articleTitle = default!;
        private string articleContent = default!;
        private Category articleCategory = default!;
        private Comment articleComment;
        private string articleImageUrl = default!;
        private ArticlePriority articlePriority = default!;

        private bool commentSet = false;
        private bool categorySet = false;
        private bool prioritySet = false;

        public IArticleFactory WithCategory(string name, string description)
            => this.WithCategory(new Category(name, description));

        public IArticleFactory WithCategory(Category category)
        {
            this.articleCategory = category;
            this.categorySet = true;
            return this;
        }

        public IArticleFactory WithComment(string title, string content, string createdBy) //manufacturer
            => this.WithComment(new Comment(title, content, createdBy));

        public IArticleFactory WithComment(Comment comment)//manufacturer
        {
            this.articleComment = comment;
            this.commentSet = true;
            return this;
        }

        //public IArticleFactory WithModel(string model)
        //{
        //    this.articleModel = model;
        //    return this;
        //}

        public IArticleFactory WithImageUrl(string imageUrl)
        {
            this.articleImageUrl = imageUrl;
            return this;
        }

        //public IArticleFactory WithPricePerDay(decimal pricePerDay)
        //{
        //    this.articlePricePerDay = pricePerDay;
        //    return this;
        //}

        //public IArticleFactory WithOptions(bool hasClimateControl, int numberOfSeats, TransmissionType transmissionType)
        //    => this.WithOptions(new Options(hasClimateControl, numberOfSeats, transmissionType));

        public IArticleFactory WithArticlePriority(ArticlePriority priority)
        {
            this.articlePriority = priority;
            this.prioritySet = true;
            return this;
        }

        public Article Build()
        {
            if (!this.categorySet || !this.prioritySet)
            {
                throw new InvalidArticleException("Category and article priority must have a value.");
            }

            return new Article(
                this.articleTitle,
                this.articleContent,
                this.articleCategory,
                this.articleComment,
                this.articleImageUrl, 
                this.articlePriority,
                true);
        }
    }
}
