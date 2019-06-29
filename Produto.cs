using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoyerApp.Model
{
    public class Produto
    {
        public int Id_produto { get; set; }

        public string Descricao_produto { get; set; }

        public double Quantidade_produto { get; set; }

        public double PrecoVenda_produto { get; set; }

        public double Custo_produto { get; set; }

        public string Medida_produto { get; set; }

        public string Categoria_produto { get; set; }
    }
}
