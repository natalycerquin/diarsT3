using N00019639.DB;
using N00019639.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N00019639.Strategy
{
    public class RutinaIntermedio : IRutina
    {
        private AppRutinasContext context;

        public RutinaIntermedio(AppRutinasContext context)
        {
            this.context = context;        
        }

        public void AsignarEjercicios(Rutina rutina)
        {
            var ejercicios = context.Ejercicios.ToList();
            var rand = new Random();
            for (var i = 0; i < 10; i++)
            {
                var ejercicioRutina = new EjercicioRutina();
                ejercicioRutina.RutinaId = rutina.Id;
                var index = rand.Next(ejercicios.Count);
                ejercicioRutina.EjercicioId = ejercicios[index].Id;
                ejercicioRutina.Duracion = rand.Next(60, 121);
                context.EjercicioRutinas.Add(ejercicioRutina);
                context.SaveChanges();
            }
        }
    }
}
