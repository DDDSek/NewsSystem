namespace NewsSystem.Application.ArticleCreation.Articles.Commands.Create
{
    using FluentValidation;
    using Common;

    public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
    {
        public CreateArticleCommandValidator(IArticleRepository articleRepository)
            => this.Include(new ArticleCommandValidator<CreateArticleCommand>(articleRepository));
    }
}
}
