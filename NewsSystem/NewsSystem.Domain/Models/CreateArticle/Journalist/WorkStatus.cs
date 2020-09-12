namespace NewsSystem.Domain.Models.CreateArticle.Journalist
{
    using NewsSystem.Domain.Common;

    public class WorkStatus : ValueObject
    {
        //OnDuty, Waiting, Removed - enum, Delete


        internal WorkStatus(bool onDuty, bool waiting, int yearsBeforeRetirement, Removed removed)
        {
            this.OnDuty = onDuty;
            this.Waiting = waiting;
            this.YearsBeforeRetirement = yearsBeforeRetirement;
            this.Removed = removed;
        }
        private WorkStatus(bool onDuty, bool waiting, int yearsBeforeRetirement)
        {
            this.OnDuty = onDuty;
            this.Waiting = waiting;
            this.YearsBeforeRetirement = yearsBeforeRetirement;

            this.Removed = default!;
        }

        public bool OnDuty { get; }

        public bool Waiting { get; }

        public int YearsBeforeRetirement { get; }

        public Removed Removed { get; }
    }
}
