using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoyerApp.BLL;
using SoyerApp.Model;
using SoyerApp.DAO;

namespace SoyerApp.Apresentação
{
    public partial class Funcionarios : Form
    {
        public Funcionarios()
        {
            InitializeComponent();

            PessoaBLL pessoa = new PessoaBLL();

            Listar();
        }

        private void Listar()
        {
            PessoaBLL pessoaBLL = new PessoaBLL();

            dgDados.DataSource = pessoaBLL.Listar();

            dgDados.Columns[0].HeaderText = "Código";
            dgDados.Columns[1].HeaderText = "Nome";
            dgDados.Columns[2].HeaderText = "Sexo";
            dgDados.Columns[3].HeaderText = "Telefone";
            dgDados.Columns[4].HeaderText = "Endereço";
            dgDados.Columns[5].HeaderText = "Bairro";
            dgDados.Columns[6].HeaderText = "Cidade";
            dgDados.Columns[7].HeaderText = "Estado";

            dgDados.Columns[0].Width = 90;
            dgDados.Columns[1].Width = 160;
            dgDados.Columns[2].Width = 25;
            dgDados.Columns[3].Width = 93;
            dgDados.Columns[4].Width = 130;
            dgDados.Columns[5].Width = 105;
            dgDados.Columns[6].Width = 80;
            dgDados.Columns[7].Width = 50;

        }

        private void Excluir(Pessoa pessoa)
        {
            PessoaBLL pessoaBll = new PessoaBLL();

            if (txbID.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Selecione uma pessoa para ser exlcuida", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (MessageBox.Show("Deseja realmente exlcuir esse usuário?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {

            }
            else
            {
                pessoa.Id = Convert.ToInt32(txbID.Text);
                pessoaBll.Excluir(pessoa);

                MessageBox.Show("Dados excluidos com sucesso!");

                pessoaBll.Listar();
                dgDados.DataSource = pessoaBll.Listar();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();

            Excluir(pessoa);
        }

        private void dgDados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txbID.Text = dgDados.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
