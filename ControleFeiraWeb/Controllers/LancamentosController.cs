using ControleFeiraWeb.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFeiraWeb.Models;
using ControleFeiraWeb.Models.ViewModels;
using ControleFeiraWeb.Services.Exceptions;
using System.Diagnostics;

namespace ControleFeiraWeb.Controllers
{
    public class LancamentosController : Controller
    {
        private readonly FuncionarioService _funcionarioService;
        private readonly ProdutoService _produtoService;
        private readonly LancamentoService _lancamentoService;
        


        public LancamentosController(FuncionarioService funcionarioService, ProdutoService produtoService, LancamentoService lancamentoService) 
        {
            _funcionarioService = funcionarioService;
            _produtoService = produtoService;
            _lancamentoService = lancamentoService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _lancamentoService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var funcionarios = await _funcionarioService.FindAllAsync();
            var produtos = await _produtoService.FindAllAsync();
            var viewModel = new LancamentoFormViewModel { Funcionarios = funcionarios, Produtos = produtos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Lancamento lancamento)
        {
            if (!ModelState.IsValid)
            {
                var funcionarios = await _funcionarioService.FindAllAsync();
                var viewModel = new LancamentoFormViewModel { Funcionarios = funcionarios, Lancamento = lancamento };
                return View(viewModel);
            }

            await _lancamentoService.InsertAsync(lancamento);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não Fornecido" });
            }

            var obj = await _lancamentoService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não Existe" });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _lancamentoService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));

            } catch (IntegrityException e)
            {

                return RedirectToAction(nameof(Error), new { message = e.Message });
            }

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não Fornecido" });
            }

            var obj = await _lancamentoService.FindByIdAsync(id.Value);
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não Existe" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não Fornecido" });
            }

            var obj = await _lancamentoService.FindByIdAsync(id.Value);
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não Existe" });
            }

            var produtos = await _produtoService.FindAllAsync();
            var funcionarios = await _funcionarioService.FindAllAsync();
            LancamentoFormViewModel viewModel = new LancamentoFormViewModel{ Lancamento = obj, Produtos = produtos, Funcionarios = funcionarios };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Lancamento lancamento)
        {
            if (!ModelState.IsValid)
            {
                var produtos = await _produtoService.FindAllAsync();
                var funcionarios = await _funcionarioService.FindAllAsync();
                var viewModel = new LancamentoFormViewModel { Lancamento = lancamento, Produtos = produtos, Funcionarios = funcionarios };
                return View(viewModel);
            }

            if (id != lancamento.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id são diferentes" });
            }

            try
            {
                await _lancamentoService.UpdateAsync(lancamento);
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
