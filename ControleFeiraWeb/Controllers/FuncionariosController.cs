using ControleFeiraWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFeiraWeb.Controllers
{
    public class FuncionariosController : Controller
    {
        public IActionResult Index()
        {
            List<Funcionario> list = new List<Funcionario>();
            list.Add(new Funcionario { Id = 1, Nome = "Luis Paulo", CPF = "024.345.191-13", RG = "5063003", 
                Email = "luispaulo.ads8@gmail.com", Data_Nascimento = DateTime.Parse("1988,07,07"), Endereco = "Rua Nova", Telefone_Celular = "(62) 9 8561-3331", Profissao = "Analista de Dados"});

        
            return View(list);
        }
    }
}
