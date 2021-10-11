using ControleFeiraWeb.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFeiraWeb.Models
{
    public class Lancamento
    {
        public int Id { get; set; }
        public double ValorLancamento { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLancamento { get; set; }
        public MovimentacaoStatus Status { get; set; }
        public Funcionario Funcionario { get; set; }
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();

        public Lancamento()
        {
        }

        public Lancamento(int id, double valorLancamento, string descricao, DateTime dataLancamento, MovimentacaoStatus status, Funcionario funcionario)
        {
            Id = id;
            ValorLancamento = valorLancamento;
            Descricao = descricao;
            DataLancamento = dataLancamento;
            Status = status;
            Funcionario = funcionario;
        }

        public void AddProduto(Produto p)
        {
            Produtos.Add(p);
        }

        public void RemoveProduto(Produto p)
        {
            Produtos.Remove(p);
        }
    }
}
