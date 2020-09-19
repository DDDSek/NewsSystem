namespace NewsSystem.Domain.ArticleCreation.Models.Articles
{
    using NewsSystem.Domain.Common;
    using NewsSystem.Domain.Common.Models;

    public class Status : Enumeration
    {
        public static readonly Status Waiting = new Status(1, nameof(Waiting));  
        public static readonly Status Available = new Status(2, nameof(Available));  
        public static readonly Status UnAvailable = new Status(3, nameof(UnAvailable));
        public static readonly Status Deleted = new Status(4, nameof(Deleted));

        private Status(int value)
            : this(value, FromValue<Status>(value).Name)
        {
        }

        private Status(int value, string name)
            : base(value, name)
        {
        }
    }
}
