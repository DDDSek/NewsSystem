namespace NewsSystem.Startup.Specs
{ 
    using MyTested.AspNetCore.Mvc;

    using Xunit;
    using Application.ArticleCreation.Journalist.Queries.Details;

    using Web;
    using Web.Features;

    public class JournalistsControllerSpecs
    {
        [Fact]
        public void DetailsShouldHaveCorrectAttributes()
            => MyController<JournalistsController>
                .Calling(c => c.Details(With.Default<JournalistDetailsQuery>()))

                .ShouldHave()
                .ActionAttributes(attr => attr
                    .RestrictingForHttpMethod(HttpMethod.Get)
                    .SpecifyingRoute(ApiController.Id));
    }
}
