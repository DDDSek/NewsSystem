namespace NewsSystem.Domain.Exceptions
{
    public class InvalidAdminException : BaseDomainException
    {
        public InvalidAdminException()
        {
        }

        public InvalidAdminException(string error) => this.Error = error;
    }
}