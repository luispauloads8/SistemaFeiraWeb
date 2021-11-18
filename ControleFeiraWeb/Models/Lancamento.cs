using ControleFeiraWeb.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFeiraWeb.Models
{
    public class Lancamento
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double ValorLancamento { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLancamento { get; set; }
        public MovimentacaoStatus Status { get; set; }
        public Funcionario Funcionario { get; set; }
        public Produto Produto{ get; set; }

        public Lancamento()
        {
        }

        public Lancamento(int id, double valorLancamento, string descricao, DateTime dataLancamento, MovimentacaoStatus status, Funcionario funcionario, Produto produto)
        {
            Id = id;
            ValorLancamento = valorLancamento;
            Descricao = descricao;
            DataLancamento = dataLancamento;
            Status = status;
            Funcionario = funcionario;
            Produto = produto;
        }

    }
}
