using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagment.Application.Features.User.Command.UpdateUserCommand
{
    public class UpdateUserCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = null!;
    }
}
