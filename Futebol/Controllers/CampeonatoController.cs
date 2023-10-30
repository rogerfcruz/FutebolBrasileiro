using Futebol.Models;
using Futebol.Models.ViewModels;
using Futebol.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var lista = _campeonatoService.FindAll();
            return View(lista);
        }
        
        public IActionResult Details(int id)
        {
            return View();
        }
        
        public IActionResult Create()
        {
            var campeonatos = _campeonatoService.FindAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CampeonatoModel campeonato)
        {
            _campeonatoService.Insert(campeonato);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            var campeonato = _campeonatoService.FindById(id.Value);
            return View(campeonato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CampeonatoModel campeonato)
        {
            _campeonatoService.Update(campeonato);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            var obj = _campeonatoService.FindById(id.Value);
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _campeonatoService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}