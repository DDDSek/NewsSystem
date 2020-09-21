namespace NewsSystem.Application.ArticleCreation.Journalist.Queries.Details
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using Application.ArticleCreation.Journalists;

    public class JournalistDetailsQuery : IRequest<JournalistDetailsOutputModel>
    {
        public int Id { get; set; }

        public class JournalisDetailsQueryHandler : IRequestHandler<JournalistDetailsQuery, JournalistDetailsOutputModel>
        {
            private readonly IJournalistRepository journalistRepository;

            public JournalisDetailsQueryHandler(IJournalistRepository journalistRepository)
                => this.journalistRepository = journalistRepository;

            public async Task<JournalistDetailsOutputModel> Handle(
                JournalistDetailsQuery request,
                CancellationToken cancellationToken)
                => await this.journalistRepository.GetDetails(request.Id, cancellationToken);
        }
    }
}
