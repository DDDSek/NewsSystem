﻿namespace NewsSystem.Domain.ArticleCreation.Models.Articles
{ 
    using NewsSystem.Domain.Common.Models;

    public class ArticlePriority : Enumeration
    {
        public static readonly ArticlePriority Daily = new ArticlePriority(1, nameof(Daily));
        public static readonly ArticlePriority Weekly = new ArticlePriority(2, nameof(Weekly));
        public static readonly ArticlePriority Monthly = new ArticlePriority(3, nameof(Monthly));
        public static readonly ArticlePriority YearTopTen = new ArticlePriority(4, nameof(YearTopTen));

        private ArticlePriority(int value)
            : this(value, FromValue<ArticlePriority>(value).Name)
        {
        }

        private ArticlePriority(int value, string name)
            : base(value, name)
        {
        }
    }
}