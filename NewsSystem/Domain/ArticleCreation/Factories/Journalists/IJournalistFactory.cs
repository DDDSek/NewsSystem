﻿namespace NewsSystem.Domain.ArticleCreation.Factories.Journalists
{
    using Common;
    using Models.Journalists; 

    public interface IJournalistFactory : IFactory<Journalist>
    {
        IJournalistFactory WithUserId(string userId);

        IJournalistFactory WithName(string name);

        IJournalistFactory WithAddress(Address address);

        IJournalistFactory WithAddress(string address);

        IJournalistFactory WithPhoneNumber(PhoneNumber phoneNumber);

        IJournalistFactory WithPhoneNumber(string phoneNumber);
    }
}