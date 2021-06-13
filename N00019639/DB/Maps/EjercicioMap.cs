using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using N00019639.Models;

namespace N00019639.DB.Maps
{
    public class EjercicioMap : IEntityTypeConfiguration<Ejercicio>
    {
        public void Configure(EntityTypeBuilder<Ejercicio> builder)
        {
            builder.ToTable("Ejercicios");
            builder.HasKey(o => o.Id);

            builder.HasMany(o => o.EjercicioRutinas).WithOne(o => o.Ejercicio).HasForeignKey(o => o.EjercicioId);
        }
    }
}
