using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.WEB.Models
{
    public class TarefaEdicaoModel
    {
        
        public int IdTarefa { get; set; }

        [MinLength(3, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [Required(ErrorMessage ="Informe o título da tarefa.")]
        public string Titulo { get; set; }

        [MaxLength(2000, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Descreva a sua tarefa.")]
        public string Descricao { get; set; }
        public int IdUsuario { set; get; }
    }
}