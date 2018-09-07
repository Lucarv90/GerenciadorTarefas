using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entidades
{
    public class Tarefa
    {
        public int IdTarefa { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int IdUsuario { set; get; }
        public Usuario Usuario { get; set; }

        public Tarefa()
        {

        }

        public Tarefa(int idTarefa, string titulo, string descricao, int idUsuario)
        {
            IdTarefa = idTarefa;
            Titulo = titulo;
            Descricao = descricao;
            IdUsuario = idUsuario;
        }

        public override string ToString()
        {
            return $"{IdTarefa}, {Titulo}, {Descricao}, {IdUsuario}";
        }
    }
}
