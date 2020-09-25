namespace NewsSystem.Domain.ArticleCreation.Models.Articles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    internal class ArticleData : IInitialData
    {
        public Type EntityType => typeof(Article);

        //private static readonly IEnumerable<Category> AllowedCategories
        //    = new CategoryData().GetData().Cast<Category>();

        public IEnumerable<object> GetData()
            => new List<Article>
            {
                new Article(
                    "Cats title",
                    "When Ian Patella's cat got stuck in a tree late last week, his family's local contractor came to the rescue.",
                    new Category("Business", "Business is a financial news and information website."),
                    "https://cdn.pixabay.com/photo/2020/04/27/09/21/cat-5098930_960_720.jpg",
                    ArticlePriority.Daily,
                    true),
                new Article(
                    "The Super cat",
                    "This is the most difficult action game in the world. It is full of infinite challenge and traps, made for only the most experienced gamers.",
                    new Category ("Business", "bbbbbbcxcxcxcxcxcxcxcxcxcxcccxcx"),
                    "https://cdn.pixabay.com/photo/2020/04/27/09/21/cat-5098930_960_720.jpg",
                    ArticlePriority.Daily,
                    true),
                new Article(
                    "How coronavirus",
                    "Since the outset of the coronavirus pandemic, the potential role of animals in catching and spreading the disease has been closely examined by scientists. This is because the virus that causes Covid-19 belongs to the family of coronaviruses that cause disease in a variety of mammals.",
                    new Category ("World", "fdsfsfdcxcxcxcxcxcxcfdfdfdf"),
                    "https://cdn.pixabay.com/photo/2020/04/27/09/21/cat-5098930_960_720.jpg",
                    ArticlePriority.Daily,
                    true),
                new Article(
                    "International Cat Day",
                    "The 8 August marks International Cat Day, an annual event that has been celebrated since 2002. It was originally created by the International Fund for Animal Welfare which works to raise awareness for felines, from big cats to domestic pets, and educate people on how to look after and protect them.",
                    new Category ("Political", "fdsfsfdfxcxcxcxcxcxcxcxcxdfdfdf"),
                    "https://cdn.pixabay.com/photo/2020/04/27/09/21/cat-5098930_960_720.jpg",
                    ArticlePriority.Daily,
                    true),
            };
    }
}
