using ControleFeiraWeb.Data;
using ControleFeiraWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControleFeiraWeb.Services.Exceptions;

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

        public void Remove(int id)
        {
            try
            {
                var obj = _context.Departamento.Find(id);
                _context.Remove(obj);
                _context.SaveChanges();

            } catch (DbUpdateException)
            {

                throw new IntegrityException("Não e permitido excluir o Departamento poís existe Funcionario!");
            }
        }
    }
}
