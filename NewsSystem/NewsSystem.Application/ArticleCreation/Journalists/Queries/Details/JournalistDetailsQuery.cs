namespace NewsSystem.Application.ArticleCreation.Journalist.Queries.Details
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class JournalistDetailsQuery : IRequest<JournalistDetailsOutputModel>
    {
        public int Id { get; set; }

        public class DealerDetailsQueryHandler : IRequestHandler<JournalistDetailsQuery, JournalistDetailsOutputModel>
        {
            private readonly IJournalistRepository journalistRepository;

            public DealerDetailsQueryHandler(IJournalistRepository journalistRepository)
                => this.journalistRepository = journalistRepository;

            public async Task<JournalistDetailsOutputModel> Handle(
                JournalistDetailsQuery request,
                CancellationToken cancellationToken)
                => await this.journalistRepository.GetDetails(request.Id, cancellationToken);
        }
    }
}
