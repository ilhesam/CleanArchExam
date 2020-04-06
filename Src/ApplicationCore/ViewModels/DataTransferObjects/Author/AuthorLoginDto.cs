using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.ViewModels.DataTransferObjects
{
    public class AuthorLoginDto
    {
        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public bool IsPersistent { get; set; } = false;
    }
}
