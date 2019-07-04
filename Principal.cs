using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoyerApp.Apresentação
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void btnCadProd_Click(object sender, EventArgs e)
        {
            CadastroProduto cadProd = new CadastroProduto();

            cadProd.Show();
        }

        private void btnCadPess_Click(object sender, EventArgs e)
        {
            CadastroPessoa cadPess = new CadastroPessoa();

            cadPess.Show();
        }

        private void btnVerEstq_Click(object sender, EventArgs e)
        {
            Estoque estoque = new Estoque();

            estoque.Show();
        }

        private void btnControle_Click(object sender, EventArgs e)
        {
            Funcionarios funcionarios = new Funcionarios();

            funcionarios.Show();
        }
    }
}
