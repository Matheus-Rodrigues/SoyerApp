using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SoyerApp.Model;
using System.Data;

namespace SoyerApp.DAO
{
    public class PessoaDAO: Conexao
    {
        MySqlCommand comando = null;

        //método para salvar os dados na tabela pessoa
        public void Salvar(Pessoa pessoa)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("INSERT INTO pessoa (nome, sexo, contato, endereco, bairro, cidade, estado) VALUES (@Nome, @Sexo, @Contato, @Endereco, @Bairro, @Cidade, @Estado)", conexao);
                comando.Parameters.AddWithValue("@nome", pessoa.Nome);
                comando.Parameters.AddWithValue("@sexo", pessoa.Sexo);
                comando.Parameters.AddWithValue("@contato", pessoa.Contato);
                comando.Parameters.AddWithValue("@endereco", pessoa.Endereco);
                comando.Parameters.AddWithValue("@bairro", pessoa.Bairro);
                comando.Parameters.AddWithValue("@cidade", pessoa.Cidade);
                comando.Parameters.AddWithValue("@estado", pessoa.Estado);

                comando.ExecuteNonQuery();
            }
            catch(Exception erro)
            {
                throw erro;
            }
            finally
            {
                conexao.Close();
            }

        }

        //método para mostrar os dados da tabela pessoa
        public DataTable Listar()
        {
            try
            {
                AbrirConexao();

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();

                comando = new MySqlCommand("SELECT * FROM pessoa ORDER BY id", conexao);
                da.SelectCommand = comando;

                da.Fill(dt);
                return dt;
            }
            catch(Exception erro)
            {
                throw erro;
            }
            finally
            {
                FecharConexao();
            }

        }

        //método para editar os dados
        public void Editar(Pessoa pessoa)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("UPDATE pessoa SET nome = @nome, sexo = @sexo, contato = @contato, endereco = @endereco, bairro = @bairro, cidade = @cidade, estado = @estado WHERE id = @id", conexao);

                comando.Parameters.AddWithValue("@id", pessoa.Id);
                comando.Parameters.AddWithValue("@nome", pessoa.Nome);
                comando.Parameters.AddWithValue("@sexo", pessoa.Sexo);
                comando.Parameters.AddWithValue("@contato", pessoa.Contato);
                comando.Parameters.AddWithValue("@endereco", pessoa.Endereco);
                comando.Parameters.AddWithValue("@bairro", pessoa.Bairro);
                comando.Parameters.AddWithValue("@cidade", pessoa.Cidade);
                comando.Parameters.AddWithValue("@estado", pessoa.Estado);

                comando.ExecuteNonQuery();
            }
            catch(Exception erro)
            {
                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }

        //método para exlcuir dados
        public void Excluir(Pessoa pessoa)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("DELETE FROM pessoa WHERE Id = @id", conexao);
                comando.Parameters.AddWithValue("@id", pessoa.Id);
                comando.ExecuteNonQuery();
            }
            catch(Exception erro)
            {
                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }

    }
}
