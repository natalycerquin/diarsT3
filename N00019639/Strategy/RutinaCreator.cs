using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using N00019639.DB;
using N00019639.Models;

namespace N00019639.Strategy
{
    public class RutinaCreator
    {
        private IRutina tipoRutina;
        private Rutina rutina;
        private AppRutinasContext context;

        public RutinaCreator(Rutina rutina, AppRutinasContext context)
        {
            this.context = context;
            this.rutina = rutina;

            if (rutina.Tipo == "Principiante")
            {
                tipoRutina = new RutinaPrincipiante(context);
            }

            if (rutina.Tipo == "Intermedio")
            {
                tipoRutina = new RutinaIntermedio(context);
            }

            if (rutina.Tipo == "Avanzado")
            {
                tipoRutina = new RutinaAvanzada(context);
            }
        }

        public void AsignarEjercicios()
        {
            if (tipoRutina != null)
            {
                tipoRutina.AsignarEjercicios(rutina);
            } 
        }
    }
}
