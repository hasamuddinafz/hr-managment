using HRManagment.Application.Exceptions;
using HRManagment.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagment.Application.Features.User.Command.DeleteUserCommand
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, DeleteUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
                throw new NotFoundException("Kullanıcı bulunamadı.");

            await _userRepository.DeleteAsync(request.Id);

            return new DeleteUserCommandResponse
            {
                IsSuccess = true,
                Message = "Kullanıcı başarıyla silindi."
            };
        }
    }
}
