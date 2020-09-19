namespace NewsSystem.Domain.Exceptions
{
    public class InvalidCommentException : BaseDomainException
    {
        public InvalidCommentException()
        {
        }

        public InvalidCommentException(string error) => this.Error = error;
    }
}
