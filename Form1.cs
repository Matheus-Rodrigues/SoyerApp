using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoyerApp.Model;
using SoyerApp.BLL;

namespace SoyerApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedDialog;

            Listar();
        }

        //método para limpar os campos preenchidos
        private void Limpar()
        {
            txt_cod.Clear();
            txt_nome.Clear();
            mtb_contato.Clear();
            cb_sexo.SelectedIndex = -1;
            txt_endereco.Clear();
            txt_cidade.Clear();
            txt_bairro.Clear();
            cb_estado.SelectedIndex = -1;
        }

        //métodos para salvar dados da pessoa
        private void Salvar(Pessoa pessoa)
        {
            PessoaBLL pessoaBLL = new PessoaBLL();

            pessoa.Nome = txt_nome.Text;
            pessoa.Sexo = cb_sexo.Text;
            pessoa.Contato = mtb_contato.Text;
            pessoa.Endereco = txt_endereco.Text;
            pessoa.Bairro = txt_bairro.Text;
            pessoa.Cidade = txt_cidade.Text;
            pessoa.Estado = cb_estado.Text;

            pessoaBLL.Salvar(pessoa);
            MessageBox.Show("Dados salvos com sucesso!");

            Limpar();
            Listar();
        }

        //método para listar os dados de pessoas cadastradas
        private void Listar()
        {
            PessoaBLL pessoaBLL = new PessoaBLL();

            dg_dados.DataSource = pessoaBLL.Listar();
        }

        //método para editar os dados
        private void Editar(Pessoa pessoa)
        {
            PessoaBLL pessoaBll = new PessoaBLL();

            pessoa.Id = Convert.ToInt32(txt_cod.Text);
            pessoa.Nome = txt_nome.Text;
            pessoa.Sexo = cb_sexo.Text;
            pessoa.Contato = mtb_contato.Text;
            pessoa.Endereco = txt_endereco.Text;
            pessoa.Bairro = txt_bairro.Text;
            pessoa.Cidade = txt_cidade.Text;
            pessoa.Estado = cb_estado.Text;

            pessoaBll.Editar(pessoa);

            MessageBox.Show("Dados editados com sucesso!");

            Limpar();
            Listar();
        }

        //método para excluir os dados
        private void Excluir(Pessoa pessoa)
        {
            PessoaBLL pessoaBll = new PessoaBLL();

            pessoa.Id = Convert.ToInt32(txt_cod.Text);
            pessoaBll.Excluir(pessoa);

            MessageBox.Show("Dados excluidos com sucesso!");

            Limpar();
            Listar();
        }

        private void dg_dados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_cod.Text = dg_dados.CurrentRow.Cells[0].Value.ToString();
            txt_nome.Text = dg_dados.CurrentRow.Cells[1].Value.ToString();
            cb_sexo.Text = dg_dados.CurrentRow.Cells[2].Value.ToString();
            mtb_contato.Text = dg_dados.CurrentRow.Cells[3].Value.ToString();
            txt_endereco.Text = dg_dados.CurrentRow.Cells[4].Value.ToString();
            txt_bairro.Text = dg_dados.CurrentRow.Cells[5].Value.ToString();
            txt_cidade.Text = dg_dados.CurrentRow.Cells[6].Value.ToString();
            cb_estado.Text = dg_dados.CurrentRow.Cells[7].Value.ToString();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();
            Salvar(pessoa);
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();
            Editar(pessoa);
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();

            Excluir(pessoa);
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Limpar();
        }
    }
} 
