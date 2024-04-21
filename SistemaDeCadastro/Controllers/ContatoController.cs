using ControledeContatos.Models;
using ControledeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControledeContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Deletar(int id) //Mostra o nome do contato que a pessoa deseja apagar
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id) //de fato apagar o contato
        {
            try
            {
                bool apagado = _contatoRepositorio.Deletar(id);

                if(apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso.";
                }
                else
                {
                    TempData["MensagemSucesso"] = "Ops, não conseguimos apagar este contato.";
                }
                return RedirectToAction("Index");
               
            }
            catch (System.Exception)
            {
                TempData["MensagemErro"] = "Ops, algo deu errado.";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);

                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso.";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (System.Exception)
            {
                TempData["MensagemErro"] = "Ops, algo deu errado.";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato editado com sucesso.";
                    return RedirectToAction("Index");
                }
                return View("Editar", contato);//Forçando a cair na view Editar
            }
            catch (System.Exception)
            {
                TempData["MensagemErro"] = "Ops, algo deu errado.";
                return RedirectToAction("Index");
            }
        }
    }
}
