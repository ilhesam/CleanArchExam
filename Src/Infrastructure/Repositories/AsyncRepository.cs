﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public abstract class AsyncRepository<TEntity> : IAsyncRepository<TEntity> where TEntity : Entity
    {
        protected readonly ApplicationDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected AsyncRepository(ApplicationDbContext db)
        {
            Db = db;
            DbSet = Db.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll() => DbSet.AsNoTracking();

        public virtual async Task<TEntity> GetByIdAsync(int id) => await DbSet.FindAsync(id);

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await Db.SaveChangesAsync();

            return entity;
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);
            await Db.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            DbSet.Remove(entity);
            await Db.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            await DeleteAsync(entity);
        }

        public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate) =>
            await DbSet.AnyAsync(predicate);

        public virtual async Task<bool> ExistsByIdAsync(int id) => await ExistsAsync(e => e.Id == id);
    }
}
