using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using N00019639.DB.Maps;
using N00019639.Models;

namespace N00019639.DB
{
    public class AppRutinasContext : DbContext
    {
        public DbSet<Ejercicio> Ejercicios { get; set; }
        public DbSet<EjercicioRutina> EjercicioRutinas { get; set; }
        public DbSet<Rutina> Rutinas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public AppRutinasContext(DbContextOptions<AppRutinasContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EjercicioMap());
            modelBuilder.ApplyConfiguration(new EjercicioRutinaMap());
            modelBuilder.ApplyConfiguration(new RutinaMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());

        }
    }
}
