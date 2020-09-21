namespace NewsSystem.Application.Identity.Commands.LoginUser
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Common;
    using ArticleCreation.Journalists;

    public class LoginUserCommand : UserInputModel, IRequest<Result<LoginOutputModel>>
    {
        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<LoginOutputModel>>
        {
            private readonly IIdentity identity;
            private readonly IJournalistRepository journalistRepository;

            public LoginUserCommandHandler(
                IIdentity identity,
                IJournalistRepository journalistRepository)
            {
                this.identity = identity;
                this.journalistRepository = journalistRepository;
            }

            public async Task<Result<LoginOutputModel>> Handle(
                LoginUserCommand request,
                CancellationToken cancellationToken)
            {
                var result = await this.identity.Login(request);

                if (!result.Succeeded)
                {
                    return result.Errors;
                }

                var user = result.Data;

                var journalistId = await this.journalistRepository.GetJournalistId(user.UserId, cancellationToken);

                return new LoginOutputModel(user.Token, journalistId);
            }
        }
    }
}
