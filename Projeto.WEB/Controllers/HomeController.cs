using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.WEB.Models;
using Projeto.Entidades;
using Projeto.DAL.Repositorios;
using Projeto.Util;
using System.Web.Security;

namespace Projeto.WEB.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UsuarioLoginModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Criptografia c = new Criptografia();

                    UsuarioRep rep = new UsuarioRep();
                    Usuario u = rep.FindByNamePass(model.Login, c.ToEncrypt(model.Senha));

                    if(u != null)
                    {
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(u.Nome, false, 5);

                        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));

                        Response.Cookies.Add(cookie);

                        Session["usuario"] = u;

                        return RedirectToAction("Index", "Logged");
                    }
                    else
                    {
                        ViewBag.Mensagem = "Acesso Negado.";
                    }
                }
                catch(Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Remove("Usuario");

            return RedirectToAction("Index", "Home");
        }
    }
}