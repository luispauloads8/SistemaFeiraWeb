using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFeiraWeb.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();

        public Departamento()
        {
        }

        public Departamento(int id, string nome, Funcionario funcionario)
        {
            Id = id;
            Nome = nome;
        }

        public void AddFuncionario(Funcionario f)
        {
            Funcionarios.Add(f);
        }

        public void RemoveFuncionario(Funcionario f)
        {
            Funcionarios.Remove(f);
        }

        public double TotalFuncionario(DateTime inicial, DateTime final)
        {
            return Funcionarios.Sum(funcionario => funcionario.TotalLancamento(inicial, final));
        }

    }
}
