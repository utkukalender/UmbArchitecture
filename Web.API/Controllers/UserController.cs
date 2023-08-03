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
        private readonly IHttpContextAccessor _httpContext;
        private readonly ILogger<UserController> _logger;

        public UserController(IMediator mediator, IHttpContextAccessor httpContext, ILogger<UserController> logger)
        {
            _httpContext = httpContext;
            _mediator = mediator;
            _logger = logger;   
        }

        [HttpGet]
        public async Task<ActionResult<List<GetUserDto>>> GetAll()
        {
            //throw new Exception("bora Deneme");
            //_logger.LogInformation("BEN CALISTIM");
            _httpContext.HttpContext.Session.SetString("_Name", "bora");
            var name = HttpContext.Session.GetString("_Name");

            var query = new GetAllUserQuery()
            {

            };

            return Ok(await _mediator.Send(query));
        }
    }
}
