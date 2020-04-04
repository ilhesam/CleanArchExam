using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.ViewModels.DataTransferObjects.Common;
using Domain.Common;

namespace ApplicationCore.ViewModels.DataTransferObjects
{
    public class AuthorAddDto : EntityAddDto, IPassword
    {
        public string DisplayName { get; set; }

        public string RealName { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }
    }
}
