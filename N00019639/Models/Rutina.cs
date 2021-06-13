using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N00019639.Models
{
    public class Rutina
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public Usuario Usuario { get; set; }
        public List<EjercicioRutina> EjercicioRutinas { get; set; }
    }
}
