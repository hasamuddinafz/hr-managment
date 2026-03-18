using HRManagment.Application.Features.User.Command.ChangePasswordCommand;
using HRManagment.Application.Features.User.Command.CreateUserCommand;
using HRManagment.Application.Features.User.Command.DeleteUserCommand;
using HRManagment.Application.Features.User.Command.UpdateUserCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRManagment.WebAPI.Controllers
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
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommandRequest request)
        {
            var response = await _mediator.Send(request);

            if (!response.IsSuccess)
                return BadRequest(response.Message);

            return Ok(response.Message);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommandRequest request)
        {
            var response = await _mediator.Send(request);

            if (!response.IsSuccess)
                return BadRequest(response.Message);

            return Ok(response.Message);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _mediator.Send(new DeleteUserCommandRequest { Id = id });

            if (!response.IsSuccess)
                return BadRequest(response.Message);

            return Ok(response.Message);
        }
        [HttpPatch("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommandRequest request)
        {
            var response = await _mediator.Send(request);

            if (!response.IsSuccess)
                return BadRequest(response.Message);

            return Ok(response.Message);
        }
    }

}
