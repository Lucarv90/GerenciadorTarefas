using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Projeto.WEB.Models
{
    public class UsuarioCadastroModel
    {
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage ="E-mail inválido.")]
        [Required(ErrorMessage ="Campo brigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Campo obrigatório.")]
        [DataType(DataType.Password)]
        [StringLength(10, MinimumLength =6, ErrorMessage ="A senha deve possuir entre 6 e 10 caracteres.")]
        public string Senha { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("Senha", ErrorMessage ="Senhas não conferem.")]
        [Required(ErrorMessage ="Campo obrigatório.")]
        public string SenhaConfirm { get; set; }

        [Required(ErrorMessage ="Selecione o perfil.")]
        public int IdPermissao  { get; set; }

        public List<SelectListItem> ListagemPermissao { get; set; }

    }
}