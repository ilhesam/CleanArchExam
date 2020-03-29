﻿using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class PostRepository : AsyncRepository<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
