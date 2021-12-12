using System;
using SpaceHair.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace SpaceHair.Controllers
{
    public class ColaboradorController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Colaborador colabForm)
        {
            ColaboradorRepository cr = new ColaboradorRepository();
            Colaborador userSessao = cr.validarLogin(colabForm);

            if (userSessao != null) // significa que localizou usuario no banco
            {
                ViewBag.Mensagem = "Você está logado!";
                //carregando na Sessao informacoes do meu objeto
                HttpContext.Session.SetInt32("IdColaborador", userSessao.Id);
                HttpContext.Session.SetString("NomeColaborador", userSessao.Nome);
                //redirecionar
                return RedirectToAction("Lista");

            }
            else
            {
                ViewBag.Mensagem = "Falha no login!";
                return View();
            }
        }
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

            ColaboradorRepository cr = new ColaboradorRepository();
            List<Colaborador> Listagem = cr.listar();
            return View(Listagem);
        }
        // Remover
        public IActionResult Remover(int Id)
        {
            if (HttpContext.Session.GetInt32("IdColaborador") == null)
            {
                return RedirectToAction("Login");
            }
            ColaboradorRepository cr = new ColaboradorRepository();
            Colaborador colab = cr.buscarPorId(Id);
            cr.remover(colab);

            return RedirectToAction("Lista");

        }
        // Editar        
        public IActionResult Editar(int Id)
        {
            if (HttpContext.Session.GetInt32("IdColaborador") == null)
            {
                return RedirectToAction("Login");
            }
            ColaboradorRepository cr = new ColaboradorRepository();
            Colaborador colab = cr.buscarPorId(Id);
            return View(colab);
        }
        // Editar - grava no banco
        [HttpPost]
        public IActionResult Editar(Colaborador colabForm)
        {
            ColaboradorRepository cr = new ColaboradorRepository();
            cr.atualizar(colabForm);
            return RedirectToAction("Lista");

        }
        // Cadastro
        public IActionResult Cadastro()
        {
            return View();
        }

        // Cadastro - grava no banco
        [HttpPost]
        public IActionResult Cadastro(Colaborador colabForm)
        {
            ColaboradorRepository cr = new ColaboradorRepository();
            cr.inserir(colabForm);
            ViewBag.Mensagem = "Cadastro realizado com sucesso!";
            return View();
        }
    }

}