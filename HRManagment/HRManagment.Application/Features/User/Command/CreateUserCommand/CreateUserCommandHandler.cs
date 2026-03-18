using HRManagment.Application.Interfaces;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagment.Application.Features.User.Command.CreateUserCommand
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public CreateUserCommandHandler(IUserRepository userRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var emailExists = await _userRepository.IsEmailExistsAsync(request.Email);
            if (emailExists)
                throw new HRManagment.Application.Exceptions.ValidationException(
                    new List<FluentValidation.Results.ValidationFailure>
                    {
                    new("Email", "Bu email adresi zaten kullanımda.")
                    });

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var user = new HRManagment.Domain.Entities.User(request.Name, request.LastName, request.Email, hashedPassword);

            await _userRepository.AddAsync(user);

            await _emailService.SendEmailAsync(
                request.Email,
                "Hoş Geldiniz!",
                $"Merhaba {request.Name}, HR sistemine kaydınız başarıyla oluşturuldu."
            );

            return new CreateUserCommandResponse
            {
                IsSuccess = true,
                Message = "Kullanıcı başarıyla oluşturuldu."
            };
        }
    }
}
