using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFeiraWeb.Models.ViewModels
{
    public class ProdutoFormViewModel
    {
        public Produto Produto { get; set; }

        public ICollection<Lancamento> Lancamentos { get; set; }
    }
}
