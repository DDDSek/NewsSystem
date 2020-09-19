namespace NewsSystem.Application.ArticleCreation.Journalist.Commands.Edit
{
    using FluentValidation;
    using Domain.ArticleCreation.Models;

    public class EditJournalistCommandValidator : AbstractValidator<EditJournalistCommand>
    {
        public EditJournalistCommandValidator()
        {
            this.RuleFor(u => u.Name)
                .MinimumLength(ModelConstants.Journalist.MinNameLength)
                .MaximumLength(ModelConstants.Journalist.MaxNameLength)
                .NotEmpty();

            this.RuleFor(u => u.PhoneNumber)
                .MinimumLength(ModelConstants.Journalist.MinPhoneNumberLength)
                .MaximumLength(ModelConstants.Journalist.MaxPhoneNumberLength)
                .Matches(ModelConstants.PhoneNumber.PhoneNumberRegularExpression)
                .NotEmpty();
        }
    }
}
