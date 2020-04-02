using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Validators.Common;
using ApplicationCore.ViewModels.DataTransferObjects;
using FluentValidation;

namespace ApplicationCore.Validators
{
    public class PostEditDtoValidator : EntityEditDtoValidator<PostEditDto>
    {
        public PostEditDtoValidator()
        {
            RuleFor(p => p.Subject)
                .NotNull().WithMessage("Subject cannot be null")
                .NotEmpty().WithMessage("Subject cannot be empty")
                .MaximumLength(250).WithMessage("Subject cannot be more than 250 characters")
                .MinimumLength(5).WithMessage("Subject cannot be less than 5 characters");

            RuleFor(p => p.Description)
                .NotNull().WithMessage("Description cannot be null")
                .NotEmpty().WithMessage("Description cannot be empty")
                .MaximumLength(1500).WithMessage("Description cannot be more than 1500 characters")
                .MinimumLength(30).WithMessage("Description cannot be less than 30 characters");

            RuleFor(p => p.ImageAddress)
                .NotNull().WithMessage("Image Address cannot be null")
                .NotEmpty().WithMessage("Image Address cannot be empty")
                .MaximumLength(1500).WithMessage("Image Address cannot be more than 1500 characters");
        }
    }
}
