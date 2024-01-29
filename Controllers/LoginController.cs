using Microsoft.AspNetCore.Mvc;
using ProjetoAspMvc.Models;

namespace ProjetoAspMvc.Controllers
{
    public class LoginController : Controller
    {
        private ContextoLogin _context;
        public LoginController() {
            _context = new ContextoLogin();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Usuario usuario)
        {
            if (usuario.Authenticate(usuario.userName, usuario.password))
            {
                return RedirectToAction("Index");
            }
            else { return View(); }
        }

        public IActionResult Index() { return View(); }
    }
}
