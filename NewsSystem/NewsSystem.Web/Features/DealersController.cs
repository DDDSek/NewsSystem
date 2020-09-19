namespace NewsSystem.Web.Features
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    public class DealersController : ApiController
    {
        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<DealerDetailsOutputModel>> Details(
            [FromRoute] DealerDetailsQuery query)
            => await this.Send(query);

        [HttpPut]
        [Route(Id)]
        public async Task<ActionResult> Edit(
            int id, EditDealerCommand command)
            => await this.Send(command.SetId(id));
    }
}
