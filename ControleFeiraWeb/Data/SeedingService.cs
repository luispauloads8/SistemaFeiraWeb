using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFeiraWeb.Models;
using ControleFeiraWeb.Models.Enums;


namespace ControleFeiraWeb.Data
{
    //injeção de dependencia
    public class SeedingService
    {
        private ControleFeiraWebContext _context;

        public SeedingService(ControleFeiraWebContext context)
        {
            _context = context;
        }
        //metodo para popular o banco de dados
        public void Seed()
        {
            if (_context.Departamento.Any()  || _context.Funcionario.Any() 
                || _context.Lancamento.Any() || _context.Produto.Any())
            {
                return; //DB ja foi populado!
            }


            Departamento d1 = new Departamento(1, "Serviço");
            Departamento d2 = new Departamento(2, "Administrativo");
            Departamento d3 = new Departamento(3, "Recurso Humano");

            Produto p1 = new Produto(1, "Carne");
            Produto p2 = new Produto(2, "Tomate");
            Produto p3 = new Produto(3, "Copo");

            Funcionario f1 = new Funcionario(1, "Divina", "577.491.911-00", "1475247", "divinamaria.castro.10@gmail.com", new DateTime(1967, 10, 29), "(62) 9 8557-1820", "Rua Centro", "Diretora", d1);
            Funcionario f2 = new Funcionario(2, "Maria Eterna", "578.548.124-87", "14785212", "Eterna@gmail.com", new DateTime(1971, 5, 15), "(62) 9 8225-7463", "Rua Centro", "Diretora", d2);
            Funcionario f3 = new Funcionario(3, "Vinycius", "748.854.789-87", "14587485", "Vinycius@gmail.com", new DateTime(2004, 9, 17), "(62) 9 9474-8577", "Rua Centro", "Fazedor de Suco", d3);

            
            Lancamento l1 = new Lancamento(1, 10, "entrada", new DateTime(2021, 11, 05), MovimentacaoStatus.entrada, f1, p1);
            Lancamento l2 = new Lancamento(2, 10, "entrada", new DateTime(2021, 11, 06), MovimentacaoStatus.entrada, f2, p2);
            Lancamento l3 = new Lancamento(3, 10, "entrada", new DateTime(2021, 11, 07), MovimentacaoStatus.entrada, f3, p3);

            _context.Departamento.AddRange(d1, d2, d3);

            _context.Produto.AddRange(p1, p2, p3);

            _context.Funcionario.AddRange(f1, f2, f3);

            _context.Lancamento.AddRange(l1, l2, l3);

            _context.SaveChanges();

        }
    }
}
