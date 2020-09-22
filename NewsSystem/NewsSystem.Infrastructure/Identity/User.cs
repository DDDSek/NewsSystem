namespace NewsSystem.Infrastructure.Identity
{
    using Microsoft.AspNetCore.Identity;

    using Application.Identity;

    using Domain.Exceptions;
    using Domain.ArticleCreation.Models.Journalists;
    using NewsSystem.Domain.ArticleCreation.Models.Articles;
    using System.Collections.Generic;

    public class User : IdentityUser, IUser
    {
        internal User(string email)
            : base(email)
            => this.Email = email;

        public ICollection<Comment> Comments { get; } = new List<Comment>();

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
