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
    public class FuncionarioService
    {
        private readonly ControleFeiraWebContext _context;

        public FuncionarioService(ControleFeiraWebContext context)
        {
            _context = context;
        }

        //lista com todos vendedores
        public async Task<List<Funcionario>> FindAllAsync()
        {
            return await _context.Funcionario.ToListAsync();
        }

        public async Task InsertAsync(Funcionario obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Funcionario> FindByIdAsync(int id)
        {
            return await _context.Funcionario.Include(obj => obj.Departamento).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Funcionario.FindAsync(id);
                _context.Funcionario.Remove(obj);
                await _context.SaveChangesAsync();

            } catch (DbUpdateException)
            {
                throw new IntegrityException("Não é permitido excluir o Funciónario poís existe Lançamentos!");
            }
           
        }

        public async Task UpdateAsync(Funcionario obj)
        {
            bool hasAny = await _context.Funcionario.AnyAsync(x => x.Id == obj.Id);
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
