namespace NewsSystem.Domain.Models.CreateArticle.Article
{
    using System;
    using Domain.Common;
    using Domain.Models;
    using Domain.Exceptions;

    public class DateRange : ValueObject
    {
        internal DateRange(DateTime createdOn, DateTime? lastModify, DateTime? deletedOn)
        {
            this.CreatedOn = createdOn;
            this.LastModify = lastModify;
            this.DeletedOn = deletedOn;
        }

        private DateRange(DateTime createdOn, DateTime lastModify, DateTime? deletedOn)
        {
            this.CreatedOn = createdOn;
            this.LastModify = lastModify;
            this.DeletedOn = deletedOn;
        }
 

        public DateTime CreatedOn { get; private set; } = DateTime.Now;

        public DateTime? LastModify { get; private set;}

        public DateTime? DeletedOn { get; private set;}

 

    }
}
