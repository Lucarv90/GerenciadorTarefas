using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.WEB.Models
{
    public class UsuarioLoginModel
    {
        [Required(ErrorMessage ="Informe o login.")]
        public string Login { get; set; }

        [Required(ErrorMessage ="Infome a senha.")]
        public string Senha { get; set; }

    }
}