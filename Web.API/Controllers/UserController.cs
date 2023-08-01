using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umb.Application.Features.User.Dtos;
using Umb.Application.Features.User.Queries;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpGet]
        public async Task<ActionResult<List<GetUserDto>>> GetAll()
        {
            var query = new GetAllUserQuery()
            {

            };

            return Ok(await _mediator.Send(query));
        }
    }
}
