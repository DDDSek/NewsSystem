namespace NewsSystem.Domain.Models.CreateArticle.Journalist
{
    using System.Text.RegularExpressions;
    using Domain.Common;
    using Domain.Exceptions;

    public class PhoneNumber : ValueObject
    {
        internal PhoneNumber(string number)
        {
            this.Validate(number);

            if (!Regex.IsMatch(number, Domain.Models.ModelConstants.PhoneNumber.PhoneNumberRegularExpression))
            {
                throw new InvalidPhoneNumberException("Phone number must start with a '+' and contain only digits afterwards.");
            }

            this.Number = number;
        }

        public string Number { get; }

        public static implicit operator string(PhoneNumber number) => number.Number;

        public static implicit operator PhoneNumber(string number) => new PhoneNumber(number);

        private void Validate(string phoneNumber)
            => Guard.ForStringLength<InvalidPhoneNumberException>(
                phoneNumber,
                Domain.Models.ModelConstants.PhoneNumber.MinPhoneNumberLength,
                Domain.Models.ModelConstants.PhoneNumber.MaxPhoneNumberLength,
                nameof(PhoneNumber));
    }
}
