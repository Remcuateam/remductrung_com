using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using AspNetMvc.Data.EF.Extensions;
using AspNetMvc.Data.Entities;
using AspNetMvc.Data.Entities.System;

namespace AspNetMvc.Data.EF.Configurations
{
    public class FunctionConfiguration : DbEntityConfiguration<Function>
    {
        public override void Configure(EntityTypeBuilder<Function> entity)
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).IsRequired()
            .HasMaxLength(128).IsUnicode(false);
            //.HasColumnType("varchar(16)");
            //entity.Property(c => c.ParentId).HasColumnType("varchar(16)");
            // etc.
        }
    }
}
