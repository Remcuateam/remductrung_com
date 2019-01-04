using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using AspNetMvc.Data.EF.Extensions;
using AspNetMvc.Data.Entities;
using AspNetMvc.Data.Entities.System;

namespace AspNetMvc.Data.EF.Configurations
{
    class SystemConfigConfiguration : DbEntityConfiguration<Setting>
    {
        public override void Configure(EntityTypeBuilder<Setting> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(255).IsRequired();
            // etc.
        }
    }
}
