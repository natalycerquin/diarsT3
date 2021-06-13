using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using N00019639.Models;

namespace N00019639.DB.Maps
{
    public class RutinaMap : IEntityTypeConfiguration<Rutina>
    {
        public void Configure(EntityTypeBuilder<Rutina> builder)
        {
            builder.ToTable("Rutinas");
            builder.HasKey(o => o.Id);
            builder.HasMany(o => o.EjercicioRutinas).WithOne(o => o.Rutina).HasForeignKey(o => o.RutinaId);
        }
    }
}
