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
    class ProdutoDAO : Conexao
    {
        MySqlCommand comando = null;

        //método para salvar os dados na tabela pessoa
        public void Salvar(Produto produto)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("INSERT INTO produto (descricao_produto, quantidade_produto, precoVenda_produto, custo_produto, medida_produto, categoria_produto) VALUES (@descricao_produto, @quantidade_produto, @precoVenda_produto, @custo_produto, @medida_produto, @categoria_produto)", conexao);
                comando.Parameters.AddWithValue("@descricao_produto", produto.Descricao_produto);
                comando.Parameters.AddWithValue("@quantidade_produto", MySqlDbType.Double).Value = produto.Quantidade_produto;
                comando.Parameters.AddWithValue("@precoVenda_produto", MySqlDbType.Double).Value = produto.PrecoVenda_produto;
                comando.Parameters.AddWithValue("@custo_produto", MySqlDbType.Double).Value = produto.Custo_produto;
                comando.Parameters.AddWithValue("@medida_produto", produto.Medida_produto);
                comando.Parameters.AddWithValue("@categoria_produto", produto.Categoria_produto);

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
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

                comando = new MySqlCommand("SELECT * FROM produto ORDER BY id_produto", conexao);
                da.SelectCommand = comando;

                da.Fill(dt);
                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                FecharConexao();
            }

        }

        //método para editar os dados
        public void Editar(Produto produto)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("UPDATE produto SET descricao_produto = @descricao_produto, quantidade_produto = @quantidade_produto, precoVenda_produto = @precoVenda_produto, custo_produto = @custo_produto, medida_produto = @medida_produto, categoria_produto = @categoria_produto WHERE id_produto = @id_produto", conexao);

                comando.Parameters.AddWithValue("@descricao_produto", produto.Descricao_produto);
                comando.Parameters.AddWithValue("@quantidade_produto", MySqlDbType.Double).Value = produto.Quantidade_produto;
                comando.Parameters.AddWithValue("@precoVenda_produto", MySqlDbType.Double).Value = produto.PrecoVenda_produto;
                comando.Parameters.AddWithValue("@custo_produto", MySqlDbType.Double).Value = produto.Custo_produto;
                comando.Parameters.AddWithValue("@medida_produto", produto.Medida_produto);
                comando.Parameters.AddWithValue("@categoria_produto", produto.Categoria_produto);

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }

        //método para exlcuir dados
        public void Excluir(Produto produto)
        {
            try
            {
                AbrirConexao();

                comando = new MySqlCommand("DELETE FROM produto WHERE id_produto = @id_produto", conexao);
                comando.Parameters.AddWithValue("@id_produto", produto.Id_produto);
                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
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
