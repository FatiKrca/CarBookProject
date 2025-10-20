using CarBookProject.Application.TagClouds.Mediator.Commands.TagCloudCommands;
using CarBookProject.Application.TagClouds.Mediator.Queries.TagCloudQueries;

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagCloudsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagCloudsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> TagCloudList()
        {
            var values = await _mediator.Send(new GetTagCloudQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByTagCloud(int id)
        {
            var value = await _mediator.Send(new GetTagCloudByIdQuery(id));
            return Ok(value);
        }
        [HttpGet("GetTagCloudByBlogId/{id}")]
        public async Task<IActionResult> GetTagCloudByBlogId(int id)
        {
            var value = await _mediator.Send(new GetTagCloudByBlogIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTagCloud(CreateTagCloudCommand createTagCloudCommand)
        {
            await _mediator.Send(createTagCloudCommand);
            return Ok("Eklend,");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveTagCloud(int id)
        {
            await _mediator.Send(new RemoveTagCloudCommand(id));
            return Ok("Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTagCloud(UpdateTagCloudCommand updateTagCloudCommand)
        {
            await _mediator.Send(updateTagCloudCommand);
            return Ok("Güncellendi");
        }
    }
}
