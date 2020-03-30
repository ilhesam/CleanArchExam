using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.ViewModels.DataTransferObjects.Common;
using AutoMapper;
using Domain.Common;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Services
{
    public abstract class AsyncService<TEntity, TEntityAddDto, TEntityEditDto, TEntityGetDto> : IAsyncService<TEntityAddDto, TEntityEditDto, TEntityGetDto> where TEntity : Entity where TEntityAddDto : EntityAddDto where TEntityEditDto : EntityEditDto where TEntityGetDto : EntityGetDto
    {
        protected readonly IAsyncRepository<TEntity> Repository;
        protected readonly IMapper Mapper;

        protected AsyncService(IAsyncRepository<TEntity> repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public async Task<List<TEntityGetDto>> ListAllAsync() => await GetAll().ToListAsync();

        public IQueryable<TEntityGetDto> GetAll() => Repository.GetAll()
                .Select(e => Mapper.Map<TEntity, TEntityGetDto>(e));

        public virtual async Task<TEntityGetDto> GetByIdAsync(int id)
        {
            var entity = await Repository.GetByIdAsync(id);

            return Mapper.Map<TEntity, TEntityGetDto>(entity);
        }

        public virtual async Task<TEntityGetDto> AddAsync(TEntityAddDto entityAddDto)
        {
            var entity = Mapper.Map<TEntityAddDto, TEntity>(entityAddDto);
            await Repository.AddAsync(entity);

            return Mapper.Map<TEntity, TEntityGetDto>(entity);
        }

        public virtual async Task UpdateAsync(int id, TEntityEditDto entityEditDto)
        {
            var entity = Mapper.Map<TEntityEditDto, TEntity>(entityEditDto);
            entity.Id = id;

            await Repository.UpdateAsync(entity);
        }

        public virtual async Task DeleteAsync(int id) => await Repository.DeleteAsync(id);
    }
}
