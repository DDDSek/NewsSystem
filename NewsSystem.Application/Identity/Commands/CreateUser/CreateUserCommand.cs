namespace NewsSystem.Application.Identity.Commands.CreateUser
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Common; 
    using Application.ArticleCreation.Journalists;
    using Domain.ArticleCreation.Factories.Journalists;

    public class CreateUserCommand : UserInputModel, IRequest<Result>
    {
        public string Name { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
        {
            private readonly IIdentity identity;
            private readonly IJournalistFactory journalistFactory;
            private readonly IJournalistRepository journalistRepository;

            public CreateUserCommandHandler(
                IIdentity identity,
                IJournalistFactory journalistFactory,
                IJournalistRepository journalistRepository)
            {
                this.identity = identity;
                this.journalistFactory = journalistFactory;
                this.journalistRepository = journalistRepository;
            }

            public async Task<Result> Handle(
                CreateUserCommand request,
                CancellationToken cancellationToken)
            {
                var result = await this.identity.Register(request);

                if (!result.Succeeded)
                {
                    return result;
                }

                var user = result.Data;

                var journalist = this.journalistFactory
                    .WithName(request.Name)
                    .WithPhoneNumber(request.PhoneNumber)
                    .Build();

                user.BecomeJournalist(journalist);

                await this.journalistRepository.Save(journalist, cancellationToken);

                return result;
            }
        }
    }
}
