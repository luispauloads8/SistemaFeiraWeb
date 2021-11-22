using ControleFeiraWeb.Data;
using ControleFeiraWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFeiraWeb.Services
{
    public class LancamentoService
    {

        private ControleFeiraWebContext _context;

        public LancamentoService(ControleFeiraWebContext context)
        {
            _context = context;
        }

        public List<Lancamento> FindAll()
        {
            return _context.Lancamento.OrderBy(x => x.Descricao).ToList();
        }
    }
}
