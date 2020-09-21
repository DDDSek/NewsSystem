namespace NewsSystem.Web.Features
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Application.ArticleCreation.Journalist.Commands.Edit;
    using Application.ArticleCreation.Journalist.Queries.Details;
    using Application.Common;

    public class JournalistsController : ApiController
    {
        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<JournalistDetailsOutputModel>> Details(
            [FromRoute] JournalistDetailsQuery query)
            => await this.Send(query);

        [HttpPut]
        [Route(Id)]
        public async Task<ActionResult> Edit(
            int id, EditJournalistCommand command)
            => await this.Send(command.SetId(id));
    }
}
