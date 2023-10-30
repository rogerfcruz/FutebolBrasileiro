using Futebol.Models;
using Futebol.Models.ViewModels;
using Futebol.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace Futebol.Controllers
{
    public class CampeonatoController : Controller
    {
        private readonly CampeonatoService _campeonatoService;

        public CampeonatoController(CampeonatoService campeonatoService)
        {
            _campeonatoService = campeonatoService;
        }

        public IActionResult Index()
        {
            var campeonatos = _campeonatoService.FindAll();
            return View(campeonatos);
        } 
       
        public IActionResult Create()
        {
            var viewModel = new CampeonatoFormViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CampeonatoModel campeonato)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CampeonatoFormViewModel();
                return View(viewModel);
            }
            _campeonatoService.Insert(campeonato);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido!" });
            }
            
            var campeonato = _campeonatoService.FindById(id.Value);
            if (campeonato == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            return View(campeonato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CampeonatoModel campeonato)
        {
            if (!ModelState.IsValid)
            {
                var campeonatos = _campeonatoService.FindAll();
                return View(campeonatos);
            }

            if (id != campeonato.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id incompatível!" });
            }

            try
            {
                _campeonatoService.Update(campeonato);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido!" });
            }
            
            var obj = _campeonatoService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            try
            {
                _campeonatoService.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel { Message = message, RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
            return View(viewModel);
        }
    }
}