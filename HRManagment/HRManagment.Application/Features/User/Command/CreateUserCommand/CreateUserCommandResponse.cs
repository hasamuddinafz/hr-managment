using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagment.Application.Features.User.Command.CreateUserCommand
{
    public class CreateUserCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = null!;
    }
}
