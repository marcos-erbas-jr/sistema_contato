﻿
using ControledeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using SistemaDeCadastro.Models;


namespace SistemaDeCadastro.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            List<UsuarioModel> usarios = _usuarioRepositorio.BuscarTodos();
            return View(usarios);
        }

        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        public IActionResult Deletar(int id) //Mostra o nome do contato que a pessoa deseja apagar
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        public IActionResult Apagar(int id) //de fato apagar o usuario
        {
            try
            {
                bool apagado = _usuarioRepositorio.Deletar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuário apagado com sucesso.";
                }
                else
                {
                    TempData["MensagemSucesso"] = "Ops, não conseguimos apagar este usuário.";
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
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);

                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso.";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (System.Exception)
            {
                TempData["MensagemErro"] = "Ops, algo deu errado.";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Alterar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuário editado com sucesso.";
                    return RedirectToAction("Index");
                }
                return View("Editar", usuario);//Forçando a cair na view Editar
            }
            catch (System.Exception)
            {
                TempData["MensagemErro"] = "Ops, algo deu errado.";
                return RedirectToAction("Index");
            }
        }
    }

}
