namespace NewsSystem.Domain.Exceptions
{
    public class InvalidArticleException : BaseDomainException
    {
        public InvalidArticleException()
        {
        }

        public InvalidArticleException(string error) => this.Error = error;
    }
}
