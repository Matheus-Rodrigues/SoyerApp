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
    public partial class CadastroProduto : Form
    {
        public CadastroProduto()
        {
            InitializeComponent();

            Listar();
        }

        //método para limpar os campos preenchidos
        private void Limpar()
        {
           txbCod.Clear();
            txbDesc.Clear();
            txbQtd.Clear();
            mtbCusto.Clear();
            mtbPrec.Clear();
            cbCat.SelectedIndex = -1;
            cbMedida.SelectedIndex = -1;
        }

        //métodos para salvar dados da pessoa
        private void Salvar(Produto produto)
        {
            ProdutoBLL produtoBLL = new ProdutoBLL();

            if (txbDesc.Text.Trim() == string.Empty || txbQtd.Text.Trim() == string.Empty || mtbPrec.Text.Trim() == string.Empty || mtbCusto.Text.Trim() == string.Empty || cbCat.Text.Trim() == string.Empty || cbMedida.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Existem campos obrigatórios vazios", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbDesc.BackColor = Color.AliceBlue;
                txbQtd.BackColor = Color.AliceBlue;
                mtbPrec.BackColor = Color.AliceBlue;
                mtbCusto.BackColor = Color.AliceBlue;
                cbCat.BackColor = Color.AliceBlue;
                cbMedida.BackColor = Color.AliceBlue;
            }
            else
            {
                produto.Descricao_produto = txbDesc.Text;
                produto.Quantidade_produto = Convert.ToDouble(txbQtd.Text);
                produto.Medida_produto = cbMedida.Text;
                produto.Custo_produto = Convert.ToDouble(mtbCusto.Text);
                produto.PrecoVenda_produto = Convert.ToDouble(mtbPrec.Text);
                produto.Categoria_produto = cbCat.Text;

                produtoBLL.Salvar(produto);
                MessageBox.Show("Produto salvo com sucesso!");

                Limpar();
                Listar();
            }
        }

        //método para listar os dados de pessoas cadastradas
        private void Listar()
        {
            ProdutoBLL produtoBLL = new ProdutoBLL();

            dgDados.DataSource = produtoBLL.Listar();

            dgDados.Columns[0].HeaderText = "Código";
            dgDados.Columns[1].HeaderText = "Descrição";
            dgDados.Columns[2].HeaderText = "Quantidade";
            dgDados.Columns[3].HeaderText = "Medida";
            dgDados.Columns[4].HeaderText = "Custo";
            dgDados.Columns[5].HeaderText = "Preço";
            dgDados.Columns[6].HeaderText = "Categoria";

            dgDados.Columns[0].Width = 46;
            dgDados.Columns[1].Width = 145;
            dgDados.Columns[2].Width = 70;
            dgDados.Columns[3].Width = 85;
            dgDados.Columns[4].Width = 90;
            dgDados.Columns[5].Width = 89;
            dgDados.Columns[6].Width = 65;

        }

        //método para editar os dados
        private void Editar(Produto produto)
        {
            ProdutoBLL produtoBLL = new ProdutoBLL();

            if (txbDesc.Text.Trim() == string.Empty || txbQtd.Text.Trim() == string.Empty || mtbPrec.Text.Trim() == string.Empty || mtbCusto.Text.Trim() == string.Empty || cbCat.Text.Trim() == string.Empty || cbMedida.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Existem campos obrigatórios vazios", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbDesc.BackColor = Color.AliceBlue;
                txbQtd.BackColor = Color.AliceBlue;
                mtbPrec.BackColor = Color.AliceBlue;
                mtbCusto.BackColor = Color.AliceBlue;
                cbCat.BackColor = Color.AliceBlue;
                cbMedida.BackColor = Color.AliceBlue;
            }
            else
            {
                produto.Descricao_produto = txbDesc.Text;
                produto.Quantidade_produto = Convert.ToDouble(txbQtd.Text);
                produto.PrecoVenda_produto = Convert.ToDouble(mtbPrec.Text);
                produto.Custo_produto = Convert.ToDouble(mtbCusto.Text);
                produto.Medida_produto = cbMedida.Text;
                produto.Categoria_produto = cbCat.Text;

                produtoBLL.Salvar(produto);
                MessageBox.Show("Produto salvo com sucesso!");

                Limpar();
                Listar();
            }
        }

        //método para excluir os dados
        private void Excluir(Produto produto)
        {
            ProdutoBLL produtoBll = new ProdutoBLL();

            if (txbCod.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Selecione um produto para ser exlcuido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (MessageBox.Show("Deseja realmente exlcuir esse produto?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {

            }
            else
            {
                produto.Id_produto = Convert.ToInt32(txbCod.Text);
                produtoBll.Excluir(produto);

                MessageBox.Show("Dados excluidos com sucesso!");

                Limpar();
                Listar();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto();
            Salvar(produto);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto();
            Editar(produto);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto();
            Excluir(produto);
        }

        private void dgDados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txbCod.Text = dgDados.CurrentRow.Cells[0].Value.ToString();
            txbDesc.Text = dgDados.CurrentRow.Cells[1].Value.ToString();
            txbQtd.Text = dgDados.CurrentRow.Cells[2].Value.ToString();
            cbMedida.Text = dgDados.CurrentRow.Cells[3].Value.ToString();
            mtbCusto.Text = dgDados.CurrentRow.Cells[4].Value.ToString();
            mtbPrec.Text = dgDados.CurrentRow.Cells[5].Value.ToString();
            cbCat.Text = dgDados.CurrentRow.Cells[6].Value.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpar();
        }
    }
}
