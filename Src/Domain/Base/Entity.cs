using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Entity
    {
        public int Id { get; set; }

        public DateTime CreateDateTime { get; set; } = DateTime.Now;
    }
}
