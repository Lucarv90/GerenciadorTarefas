using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.WEB.Models;
using Projeto.Entidades;
using Projeto.DAL.Repositorios;
using Projeto.Util;

namespace Projeto.WEB.Controllers
{
    public class UsuarioController : Controller
    {
        
        // GET: Usuario
        public ActionResult Cadastro()
        {
            return View(CarregarModelCadastro());
        }

        
        [HttpPost]
        public ActionResult Cadastro(UsuarioCadastroModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Senha.Equals(model.SenhaConfirm))
                    {
                        UsuarioRep rep = new UsuarioRep();
                        if (!rep.HasName(model.Nome))
                        {
                            Criptografia c = new Criptografia();
                            Usuario u = new Usuario();
                            u.Permissao = new Permissao();

                            u.Nome = model.Nome;
                            u.Email = model.Email;                            
                            u.Senha = c.ToEncrypt(model.Senha);
                            u.Permissao.IdPermissao = model.IdPermissao;

                            rep.Insert(u);
                            ViewBag.Mensagem = "Usuario cadastrado com sucesso!";
                            ModelState.Clear();
                        }
                        else
                        {
                            ViewBag.Mensagem = "Este usuário já existe! Favor, criar outro...";
                        }
                    }
                    else
                    {
                        ViewBag.Mensagem = "Senhas não conferem.";
                    }
                }
            }
            catch(Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }
            return View(CarregarModelCadastro());
        }

        private UsuarioCadastroModel CarregarModelCadastro()
        {
            UsuarioCadastroModel model = new UsuarioCadastroModel();

            model.ListagemPermissao = new List<SelectListItem>();

            PermissaoRep rep = new PermissaoRep();
            foreach(Permissao p in rep.ListarTodos())
            {
                SelectListItem item = new SelectListItem();
                item.Value = p.IdPermissao.ToString();
                item.Text = p.Nome;

                model.ListagemPermissao.Add(item);
            }
            return model;
        }
    }
}