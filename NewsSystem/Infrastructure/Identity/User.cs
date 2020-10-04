namespace NewsSystem.Infrastructure.Identity
{
    using System.Collections.Generic;  

    using Microsoft.AspNetCore.Identity;
    using System.Linq;

    using Domain.ArticleCreation.Models.Articles;
    using Application.Identity;

    public class User : IdentityUser, IUser
    { 
        private readonly HashSet<Comment> comments;
        internal User(string email, string userName, string phoneNumber)
            : base(email)
        {
            base.Email = email;
            base.UserName = userName;
            base.PhoneNumber = phoneNumber;

            this.comments = new HashSet<Comment>();
        }
  
        public int CommentId { get; private set; } 

        public IReadOnlyCollection<Comment> Comments => this.comments.ToList().AsReadOnly(); 
    }
}
