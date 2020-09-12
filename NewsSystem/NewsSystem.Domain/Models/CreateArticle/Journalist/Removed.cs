namespace NewsSystem.Domain.Models.CreateArticle.Journalist
{
    using NewsSystem.Domain.Common;


    public class Removed : Enumeration
    {
        public static readonly Removed WeeklyRemoved = new Removed(1, nameof(WeeklyRemoved));
        public static readonly Removed MonthlyRemoved = new Removed(2, nameof(MonthlyRemoved));
        public static readonly Removed SixMontsRemoved = new Removed(2, nameof(SixMontsRemoved));
        public static readonly Removed Fired = new Removed(2, nameof(Fired));

        private Removed(int value)
            : this(value, FromValue<Removed>(value).Name)
        {
        }

        private Removed(int value, string name)
            : base(value, name)
        {
        }
    }
}
