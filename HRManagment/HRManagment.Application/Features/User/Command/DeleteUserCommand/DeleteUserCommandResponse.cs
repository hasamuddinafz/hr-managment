using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagment.Application.Features.User.Command.DeleteUserCommand
{
    public class DeleteUserCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = null!;
    }
}
