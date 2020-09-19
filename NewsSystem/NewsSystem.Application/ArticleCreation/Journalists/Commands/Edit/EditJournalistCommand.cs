﻿namespace NewsSystem.Application.ArticleCreation.Journalist.Commands.Edit
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Common;
    using Common.Contracts;

    using Application.ArticleCreation.Journalists;

    public class EditJournalistCommand : EntityCommand<int>, IRequest<Result>
    {
        public string Name { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public class EditJournalistCommandHandler : IRequestHandler<EditJournalistCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly IJournalistRepository journalistRepository;

            public EditJournalistCommandHandler(
                ICurrentUser currentUser,
                IJournalistRepository journalistRepository)
            {
                this.currentUser = currentUser;
                this.journalistRepository = journalistRepository;
            }

            public async Task<Result> Handle(
                EditJournalistCommand request,
                CancellationToken cancellationToken)
            {
                var journalist = await this.journalistRepository.FindByUser(
                    this.currentUser.UserId,
                    cancellationToken);

                if (request.Id != journalist.Id)
                {
                    return "You cannot edit this journalist.";
                }

                journalist
                    .UpdateName(request.Name)
                    .UpdatePhoneNumber(request.PhoneNumber);

                await this.journalistRepository.Save(journalist, cancellationToken);

                return Result.Success;
            }
        }
    }
}
