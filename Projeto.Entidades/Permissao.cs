using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Entidades
{
    public class Permissao
    {
        public int IdPermissao { get; set; }
        public string Nome { get; set; }

        public Permissao()
        {

        }

        public Permissao(int idPermissao, string nome)
        {
            IdPermissao = idPermissao;
            Nome = nome;
        }

        public override string ToString()
        {
            return $"{IdPermissao}, {Nome}";
        }
    }
}
