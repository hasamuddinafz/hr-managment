using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagment.Application.Features.User.Command.ChangePasswordCommand
{
    public class ChangePasswordCommandRequest : IRequest<ChangePasswordCommandResponse>
    {
        public Guid Id { get; set; }
        public string CurrentPassword { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
    }
}
