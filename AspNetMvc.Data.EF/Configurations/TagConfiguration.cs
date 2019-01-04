using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using AspNetMvc.Data.EF.Extensions;
using AspNetMvc.Data.Entities;
using AspNetMvc.Data.Entities.Content;

namespace AspNetMvc.Data.EF.Configurations
{
    public class TagConfiguration : DbEntityConfiguration<Tag>
    {
        public override void Configure(EntityTypeBuilder<Tag> entity)
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasMaxLength(255).HasColumnType("varchar(255)").IsRequired();
            //entity.Property(c => c.Id).HasMaxLength(255).IsRequired().HasColumnType("varchar(255)");
        }
    }
}
