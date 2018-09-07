using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Projeto.Entidades;

namespace Projeto.DAL.Repositorios
{
    public class UsuarioRep : Conexao
    {
        public void Insert(Usuario u)
        {
            OpenConnection();

            string query = "insert into Usuario(Nome, Email, Senha, IdPermissao) "
                         + "values (@Nome, @Email, @Senha, @IdPermissao)";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", u.Nome);
            cmd.Parameters.AddWithValue("@Email", u.Email);
            cmd.Parameters.AddWithValue("@Senha", u.Senha);
            cmd.Parameters.AddWithValue("@IdPermissao", u.Permissao.IdPermissao);
            cmd.ExecuteNonQuery();

            CloseConnection();

        }

        //retornando um Nome de Usuário
        public bool HasName(string nome)
        {
            OpenConnection();

            string query = "select count(*) from Usuario where Nome = @Nome";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", nome);
            int qtd = Convert.ToInt32(cmd.ExecuteScalar());

            CloseConnection();
            return qtd > 0; //verdadeiro, falso
        }


        //retornando um email já cadastrado

        public bool HasEmail(string email)
        {
            OpenConnection();

            string query = "select count(*) from Usuario where Email = @Email";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Email", email);
            int qtd = Convert.ToInt32(cmd.ExecuteScalar());

            CloseConnection();

            return qtd > 0;
        }

        //Achar um usuário pelo nome e senha
        public Usuario FindByNamePass(string nome, string senha)
        {
            OpenConnection();
            string query = "select * from Usuario where Nome = @Nome and Senha = @Senha";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", nome);
            cmd.Parameters.AddWithValue("@Senha", senha);
            dr = cmd.ExecuteReader();
            Usuario u = null; //inicializa sem espaço de memória
            if(dr.Read())//caso encontre
            {
                u = new Usuario();//abrir espaço de memória
                u.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                u.Nome = Convert.ToString(dr["Nome"]);
                u.Senha = Convert.ToString(dr["Senha"]);                


            }
            CloseConnection();
            return u;

        }

        public Usuario FindByName(string nome)
        {
            OpenConnection();
            string query = "select * from Usuario where Nome = @Nome";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", nome);
            dr = cmd.ExecuteReader();
            Usuario u = null;
            if (dr.Read())
            {
                u = new Usuario();
                u.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                u.Nome = Convert.ToString(dr["Nome"]);
                u.Email = Convert.ToString(dr["Email"]);
                u.Senha = Convert.ToString(dr["Senha"]);
            }


            CloseConnection();
            return u;
        }

    }
}
