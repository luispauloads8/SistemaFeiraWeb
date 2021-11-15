using ControleFeiraWeb.Data;
using ControleFeiraWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }

}
