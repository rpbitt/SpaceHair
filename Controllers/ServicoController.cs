using System;
using SpaceHair.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace SpaceHair.Controllers
{
    public class ServicoController : Controller
    {
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        // Lista
        public IActionResult Lista()
        {
            //objetivo juntar a models com a controllers e a views
            if (HttpContext.Session.GetInt32("IdColaborador") == null)
            {
                return RedirectToAction("Login");
            }

            ServicoRepository cr = new ServicoRepository();
            List<Servico> Listagem = cr.listar();
            return View(Listagem);
        }
        // Remover
        public IActionResult Remover(int Id)
        {
            if (HttpContext.Session.GetInt32("IdColaborador") == null)
            {
                return RedirectToAction("Login");
            }
            ServicoRepository cr = new ServicoRepository();
            Servico serv = cr.buscarPorId(Id);
            cr.remover(serv);

            return RedirectToAction("Lista");
        }
        // Editar        
        public IActionResult Editar(int Id)
        {
            if (HttpContext.Session.GetInt32("IdColaborador") == null)
            {
                return RedirectToAction("Login");
            }
            ServicoRepository cr = new ServicoRepository();
            Servico serv = cr.buscarPorId(Id);
            return View(serv);
        }
        // Editar - grava no banco
        [HttpPost]
        public IActionResult Editar(Servico servForm)
        {
            ServicoRepository cr = new ServicoRepository();
            cr.atualizar(servForm);
            return RedirectToAction("Lista");
        }
        // Cadastro
        public IActionResult Cadastro()
        {
            return View();
        }

        // Cadastro - grava no banco
        [HttpPost]
        public IActionResult Cadastro(Servico servForm)
        {
            ServicoRepository cr = new ServicoRepository();
            cr.inserir(servForm);
            ViewBag.Mensagem = "Cadastro realizado com sucesso!";
            return View();
        }
    }

}