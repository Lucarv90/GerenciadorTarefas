using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Projeto.Entidades;

namespace Projeto.DAL.Repositorios
{
    public class PermissaoRep : Conexao
    {
        public List<Permissao> ListarTodos()
        {
            OpenConnection();

            string query = "select * from Permissao order by Nome asc";

            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();

            List<Permissao> lista = new List<Permissao>();

            while (dr.Read())
            {
                Permissao p = new Permissao();
                p.IdPermissao = Convert.ToInt32(dr["IdPermissao"]);
                p.Nome = Convert.ToString(dr["Nome"]);

                lista.Add(p);
            }
            CloseConnection();
            return lista;
        }

    }
}
