using HRManagment.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagment.Application.Features.User.Command.UpdateUserCommand
{
    public class UpdateUserCommandRequest : IRequest<UpdateUserCommandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public UserRole Role { get; set; }
    }
}
