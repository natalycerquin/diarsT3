using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N00019639.Models
{
    public class Ejercicio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Link { get; set; }
        public List<EjercicioRutina> EjercicioRutinas { get; set; }
    }
}
