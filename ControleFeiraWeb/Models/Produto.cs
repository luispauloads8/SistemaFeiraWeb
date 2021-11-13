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
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();

        public Produto()
        {
        }

        public Produto(int id, string descrição)
        {
            Id = id;
            Descrição = descrição;
        }
    }
}
