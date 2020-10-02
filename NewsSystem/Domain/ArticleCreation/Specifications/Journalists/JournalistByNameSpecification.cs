namespace NewsSystem.Domain.ArticleCreation.Specifications.Journalists
{
    using System;
    using System.Linq.Expressions;
    using Common;
    using Models.Journalists; 

    public class JournalistByNameSpecification : Specification<Journalist>
    {
        private readonly string? name;

        public JournalistByNameSpecification(string? name) 
            => this.name = name;

        protected override bool Include => this.name != null;

        public override Expression<Func<Journalist, bool>> ToExpression()
            => journalist => journalist.Name.ToLower().Contains(this.name!.ToLower());
    }
}
