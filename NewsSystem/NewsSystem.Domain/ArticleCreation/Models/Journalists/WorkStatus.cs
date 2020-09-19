namespace NewsSystem.Domain.ArticleCreation.Models.Journalists
{
    using Domain.Common.Models;

    public class WorkStatus : ValueObject
    {  
        internal WorkStatus(bool onDuty, int yearsBeforeRetirement, Removed removed)
        {
            this.OnDuty = onDuty;
            this.YearsBeforeRetirement = yearsBeforeRetirement;
            this.Removed = removed;
        }
  
        private WorkStatus(bool onDuty, int yearsBeforeRetirement)
        {
            this.OnDuty = onDuty;
            this.YearsBeforeRetirement = yearsBeforeRetirement;

            this.Removed = default!;
        }

        public bool OnDuty { get; }

        public int YearsBeforeRetirement { get; }

        public Removed Removed { get; }
    }
}
