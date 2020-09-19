namespace NewsSystem.Application.ArticleCreation.Articles.Commands.Common
{
    using System;

    using Application.Common;
    using FluentValidation;

    public class ArticleCommandValidator<TCommand> : AbstractValidator<ArticleCommand<TCommand>>
        where TCommand : EntityCommand<int>
    {
        public ArticleCommandValidator(IArticleRepository carAdRepository)
        {
            this.RuleFor(c => c.Manufacturer)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            this.RuleFor(c => c.Model)
                .MinimumLength(MinModelLength)
                .MaximumLength(MaxModelLength)
                .NotEmpty();

            this.RuleFor(c => c.Category)
                .MustAsync(async (category, token) => await carAdRepository
                    .GetCategory(category, token) != null)
                .WithMessage("'{PropertyName}' does not exist.");

            this.RuleFor(c => c.ImageUrl)
                .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
                .WithMessage("'{PropertyName}' must be a valid url.")
                .NotEmpty();

            this.RuleFor(c => c.PricePerDay)
                .InclusiveBetween(Zero, decimal.MaxValue);

            this.RuleFor(c => c.NumberOfSeats)
                .InclusiveBetween(MinNumberOfSeats, MaxNumberOfSeats);

            this.RuleFor(c => c.TransmissionType)
                .Must(Enumeration.HasValue<TransmissionType>)
                .WithMessage("'Transmission Type' is not valid.");
        }
    }
}
