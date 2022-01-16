using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OTS.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OTS.Data.Configurations
{
    class CargoConfiguration
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {

            builder
                .HasKey(a => a.CargoId);

            //builder
            //    .Property(m => m.CargoId)
            //    .UseIdentityColumn();

            builder
                .Property(m => m.CargoName)
                .IsRequired()
                .HasMaxLength(100);

            //builder
            //    .ToTable("Artists");
        }

    }
}
