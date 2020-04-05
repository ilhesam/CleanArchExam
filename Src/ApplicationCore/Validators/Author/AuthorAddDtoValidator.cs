using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Validators.Common;
using ApplicationCore.ViewModels.DataTransferObjects;
using FluentValidation;

namespace ApplicationCore.Validators
{
    public class AuthorAddDtoValidator : EntityAddDtoValidator<AuthorAddDto>
    {
        public AuthorAddDtoValidator()
        {
            RuleFor(a => a.DisplayName)
                .NotNull().WithMessage("Display Name cannot be null")
                .NotEmpty().WithMessage("Display Name cannot be empty")
                .MaximumLength(250).WithMessage("Display Name cannot be more than 250 characters")
                .MinimumLength(5).WithMessage("Display Name cannot be less than 5 characters");

            RuleFor(a => a.RealName)
                .NotNull().WithMessage("Real Name cannot be null")
                .NotEmpty().WithMessage("Real Name cannot be empty")
                .MaximumLength(250).WithMessage("Real Name cannot be more than 250 characters")
                .MinimumLength(5).WithMessage("Real Name cannot be less than 5 characters");

            RuleFor(a => a.EmailAddress)
                .NotNull().WithMessage("Email Address cannot be null")
                .NotEmpty().WithMessage("Email Address cannot be empty")
                .MaximumLength(250).WithMessage("Email Address cannot be more than 250 characters")
                .MinimumLength(5).WithMessage("Email Address cannot be less than 5 characters")
                .EmailAddress().WithMessage("Email Address is not valid");

            RuleFor(a => a.Password)
                .NotNull().WithMessage("Password cannot be null")
                .NotEmpty().WithMessage("Password cannot be empty")
                .MaximumLength(250).WithMessage("Password cannot be more than 250 characters")
                .MinimumLength(7).WithMessage("Password cannot be less than 7 characters");
        }
    }
}
