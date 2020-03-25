using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Post
{
    public sealed class PostConfiguration : EntityConfiguration<Domain.Entities.Post>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.Post> builder)
        {
            builder?.Property(p => p.Subject)
                .IsRequired()
                .HasMaxLength(250);

            builder?.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(1500);

            builder?.Property(p => p.ImageAddress)
                .HasMaxLength(1500);

            base.Configure(builder);
        }
    }
}
