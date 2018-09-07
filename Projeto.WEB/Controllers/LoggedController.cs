using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Projeto.WEB.Models;
using Projeto.DAL.Repositorios;
using Projeto.Entidades;
using System.Net.Http;

namespace Projeto.WEB.Controllers
{
    public class LoggedController : Controller
    {
        // GET: Logged
        [Authorize]
        public ActionResult Index()
        {
            List<ConsultaTarefaModel> lista = new List<ConsultaTarefaModel>();
            try
            {
                TarefaRep rep = new TarefaRep();
                foreach(Tarefa t in rep.FindAll())
                {
                    ConsultaTarefaModel model = new ConsultaTarefaModel();
                    UsuarioRep repUsuario = new UsuarioRep();

                    t.Usuario = new Usuario();
                    t.Usuario = repUsuario.FindByName(User.Identity.Name);

                    model.IdTarefa = t.IdTarefa;
                    model.Titulo = t.Titulo;
                    model.Descricao = t.Descricao;
                    

                    lista.Add(model);
                }
            }
            catch(Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }


            return View(lista);
        }

        //GET
        public ActionResult Cadastro()
        {
            return View();
        }

        //POST: Cadastro
        [HttpPost]        
        public ActionResult Cadastro(TarefaCadastroModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UsuarioRep repUsuario = new UsuarioRep();

                    Tarefa t = new Tarefa();
                    t.Usuario = repUsuario.FindByName(User.Identity.Name);

                    t.Titulo = model.Titulo;
                    t.Descricao = model.Descricao;
                    

                    TarefaRep rep = new TarefaRep();
                    rep.Insert(t);
                    ViewBag.Mensagem = "Tarefa Cadastrada com sucesso.";
                    ModelState.Clear();
                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }
                return View(model);

            }
            return View();
        }



        //GET: Tarefa/Edicao 
        public ActionResult Edicao()
        {
            TarefaEdicaoModel model = new TarefaEdicaoModel();

            

            try
            {
                UsuarioRep repUsuario = new UsuarioRep();

                Tarefa t = new Tarefa();
                t.Usuario = repUsuario.FindByName(User.Identity.Name);

                int idTarefa = int.Parse(Request.QueryString["id"]);


                model.IdTarefa = t.IdTarefa;
                model.Titulo = t.Titulo;
                model.Descricao = t.Descricao;
                model.IdUsuario = t.Usuario.IdUsuario;

                TarefaRep rep = new TarefaRep();
                rep.Update(t);
                ViewBag.Mensagem = "Tarefa atualizada com sucesso.";

            }
            catch(Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }

            return View(model);
        }

        [HttpPost]      
        public ActionResult Edicao(TarefaEdicaoModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UsuarioRep repUsuario = new UsuarioRep();

                    Tarefa t = new Tarefa();
                    t.Usuario = repUsuario.FindByName(User.Identity.Name);

                    t.IdTarefa = model.IdTarefa;
                    t.Titulo = model.Titulo;
                    t.Descricao = model.Descricao;
                    t.Usuario.IdUsuario = model.IdUsuario;


                    TarefaRep rep = new TarefaRep();
                    rep.Update(t);
                    ViewBag.Mensagem = "Atualizado com sucesso.";
                    ModelState.Clear(); //Aqui eu limpo os campos do formulário
                }
                catch(Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }
            }

            return View();
        }

        //get
        public ActionResult Excluir()
        {
            TarefaExclusaoModel model = new TarefaExclusaoModel();

            try
            {
                int idTarefa = int.Parse(Request.QueryString["id"]);

                TarefaRep rep = new TarefaRep();
                Tarefa t = rep.FindById(idTarefa);

                model.IdTarefa = t.IdTarefa;
                model.Titulo = t.Titulo;
                model.Descricao = t.Descricao;
            }
            catch(Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }

            return View(model);
        }

        [HttpPost]        
        public ActionResult Excluir(TarefaExclusaoModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UsuarioRep repUsuario = new UsuarioRep();

                    Tarefa t = new Tarefa();
                    t.Usuario = repUsuario.FindByName(User.Identity.Name);

                    t.IdTarefa = model.IdTarefa;
                    t.Titulo = model.Titulo;
                    t.Descricao = model.Descricao;

                    TarefaRep rep = new TarefaRep();
                    rep.Delete(t);

                    ModelState.Clear();
                }
                catch(Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }
            }
            return View();
        }
    }
}