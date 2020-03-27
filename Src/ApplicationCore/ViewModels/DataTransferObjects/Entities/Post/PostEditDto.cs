using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.ViewModels.DataTransferObjects.Common;

namespace ApplicationCore.ViewModels.DataTransferObjects.Entities
{
    public class PostEditDto : EntityEditDto
    {
        public string Subject { get; set; }

        public string Description { get; set; }

        public string ImageAddress { get; set; }
    }
}
