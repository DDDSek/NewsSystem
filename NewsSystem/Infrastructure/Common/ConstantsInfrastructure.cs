namespace NewsSystem.Infrastructure.Common
{
    public static class ConstantsInfrastructure
    {
        public static class IdentityErrors
        {
            public const string LoginInvalid = "Invalid credentials";
            public const string UserInvalid = "Invalid user"; 
            public const string EmailInvalid = "The Email is already taken";

            public const string AlreadyJournalist = "The user is already a journalist.";
        }

        public static class Roles
        {
            public const string Journalist = "Journalist";
        }
    }
}
