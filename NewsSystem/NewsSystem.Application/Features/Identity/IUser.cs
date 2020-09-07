namespace NewsSystem.Application.Features.Identity
{
    using Domain.Models.Journalist;

    public interface IUser
    {
        void BecomeJournalist(Journalist journalist);
    }
}
