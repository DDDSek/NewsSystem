namespace NewsSystem.Application.Identity.Commands.CreateJournalist
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Application.Common;
    using Application.Common.Contracts;
    using Application.ArticleCreation.Journalists;
    using Domain.ArticleCreation.Factories.Journalists;


    public class RegisterJournalistCommand : IRequest<Result>
    {
        public RegisterJournalistCommand(string address, string phoneNumber)
        {
            this.UserId = default!;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
        }

        public string UserId { get; set; }

        public string Address { get; }

        public string PhoneNumber { get; }

        public class RegisterJournalistCommandHandler : IRequestHandler<RegisterJournalistCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly IIdentity identity;
            private readonly IJournalistFactory journalistFactory;
            private readonly IJournalistRepository journalistRepository;

            public RegisterJournalistCommandHandler(
                ICurrentUser currentUser,
                IIdentity identity,
                IJournalistFactory journalistFactory,
                IJournalistRepository journalistRepository)
            {
                this.currentUser = currentUser;
                this.identity = identity;
                this.journalistFactory = journalistFactory;
                this.journalistRepository = journalistRepository;
            }

            public async Task<Result> Handle(RegisterJournalistCommand request, CancellationToken cancellationToken)
            {
                var exist = await this.journalistRepository.Existed(this.currentUser.UserId, cancellationToken);

                if (exist)
                {
                    return "The journalist already existing with this account!";
                }

                var journalist = this.journalistFactory
                    .WithUserId(this.currentUser.UserId)
                    .WithAddress(request.Address)
                    .WithPhoneNumber(request.PhoneNumber)
                    .Build();

                await this.journalistRepository.Save(journalist, cancellationToken: cancellationToken);
                await this.identity.AddToRoleJournalist(this.currentUser.UserId);

                return Result.Success;
            }
        }

    }
}
