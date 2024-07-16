using SistemaDeCadastro.Models;
using Microsoft.AspNetCore.Mvc;
using ControledeContatos.Repositorio;
using SistemaDeCadastro.Helper;

namespace SistemaDeCadastro.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        private readonly ISessao _sessao;

        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            //Se o usuário estiver logado, redirecionar para a Home

            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

                    //Administrador teste: admin | senha: 123456   / usuário teste: user | senha:123456
                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoDoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = $"A senha informada é inválida. Por favor, tente novamente.";
                        
                    }
                    TempData["MensagemErro"] = $"Usuário ou senha inválido(s). Por favor, tente novamente.";

                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = "Ops, algo está errado. Verifique seu usuário e senha.";
                return RedirectToAction("Index");
            }
        }
    }
}
