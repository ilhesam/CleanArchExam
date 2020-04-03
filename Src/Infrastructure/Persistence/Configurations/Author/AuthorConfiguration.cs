using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Author
{
    public class AuthorConfiguration : EntityConfiguration<Domain.Entities.Author>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.Author> builder)
        {
            builder?.Property(a => a.DisplayName)
                .IsRequired()
                .HasMaxLength(250);

            builder?.Property(a => a.RealName)
                .IsRequired()
                .HasMaxLength(250);

            builder?.Property(a => a.EmailAddress)
                .IsRequired()
                .HasMaxLength(250);

            builder?.Property(a => a.Password)
                .IsRequired()
                .HasMaxLength(250);

            base.Configure(builder);
        }
    }
}
