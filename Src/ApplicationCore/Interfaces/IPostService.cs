using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.ViewModels.DataTransferObjects;

namespace ApplicationCore.Interfaces
{
    public interface IPostService<in TPostAddDto, TPostEditDto, TPostGetDto> : IAsyncService<TPostAddDto, TPostEditDto, TPostGetDto> where TPostAddDto : PostAddDto where TPostEditDto : PostEditDto where TPostGetDto : PostGetDto
    {
    }
}
