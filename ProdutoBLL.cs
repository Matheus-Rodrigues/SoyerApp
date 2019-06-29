using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoyerApp.Model;
using SoyerApp.DAO;
using System.Data;

namespace SoyerApp.BLL
{
    class ProdutoBLL
    {
        ProdutoDAO produtoDAO = new ProdutoDAO();

        //método para salvar os dados no banco de dados
        public void Salvar(Produto produto)
        {
            try
            {
                produtoDAO.Salvar(produto);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //método para listar os dados
        public DataTable Listar()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = produtoDAO.Listar();

                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //método para editar os dados
        public void Editar(Produto produto)
        {
            try
            {
                produtoDAO.Editar(produto);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //método para excluir dados
        public void Excluir(Produto produto)
        {
            try
            {
                produtoDAO.Excluir(produto);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
