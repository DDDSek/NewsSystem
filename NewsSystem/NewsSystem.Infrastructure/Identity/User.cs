namespace NewsSystem.Infrastructure.Identity
{
    using Microsoft.AspNetCore.Identity;

    using Application.Identity;

    using Domain.Exceptions;
    using Domain.ArticleCreation.Models.Journalists;

    public class User : IdentityUser, IUser
    {
        internal User(string email)
            : base(email)
            => this.Email = email;

        public IReadOnlyCollection<Comment> Comments => this.comments.ToList().AsReadOnly();

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
