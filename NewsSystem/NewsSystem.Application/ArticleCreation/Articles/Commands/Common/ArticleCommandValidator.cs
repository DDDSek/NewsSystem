﻿namespace NewsSystem.Application.ArticleCreation.Articles.Commands.Common
{
    using System;

    using FluentValidation;

    using Application.Common;
    using NewsSystem.Domain.Common.Models;
    using NewsSystem.Domain.ArticleCreation.Models.Articles;

    public class ArticleCommandValidator<TCommand> : AbstractValidator<ArticleCommand<TCommand>>
        where TCommand : EntityCommand<int>
    {
        public ArticleCommandValidator(IArticleRepository carAdRepository)
        {
            this.RuleFor(c => c.Title)
                .MinimumLength(Domain.ArticleCreation.Models.ModelConstants.Article.MinTitleLength)
                .MaximumLength(Domain.ArticleCreation.Models.ModelConstants.Article.MaxTitleLength)
                .NotEmpty();

            this.RuleFor(c => c.Content)
                .MinimumLength(Domain.ArticleCreation.Models.ModelConstants.Article.MinContentLength)
                .MaximumLength(Domain.ArticleCreation.Models.ModelConstants.Article.MaxContentLength)
                .NotEmpty();

            this.RuleFor(c => c.Category)
                .MustAsync(async (category, token) => await carAdRepository
                    .GetCategory(category, token) != null)
                .WithMessage("'{PropertyName}' does not exist.");

            this.RuleFor(c => c.ImageUrl)
                .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
                .WithMessage("'{PropertyName}' must be a valid url.")
                .NotEmpty();

            this.RuleFor(c => c.ArticlePriority)
                .Must(Enumeration.HasValue<ArticlePriority>)
                .WithMessage("'ArticlePriority Type' is not valid.");
        }
    }
}
