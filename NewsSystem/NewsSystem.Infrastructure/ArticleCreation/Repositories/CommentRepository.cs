namespace NewsSystem.Infrastructure.ArticleCreation.Repositories
{
    using System.Threading.Tasks;

    using AutoMapper;

    using Application.ArticleCreation.Articles;

    using Domain.ArticleCreation.Models.Articles;

    using Infrastructure.Common.Persistence;

    public class CommentRepository : DataRepository<IArticleCreationDbContext, Comment>, ICommentRepository
    {
        private readonly IMapper mapper;

        public CommentRepository(IArticleCreationDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        Task<CommentDetailsOutputModel> GetDetails(int id, CancellationToken cancellationToken = default);

        //Task<int> Total(
        //    Specification<Comment> commentSpecification,
        //    CancellationToken cancellationToken = default);

        //Task<bool> Delete(int id, CancellationToken cancellationToken = default);
    }
}
