using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagment.Application.Features.User.Command.ChangePasswordCommand
{
    public class ChangePasswordCommandResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = null!;
    }
}
