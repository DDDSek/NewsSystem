namespace NewsSystem.Infrastructure.Identity
{
    using Application.Features.Identity;
    using Domain.Exceptions;
    using Domain.Models;
    using Microsoft.AspNetCore.Identity;
    using Domain.Models.Journalist;

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
                throw new InvalidJournalistException($"User '{this.UserName}' is already a dealer.");
            }

            this.Journalist = journalist;
        }
    }
}
