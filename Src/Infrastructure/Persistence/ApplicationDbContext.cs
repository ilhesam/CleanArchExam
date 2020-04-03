using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Infrastructure.Persistence.Configurations.Author;
using Infrastructure.Persistence.Configurations.Post;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        #region Constructors

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        #endregion

        #region Properties

        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<Post> Posts { get; set; }

        #endregion

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder?.ApplyConfiguration<Author>(new AuthorConfiguration());
            modelBuilder?.ApplyConfiguration<Post>(new PostConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
