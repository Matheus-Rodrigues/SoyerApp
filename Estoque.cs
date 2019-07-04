using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoyerApp.DAO;
using SoyerApp.BLL;
using SoyerApp.Model;

namespace SoyerApp.Apresentação
{
    public partial class Estoque : Form
    {
        public Estoque()
        {
            InitializeComponent();

            ProdutoBLL produto = new ProdutoBLL();

            Listar();
        }

        private void Listar()
        {
            ProdutoBLL produtoBLL = new ProdutoBLL();

            dgDados.DataSource = produtoBLL.Listar();

            dgDados.Columns[0].HeaderText = "Código";
            dgDados.Columns[1].HeaderText = "Descrição";
            dgDados.Columns[2].HeaderText = "Quantidade";
            dgDados.Columns[3].HeaderText = "Preço";
            dgDados.Columns[4].HeaderText = "Custo";
            dgDados.Columns[5].HeaderText = "Medida";
            dgDados.Columns[6].HeaderText = "Categoria";

            dgDados.Columns[0].Width = 90;
            dgDados.Columns[1].Width = 160;
            dgDados.Columns[2].Width = 100;
            dgDados.Columns[3].Width = 93;
            dgDados.Columns[4].Width = 100;
            dgDados.Columns[5].Width = 100;
            dgDados.Columns[6].Width = 90;

        }

        private void Excluir(Produto produto)
        {
            ProdutoBLL produtoBll = new ProdutoBLL();

            if (txbID.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Selecione um produto para ser exlcuido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (MessageBox.Show("Deseja realmente exlcuir esse produto?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {

            }
            else
            {
                produto.Id_produto = Convert.ToInt32(txbID.Text);
                produtoBll.Excluir(produto);

                MessageBox.Show("Dados excluidos com sucesso!");

                produtoBll.Listar();
                dgDados.DataSource = produtoBll.Listar();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto();

            Excluir(produto);

        }

        private void dgDados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txbID.Text = dgDados.CurrentRow.Cells[0].Value.ToString();
        }
    }


}
