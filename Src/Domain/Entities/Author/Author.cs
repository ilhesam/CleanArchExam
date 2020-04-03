using System;
using System.Collections.Generic;
using System.Text;
using Domain.Common;

namespace Domain.Entities
{
    public class Author : Entity
    {
        public string DisplayName { get; set; }

        public string RealName { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }
    }
}
