using Microsoft.AspNetCore.Mvc;
using ProjetoAspMvc.Models;

public class AutenticacaoController : Controller
{
    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Login(Usuario usuario)
    {
        // Lógica de autenticação aqui (verificar se o usuário existe no banco de dados, etc.)
        // Por enquanto, faremos uma verificação simples da senha como exemplo.

        if (usuario.userName == "Keol" && usuario.password == "senha")
        {
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ViewBag.MensagemErro = "Credenciais inválidas. Tente novamente.";
            return View();
        }
    }
}
