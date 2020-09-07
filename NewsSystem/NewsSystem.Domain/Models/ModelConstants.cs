namespace NewsSystem.Domain.Models
{
    public class ModelConstants
    {
        public class Common
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 20;
            public const int MinEmailLength = 3;
            public const int MaxEmailLength = 50;
            public const int MaxUrlLength = 2048;
            public const int Zero = 0;
        }

        public class Category
        {
            public const int MinDescriptionLength = 20;
            public const int MaxDescriptionLength = 1000;
        }
 
        public class Article
        {
            public const int MinTitleLength = 5;
            public const int MaxTitleLength = 60;

            public const int MinContentLength = 100;
            public const int MaxContentLength = 1000;
        }

        public class Journalist
        {
            public const int MinNameLength = 3;
            public const int MaxNameLength = 12;
        }
    }
}
