using ControleFeiraWeb.Data;
using ControleFeiraWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace ControleFeiraWeb.Services
{
    public class DepartamentoService
    {
        private readonly ControleFeiraWebContext _context;

        public DepartamentoService(ControleFeiraWebContext context)
        {
            _context = context;
        }

        public async Task<List<Departamento>> FindAllAsync()
        {
            return await _context.Departamento.OrderBy(x => x.Nome).ToListAsync();
        }
    }
}
