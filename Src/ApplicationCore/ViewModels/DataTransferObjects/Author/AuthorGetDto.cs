using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.ViewModels.DataTransferObjects.Common;

namespace ApplicationCore.ViewModels.DataTransferObjects
{
    public class AuthorGetDto : EntityGetDto
    {
        public string DisplayName { get; set; }

        public string RealName { get; set; }

        public string EmailAddress { get; set; }
    }
}
