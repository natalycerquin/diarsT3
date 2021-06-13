using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using N00019639.DB;
using N00019639.Models;
using N00019639.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace N00019639.Controllers
{
    [Authorize]
    public class RutinaController : Controller
    {

        private AppRutinasContext context;

        public RutinaController(AppRutinasContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var usuario = GetUsuario();
            var rutinas = context.Rutinas.Include(o => o.EjercicioRutinas).ThenInclude(o => o.Ejercicio).Where(x => x.UsuarioId == usuario.Id).ToList();
            return View(rutinas);
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(Rutina rutina)
        {

            var usuario = GetUsuario();

            if (string.IsNullOrEmpty(rutina.Nombre))
            {
                ModelState.AddModelError("Error", "El nombre de la rutina es obligatorio.");
                return View();
            }

            rutina.UsuarioId = usuario.Id;
            context.Rutinas.Add(rutina);
            context.SaveChanges();
            var registradorEjercicios = new RutinaCreator(rutina, context);
            registradorEjercicios.AsignarEjercicios();
            return RedirectToAction("Index");            
        }

        public IActionResult Detalle(int id)
        {
            var rutina = context.Rutinas.Include(o => o.EjercicioRutinas).ThenInclude(o => o.Ejercicio).Where(x => x.Id == id).FirstOrDefault();
            return View(rutina);
        }

        private Usuario GetUsuario()
        {
            var claim = HttpContext.User.Claims.Where(o => o.Type == ClaimTypes.Name).FirstOrDefault();
            if (claim != null)
            {
                return context.Usuarios.Where(o => o.Username == claim.Value).FirstOrDefault();
            }
            else
            {
                return null;
            }
        }
    }
}
