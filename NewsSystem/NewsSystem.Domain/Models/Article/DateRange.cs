namespace NewsSystem.Domain.Models.Article
{
    using System;
    using Domain.Common;

    public class DateRange : ValueObject
    {
        internal DateRange(DateTime createdOn)
        {
            this.CreatedOn = createdOn;
        }

        internal DateRange(DateTime lastModify, DateTime deletedOn)
        {
            this.LastModify = lastModify; 
            this.DeletedOn = deletedOn;
        }
 

        public DateTime CreatedOn { get; private set; } = DateTime.Now;

        public DateTime? LastModify { get; private set;}

        public DateTime? DeletedOn { get; private set;} 
 
    }
}
