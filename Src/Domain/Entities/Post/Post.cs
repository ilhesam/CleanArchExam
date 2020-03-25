using System;
using System.Collections.Generic;
using System.Text;
using Domain.Common;

namespace Domain.Entities
{
    public class Post : Entity
    {
        public string Subject { get; set; }

        public string Description { get; set; }

        public string ImageAddress { get; set; }
    }
}
