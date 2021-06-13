using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using N00019639.Models;

namespace N00019639.DB.Maps
{
    public class EjercicioRutinaMap : IEntityTypeConfiguration<EjercicioRutina>
    {
        public void Configure(EntityTypeBuilder<EjercicioRutina> builder)
        {
            builder.ToTable("EjercicioRutinas");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Rutina).WithMany(o => o.EjercicioRutinas).HasForeignKey(o => o.RutinaId);
            builder.HasOne(o => o.Ejercicio).WithMany(o => o.EjercicioRutinas).HasForeignKey(o => o.EjercicioId);
        }
    }
}
