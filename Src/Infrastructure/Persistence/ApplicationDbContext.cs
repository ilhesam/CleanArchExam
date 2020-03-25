using System;
using System.Collections.Generic;
using System.Text;
using Domain;
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

        public virtual DbSet<Post> Posts { get; set; }

        #endregion

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder?.ApplyConfiguration<Post>(new PostConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
