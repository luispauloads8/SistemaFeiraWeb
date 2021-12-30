using ControleFeiraWeb.Data;
using ControleFeiraWeb.Models;
using ControleFeiraWeb.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Lancamento>> FindAllAsync()
        {
            return await _context.Lancamento.OrderBy(x => x.Descricao).ToListAsync();
        }

        public async Task InsertAsync(Lancamento obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Lancamento> FindByIdAsync(int id)
        {
            return await _context.Lancamento.Include(obj => obj.Funcionario).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Lancamento.FindAsync(id);
                _context.Lancamento.Remove(obj);
                await _context.SaveChangesAsync();

            } catch (DbUpdateException)
            {

                throw new IntegrityException("Não é permitido excluir o lançamento pois existe movimentação!");
            }
        }

        public async Task UpdateAsync(Lancamento obj)
        {
            bool hasAny = await _context.Lancamento.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id não existe");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();

            } catch (DbUpdateConcurrencyException e)
            {

                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
