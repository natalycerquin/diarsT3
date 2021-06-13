using N00019639.DB;
using N00019639.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N00019639.Strategy
{
    public class RutinaAvanzada : IRutina
    {
        private AppRutinasContext context;

        public RutinaAvanzada(AppRutinasContext context)
        {
            this.context = context;
        }

        public void AsignarEjercicios(Rutina rutina)
        {
            var ejercicios = context.Ejercicios.ToList();
            var rand = new Random();
            for (var i = 0; i < 15; i++)
            {
                var ejercicioRutina = new EjercicioRutina();
                ejercicioRutina.RutinaId = rutina.Id;
                var index = rand.Next(ejercicios.Count);
                ejercicioRutina.EjercicioId = ejercicios[index].Id;
                ejercicioRutina.Duracion = 120;
                context.EjercicioRutinas.Add(ejercicioRutina);
                context.SaveChanges();
            }
        }
    }
}
