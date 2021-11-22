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
    public class ProdutoService
    {
        private ControleFeiraWebContext _context;

        public ProdutoService(ControleFeiraWebContext context)
        {
            _context = context;
        }

        public List<Produto> FindAll()
        {
            return _context.Produto.OrderBy(x => x.Descricao).ToList();
        }

        public void Insert(Produto obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            try
            {
                var obj = _context.Produto.Find(id);
                _context.Remove(obj);
                _context.SaveChanges();

            } catch (DbUpdateException)
            {

                throw new IntegrityException("Não e permitido excluir o Produto poís existe Lançamentos!");
            }
        }

        public Produto FindById(int id)
        {
            return _context.Produto.FirstOrDefault(obj => obj.Id == id);
        }

     
        public void Update(Produto obj)
        {
            bool hasAny = _context.Produto.Any(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id não existe");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();

            } catch (DbUpdateConcurrencyException e)
            {

                throw new DbConcurrencyException(e.Message);
            }
      
        }
    }
}
