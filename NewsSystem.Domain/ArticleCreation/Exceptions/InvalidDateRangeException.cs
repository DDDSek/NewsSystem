namespace NewsSystem.Domain.Exceptions
{
    public class InvalidDateRangeException : BaseDomainException
    {
        public InvalidDateRangeException()
        {
        }

        public InvalidDateRangeException(string error) => this.Error = error;
    }
}
