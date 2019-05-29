using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SoyerApp.DAO
{
    public class Conexao
    {
        string conecta = "DATABASE = soyer; SERVER = localhost; UID = root; PWD = 0405";
        protected MySqlConnection conexao = null;

        //método para abrir conexão com o banco de dados
        public void AbrirConexao()
        {
            try
            {
                conexao = new MySqlConnection(conecta);
                conexao.Open();
            }
            catch(Exception erro)
            {
                throw erro;
            } 
        }

        //método para fechar conexão com o banco de dados
        public void FecharConexao()
        {
            try
            {
                conexao = new MySqlConnection(conecta);
                conexao.Close();
            }
            catch(Exception erro)
            {
                throw erro;
            }
        }
    }
}
