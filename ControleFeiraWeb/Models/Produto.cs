using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFeiraWeb.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();

        public Produto()
        {
        }

        public Produto(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
