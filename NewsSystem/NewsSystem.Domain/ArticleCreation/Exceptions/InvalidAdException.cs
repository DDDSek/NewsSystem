namespace NewsSystem.Domain.Exceptions
{
    public class InvalidAdException : BaseDomainException
    {
        public InvalidAdException()
        {
        }

        public InvalidAdException(string error) => this.Error = error;
    }
    
}
