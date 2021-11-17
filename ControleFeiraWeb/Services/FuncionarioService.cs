using ControleFeiraWeb.Data;
using ControleFeiraWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
        public List<Funcionario> FindAll()
        {
            return _context.Funcionario.ToList();
        }

        public void Insert(Funcionario obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Funcionario FindById(int id)
        {
            return _context.Funcionario.Include(obj =>obj.Departamento).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Funcionario.Find(id);
            _context.Funcionario.Remove(obj);
            _context.SaveChanges();
        }
    }

}
