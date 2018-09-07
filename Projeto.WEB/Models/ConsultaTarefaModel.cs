using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.WEB.Models
{
    public class ConsultaTarefaModel
    {
        public int IdTarefa { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int IdUsuario { set; get; }
    }
}