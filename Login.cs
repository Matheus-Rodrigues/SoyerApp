using SoyerApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace SoyerApp.Apresentação
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        MySqlConnection conexao1 = new MySqlConnection(Properties.Settings.Default.conexao);
        string usuario, senha;

        private void Logar()
        {
            string login = "SELECT usuario, senha FROM login WHERE usuario = '" + txbLogin.Text + "' AND senha = '" + txbSenha.Text + "'";
            MySqlCommand comando = new MySqlCommand(login, conexao1);
            comando.CommandType = CommandType.Text;
            MySqlDataReader reader;

            try
            {
                conexao1.Open();
                reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    usuario = reader[0].ToString();
                    senha = reader[1].ToString();
                    
                    if (usuario == txbLogin.Text && senha == txbSenha.Text)
                    {
                        Principal principal = new Principal();
                        principal.Show();
                    }
                    else

                        MessageBox.Show("Usuário ou senha inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Usuário ou senha inválidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao validar usuário" + ex);
            }
            conexao1.Close();
        }
        


        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Logar();
        }
    }
}
