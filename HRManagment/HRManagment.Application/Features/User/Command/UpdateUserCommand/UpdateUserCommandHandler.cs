using HRManagment.Application.Exceptions;
using HRManagment.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagment.Application.Features.User.Command.UpdateUserCommand
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
                throw new NotFoundException("Kullanıcı bulunamadı.");

            var emailExists = await _userRepository.IsEmailExistsAsync(request.Email);
            if (emailExists && user.Email != request.Email)
                throw new ConflictException("Bu email adresi zaten kullanımda.");

            user.Name = request.Name;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Role = request.Role;

            await _userRepository.UpdateAsync(user);

            return new UpdateUserCommandResponse
            {
                IsSuccess = true,
                Message = "Kullanıcı başarıyla güncellendi."
            };
        }
    }
}
