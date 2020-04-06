using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.ViewModels.DataTransferObjects;
using FluentValidation;

namespace ApplicationCore.Validators
{
    public class AuthorLoginDtoValidator : AbstractValidator<AuthorLoginDto>
    {
        public AuthorLoginDtoValidator()
        {
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

            RuleFor(a => a.IsPersistent)
                .NotNull().WithMessage("Is Persistent cannot be null");
        }
    }
}
