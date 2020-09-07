namespace NewsSystem.Domain.Models.Article
{
    using System;
    using Common;
    using Exceptions;
    using global::Domain.Exceptions;

    public class Comment : Entity<int>
    {
        private string content;
        private string createdBy;
        private string modifiedBy;

        public Comment(string content, string createdBy)
        {
            this.Content = content;
            this.CreatedBy = createdBy;
        }

        public string Content
        {
            get => this.content;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidArticleException("Comment content cannot be null.");
                }

                this.content = value;
            }
        }

        public bool IsPublic { get; set; }

        public DateTime? PublishedOn { get; set; }

        public string CreatedBy
        {
            get => this.createdBy;
            set => this.createdBy = value ?? throw new InvalidEntityException("User ID cannot be null.");
        }

        public DateTime CreatedOn { get; set; }

        public string ModifiedBy
        {
            get => this.modifiedBy;
            set => this.modifiedBy = value ?? throw new InvalidEntityException("User ID cannot be null.");
        }

        public DateTime? ModifiedOn { get; set; }
    }
}
