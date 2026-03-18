using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagment.Application.Features.User.Command.DeleteUserCommand
{
    public class DeleteUserCommandRequest : IRequest<DeleteUserCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
