﻿namespace NewsSystem.Domain.ArticleCreation.Models.Journalists
{ 
    using Domain.Common.Models;

    public class Removed : Enumeration
    {
        public static readonly Removed Waiting = new Removed(1, nameof(Waiting));
        public static readonly Removed WeeklyRemoved = new Removed(2, nameof(WeeklyRemoved));
        public static readonly Removed MonthlyRemoved = new Removed(3, nameof(MonthlyRemoved));
        public static readonly Removed SixMontsRemoved = new Removed(4, nameof(SixMontsRemoved));
        public static readonly Removed Fired = new Removed(5, nameof(Fired));

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