using HRManagment.Application.Exceptions;
using HRManagment.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagment.Application.Features.User.Command.ChangePasswordCommand
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommandRequest, ChangePasswordCommandResponse>
    {
        private readonly IUserRepository _userRepository;

        public ChangePasswordCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ChangePasswordCommandResponse> Handle(ChangePasswordCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
                throw new NotFoundException("Kullanıcı bulunamadı.");

            var isPasswordValid = BCrypt.Net.BCrypt.Verify(request.CurrentPassword, user.PasswordHash);
            if (!isPasswordValid)
                throw new ValidationException(
                    new List<FluentValidation.Results.ValidationFailure>
                    {
                        new("CurrentPassword", "Mevcut şifre yanlış.")
                    });

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);

            await _userRepository.UpdateAsync(user);

            return new ChangePasswordCommandResponse
            {
                IsSuccess = true,
                Message = "Şifre başarıyla güncellendi."
            };
        }
    }
}
