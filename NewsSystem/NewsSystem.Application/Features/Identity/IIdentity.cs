namespace NewsSystem.Application.Features.Identity
{
    using System.Threading.Tasks;

    using Application.Common;

    using Commands;
    using Commands.LoginUser;
    using Commands.ChangePassword;

    public interface IIdentity
    {
        Task<Result<IUser>> Register(UserInputModel userInput);

        Task<Result<LoginSuccessModel>> Login(UserInputModel userInput);

        Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput);
    }
}
