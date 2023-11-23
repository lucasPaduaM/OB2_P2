using Dominio;
using Microsoft.AspNetCore.Mvc;
using Social.NetWork.Dominio;

namespace Social.NetWork.Controllers
{
    public class ReaccionesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MeGusta(int idPost)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuarioLogueado")))
            {
                return RedirectToAction("Login", "Login", new { mensaje = "Necesita iniciar sesion primero!" });
            }

            Post postReaccion = Sistema.Instancia.GetPostPorId(idPost);
            Miembro usuarioReaccion = Sistema.Instancia.GetUsuario(HttpContext.Session.GetString("usuarioLogueado"));
            Reaccion reaccion = new Reaccion();
            reaccion.TipoReaccion = Reacciones.Like;
            reaccion.miembroReaccion = usuarioReaccion;
            postReaccion.valorDeAceptacion = postReaccion.CalcularVA(postReaccion.likes, postReaccion.dislikes);
            Sistema.Instancia.CrearReaccion(reaccion, postReaccion);

            return RedirectToAction("VerPublicaciones", "Index");
        }

        public IActionResult NoMeGusta(int idPost)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuarioLogueado")))
            {
                return RedirectToAction("Login", "Login", new { mensaje = "Necesita iniciar sesion primero!" });
            }

            Post postReaccion = Sistema.Instancia.GetPostPorId(idPost);
            Miembro usuarioReaccion = Sistema.Instancia.GetUsuario(HttpContext.Session.GetString("usuarioLogueado"));
            Reaccion reaccion = new Reaccion();
            reaccion.TipoReaccion = Reacciones.Dislike;
            reaccion.miembroReaccion = usuarioReaccion;
            postReaccion.valorDeAceptacion = postReaccion.CalcularVA(postReaccion.likes, postReaccion.dislikes);
            Sistema.Instancia.CrearReaccion(reaccion, postReaccion);

            return RedirectToAction("VerPublicaciones", "Index");
        }
    }
}