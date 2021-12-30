using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ControleFeiraWeb.Models.ViewModels
{
    public class LancamentoFormViewModel
    {
        public Lancamento Lancamento { get; set; }

        public ICollection<Produto> Produtos { get; set; }
        public ICollection<Funcionario> Funcionarios { get; set; }
    }
}
