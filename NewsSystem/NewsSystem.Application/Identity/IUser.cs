namespace NewsSystem.Application.Identity
{
    using NewsSystem.Domain.ArticleCreation.Models.Journalists;

    public interface IUser
    {
        void BecomeJournalist(Journalist journalist);
    }
}
