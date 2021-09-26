using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFeiraWeb.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Email { get; set; }
        public DateTime Data_Nascimento { get; set; }
        public string Telefone_Celular { get; set; }
        public string Endereco { get; set; }
        public string Profissao { get; set; }


    }
}
