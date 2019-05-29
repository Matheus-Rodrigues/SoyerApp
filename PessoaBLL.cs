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
    public class PessoaBLL
    {
        PessoaDAO pessoaDAO = new PessoaDAO();

        //método para salvar os dados no banco de dados
        public void Salvar(Pessoa pessoa)
        {
            try
            {
                pessoaDAO.Salvar(pessoa);
            }
            catch(Exception erro)
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
                dt = pessoaDAO.Listar();

                return dt;
            }
            catch(Exception erro)
            {
                throw erro;
            }
        }

        //método para editar os dados
        public void Editar(Pessoa pessoa)
        {
            try
            {
                pessoaDAO.Editar(pessoa);
            }
            catch(Exception erro)
            {
                throw erro;
            }
        }

        //método para excluir dados
        public void Excluir(Pessoa pessoa)
        {
            try
            {
                pessoaDAO.Excluir(pessoa);
            }
            catch(Exception erro)
            {
                throw erro;
            }
        }
    }
}
