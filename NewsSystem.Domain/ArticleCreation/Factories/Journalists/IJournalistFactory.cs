namespace NewsSystem.Domain.ArticleCreation.Factories.Journalists
{
    using Common;
    using Models.Journalists;

    public interface IJournalistFactory : IFactory<Journalist>
    {
        IJournalistFactory WithName(string name);

        IJournalistFactory WithPhoneNumber(string phoneNumber);
    }
}
