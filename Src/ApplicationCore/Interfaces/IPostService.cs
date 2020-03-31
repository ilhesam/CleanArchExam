using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.ViewModels.DataTransferObjects;

namespace ApplicationCore.Interfaces
{
    public interface IPostService<in TPostAddDto, in TPostEditDto, TPostGetDto> : IAsyncService<TPostAddDto, TPostEditDto, TPostGetDto> where TPostAddDto : PostAddDto where TPostEditDto : PostEditDto where TPostGetDto : PostGetDto
    {
    }
}
