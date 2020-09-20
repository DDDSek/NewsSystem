namespace NewsSystem.Application.ArticleCreation.Articles
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using Common.Contracts;

    using Domain.Common;
    using Domain.ArticleCreation.Models.Articles; 

    public class ICommentRepository : IRepository<Comment>
    {
        Task<Category> GetAllByUserId(
            int userId,
            CancellationToken cancellationToken = default);


        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
    }
}
