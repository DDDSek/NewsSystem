namespace NewsSystem.Application.ArticleCreation.Journalist.Commands.Edit
{
    using FluentValidation; 

    public class EditJournalistCommandValidator : AbstractValidator<EditJournalistCommand>
    {
        public EditJournalistCommandValidator()
        {
            this.RuleFor(u => u.Name)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            this.RuleFor(u => u.PhoneNumber)
                .MinimumLength(MinPhoneNumberLength)
                .MaximumLength(MaxPhoneNumberLength)
                .Matches(PhoneNumberRegularExpression)
                .NotEmpty();
        }
    }
}
