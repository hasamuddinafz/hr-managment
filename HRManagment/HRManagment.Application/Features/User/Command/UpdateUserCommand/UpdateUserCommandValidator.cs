using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagment.Application.Features.User.Command.UpdateUserCommand
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommandRequest>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id boş olamaz.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("İsim boş olamaz.")
                .MaximumLength(100).WithMessage("İsim 100 karakterden uzun olamaz.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyisim boş olamaz.")
                .MaximumLength(100).WithMessage("Soyisim 100 karakterden uzun olamaz.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir email giriniz.")
                .MaximumLength(100).WithMessage("Email 100 karakterden uzun olamaz.");
        }
    }
}
