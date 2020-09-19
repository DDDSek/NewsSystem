﻿namespace NewsSystem.Domain.ArticleCreation.Factories.Journalists
{
    using Models.Journalists;
    using NewsSystem.Domain.ArticleCreation.Models.Articles;

    internal class JournalistFactory : IJournalistFactory
    {
        private string journalistName = default!;
        private string journalistPhoneNumber = default!;
        private Category articleCategory = default!;

        public IJournalistFactory WithName(string name)
        {
            this.journalistName = name;
            return this;
        }

        public IJournalistFactory WithPhoneNumber(string phoneNumber)
        {
            this.journalistPhoneNumber = phoneNumber;
            return this;
        }

        public Journalist Build() => new Journalist(this.journalistName, this.journalistPhoneNumber);

        public Journalist Build(string name, string phoneNumber)
            => this
                .WithName(name)
                .WithPhoneNumber(phoneNumber)
                .Build();
    }
}
