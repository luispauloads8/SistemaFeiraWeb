using ControleFeiraWeb.Data;
using ControleFeiraWeb.Models;
using ControleFeiraWeb.Models.ViewModels;
using ControleFeiraWeb.Services;
using ControleFeiraWeb.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ControleFeiraWeb.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ProdutoService _produtoService;
        private readonly ControleFeiraWebContext _context;

        public ProdutosController(ProdutoService produtoService,  ControleFeiraWebContext context)
        {
            _produtoService = produtoService;
            _context = context;
        }

        public IActionResult Index()
        {
            var list = _produtoService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Produto produto)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new ProdutoFormViewModel { Produto = produto };
                return View(viewModel);
            }
            _produtoService.Insert(produto);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index), new { Message = "Id Não Encontrado" });
            }
            var obj = _produtoService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Index), new { Message = "Id não Existe" });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            try
            {
                _produtoService.Remove(id);
                return RedirectToAction(nameof(Index));

            } catch (IntegrityException e)
            {

                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não Fornecido" });
            }

            var obj = _produtoService.FindById(id.Value);
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

            var obj = _produtoService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não Existe" });
            }

            ProdutoFormViewModel ViewModel = new ProdutoFormViewModel { Produto = obj };
            return View(ViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Produto produto)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ProdutoFormViewModel { Produto = produto };
                return View(viewModel);
            }

            if (id != produto.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "id são diferentes!" });
            }

            try
            {
                _produtoService.Update(produto);
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
