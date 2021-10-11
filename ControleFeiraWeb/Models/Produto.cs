using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFeiraWeb.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Descrição { get; set; }
        public Funcionario Funcionario { get; set; }

        public Produto()
        {
        }

        public Produto(int id, string descrição, Funcionario funcionario)
        {
            Id = id;
            Descrição = descrição;
            Funcionario = funcionario;
        }
    }
}
