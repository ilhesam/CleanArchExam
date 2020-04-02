using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.ViewModels.DataTransferObjects.Common;
using FluentValidation;

namespace ApplicationCore.Validators.Common
{
    public class EntityAddDtoValidator<TEntityAddDto> : AbstractValidator<TEntityAddDto> where TEntityAddDto : EntityAddDto
    {
        public EntityAddDtoValidator()
        {
        }
    }
}
