using Microsoft.AspNetCore.Mvc;
using Social.NetWork.Dominio;

namespace WebAppOB2P2.Controllers
{
    public class IndexController : Controller
    {   
        public static Sistema sistema =  Sistema.Instancia;


        public IActionResult Inicio(string mensaje)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuarioLogueado")))
            {
                return RedirectToAction("Login", "Login", new { mensaje = "Necesita iniciar sesion primero!"});
            }
            ViewBag.mensaje = mensaje;
            ViewBag.usuario = HttpContext.Session.GetString("usuarioLogueado");
            return View(sistema.GetUsuarios());
        }

        public IActionResult VerPublicaciones() {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuarioLogueado")))
            {
                return RedirectToAction("Login", "Login", new { mensaje = "Necesita iniciar sesion primero!" });
            }
            return View();
        }
        public IActionResult VerPublicacionesAdmin()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuarioLogueado")))
            {
                return RedirectToAction("Login", "Login", new { mensaje = "Necesita iniciar sesion primero!" });
            }
            return View();
        }

        public IActionResult VerMiembrosAdmin()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuarioLogueado")))
            {
                return RedirectToAction("Login", "Login", new { mensaje = "Necesita iniciar sesion primero!" });
            }
            return View();
        }

        public IActionResult VerPublicacionesFilt(string valorTitulo, int valorVA)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuarioLogueado")))
            {
                return RedirectToAction("Login", "Login", new { mensaje = "Necesita iniciar sesion primero!" });
            }
            List<Post> postsFiltrados = Sistema.Instancia.FiltrarPosts(valorTitulo, valorVA);
            return View(postsFiltrados);
        }
    }
}
