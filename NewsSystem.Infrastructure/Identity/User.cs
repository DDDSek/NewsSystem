namespace NewsSystem.Infrastructure.Identity
{
    using Domain.Exceptions;
    using Microsoft.AspNetCore.Identity;
    using NewsSystem.Domain.ArticleCreation.Models.Journalists;
    using NewsSystem.Application.Identity;

    public class User : IdentityUser, IUser
    {
        internal User(string email)
            : base(email)
            => this.Email = email;

        public Journalist? Journalist { get; private set; }

        public void BecomeJournalist(Journalist journalist)
        {
            if (this.Journalist != null)
            {
                throw new InvalidJournalistException($"User '{this.UserName}' is already a Journalist.");
            }

            this.Journalist = journalist;
        }
    }
}
