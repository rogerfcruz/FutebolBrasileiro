using Futebol.Models;
using Futebol.Models.ViewModels;
using Futebol.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace Futebol.Controllers
{
    public class TimeController : Controller
    {
        private readonly TimeService _timeService;

        public TimeController(TimeService timeService)
        {
            _timeService = timeService;
        }

        public IActionResult Index()
        {
            var times = _timeService.FindAll();
            return View(times);
        }

        public IActionResult Create()
        {
            var viewModel = new TimeFormViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TimeModel time)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new TimeFormViewModel();
                return View(viewModel);
            }
            _timeService.Insert(time);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido!" });
            }
            
            var time = _timeService.FindById(id.Value);
            if (time == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado!" });
            }

            return View(time);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TimeModel time)
        {
            if (!ModelState.IsValid)
            {
                var times = _timeService.FindAll();
                return View(times);
            }

            if (id != time.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id incompatível!" });
            }

            try
            {
                _timeService.Update(time);
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
            
            var obj = _timeService.FindById(id.Value);
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
                _timeService.Remove(id);
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