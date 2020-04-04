using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class AuthorRepository : AsyncRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
