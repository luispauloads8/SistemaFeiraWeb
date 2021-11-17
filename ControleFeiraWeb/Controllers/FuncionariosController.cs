using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleFeiraWeb.Data;
using ControleFeiraWeb.Models;
using ControleFeiraWeb.Services;
using ControleFeiraWeb.Models.ViewModels;
using ControleFeiraWeb.Services.Exceptions;
using System.Diagnostics;

namespace ControleFeiraWeb.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly FuncionarioService _funcionarioService;
        private readonly DepartamentoService _departamentoService;

        public FuncionariosController(FuncionarioService funcionarioService, DepartamentoService departamentoService)
        {
            _funcionarioService = funcionarioService;
            _departamentoService = departamentoService;
        }

        public IActionResult Index()
        {
            var list = _funcionarioService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departamentos = _departamentoService.FindAll();
            var viewModel = new FuncionarioFormViewModel { Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Funcionario funcionario)
        {
            _funcionarioService.Insert(funcionario);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não Fornecido" });
            }

            var obj = _funcionarioService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não Existe" });
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _funcionarioService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não Fornecido" });
            }

            var obj = _funcionarioService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não Existe" });
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não Fornecido" });
            }

            var obj = _funcionarioService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não Existe" });
            }

            List<Departamento> departamentos = _departamentoService.FindAll();
            FuncionarioFormViewModel ViewModel = new FuncionarioFormViewModel { Funcionario = obj, Departamentos = departamentos };
            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Funcionario funcionario)
        {
            if (id != funcionario.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id são diferentes" });
            }
            try
            {
                _funcionarioService.Update(funcionario);
                return RedirectToAction(nameof(Index));
            } catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                //obter id interno da requisição
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
