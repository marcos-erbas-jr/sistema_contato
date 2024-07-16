using Microsoft.AspNetCore.Mvc;
using SistemaDeCadastro.Filters;

namespace SistemaDeCadastro.Controllers
{
    [PaginaParaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
