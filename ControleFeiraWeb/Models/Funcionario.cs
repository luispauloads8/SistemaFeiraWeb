using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFeiraWeb.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###-##-####}")]
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Email { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime Data_Nascimento { get; set; }
        public string Telefone_Celular { get; set; }
        public string Endereco { get; set; }
        public string Profissao { get; set; }
        public ICollection<Lancamento> Lancamentos { get; set; } = new List<Lancamento>();
        public Departamento Departamento { get; set; }

        public Funcionario()
        {
        }

        public Funcionario(int id, string nome, string cPF, string rG, string email, DateTime data_Nascimento, string telefone_Celular, string endereco, string profissao, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            CPF = cPF;
            RG = rG;
            Email = email;
            Data_Nascimento = data_Nascimento;
            Telefone_Celular = telefone_Celular;
            Endereco = endereco;
            Profissao = profissao;
            Departamento = departamento;
        }

        public void AddLancamentos(Lancamento l)
        {
            Lancamentos.Add(l);
        }

        public void RemoveLancamento(Lancamento l)
        {
            Lancamentos.Remove(l);
        }

        public double TotalLancamento(DateTime inicial, DateTime final)
        {
            return Lancamentos.Where(l => l.DataLancamento >= inicial && l.DataLancamento <= final).Sum(l => l.ValorLancamento);
        }
     
    }

}
