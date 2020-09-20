﻿namespace NewsSystem.Web.Features
{
    using System.Collections.Generic;
    using System.Threading.Tasks; 

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using NewsSystem.Application.ArticleCreation.Articles.Commands.ChangeAvailability;
    using NewsSystem.Application.ArticleCreation.Articles.Commands.Create;
    using NewsSystem.Application.ArticleCreation.Articles.Commands.Delete;
    using NewsSystem.Application.ArticleCreation.Articles.Commands.Edit;
    using NewsSystem.Application.ArticleCreation.Articles.Queries.Categories;
    using NewsSystem.Application.ArticleCreation.Articles.Queries.Details;
    using NewsSystem.Application.ArticleCreation.Articles.Queries.Mine;
    using NewsSystem.Application.ArticleCreation.Articles.Queries.Search;
    using NewsSystem.Application.Common;

    public class ArticlesController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<SearchArticlesOutputModel>> Search(
            [FromQuery] SearchArticlesQuery query)
            => await this.Send(query);

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<ArticleDetailsOutputModel>> Details(
            [FromRoute] ArticleDetailsQuery query)
            => await this.Send(query);

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateArticleOutputModel>> Create(
            CreateArticleCommand command)
            => await this.Send(command);

        [HttpPut]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult> Edit(
            int id, EditArticleCommand command)
            => await this.Send(command.SetId(id));

        [HttpDelete]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult> Delete(
            [FromRoute] DeleteArticleCommand command)
            => await this.Send(command);

        [HttpGet]
        [Authorize]
        [Route(nameof(Mine))]
        public async Task<ActionResult<MineArticlesOutputModel>> Mine(
            [FromQuery] MineArticlesQuery query)
            => await this.Send(query);

        [HttpGet]
        [Route(nameof(Categories))]
        public async Task<ActionResult<IEnumerable<GetArticleCategoryOutputModel>>> Categories(
            [FromQuery] GetArticleCategoriesQuery query)
            => await this.Send(query);

        [HttpPut]
        [Authorize]
        [Route(Id + PathSeparator + nameof(ChangeAvailability))]
        public async Task<ActionResult> ChangeAvailability(
            [FromRoute] ChangeAvailabilityCommand query)
            => await this.Send(query);
    }
}