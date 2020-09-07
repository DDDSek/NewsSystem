namespace NewsSystem.Domain.Exceptions
{
    public class InvalidJournalistException : BaseDomainException
    {
        public InvalidJournalistException()
        {
        }

        public InvalidJournalistException(string error) => this.Error = error;
    }
}
