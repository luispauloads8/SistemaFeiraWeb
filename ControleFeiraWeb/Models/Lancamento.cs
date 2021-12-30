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
        [Display(Name = "Valor Lancamento")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Required(ErrorMessage = "{0} Obrigatorio!")]
        public double ValorLancamento { get; set; }
        [Required(ErrorMessage = "{0} Obrigatorio!")]
        public string Descricao { get; set; }

        [Display(Name = "Data Lancamento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "{0} Obrigatorio!")]
        public DateTime DataLancamento { get; set; }

        public MovimentacaoStatus Status { get; set; }
        public Funcionario Funcionario { get; set; }
        public Produto Produto{ get; set; }

        [Display(Name = "Produtos")]
        public int ProdutoId { get; set; }
        [Display(Name = "Funcionarios")]
        public int FuncionarioId { get; set; }

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
