using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenLab.Infrastructure.ViewModels;
using OpenLab.Services.Services;

namespace OpenLab.Controllers
{
    public class CalcController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Process(CalcViewModel model)
        {
            if (model == null)
                return NotFound();

            CalcService cs = new CalcService();
            int res = cs.AddNumbers(model.Number1, model.Number2);
            model.Result = res;

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(CalcViewModel model)
        {
            CalcService cs = new CalcService();
            int result = cs.AddNumbers(model.Number1, model.Number2);
            model.Result = result;
            return View("Process", model);
        }

        [HttpPost]
        public IActionResult Subtract(CalcViewModel model)
        {
            CalcService cs = new CalcService();
            int result = cs.SubtractNumbers(model.Number1, model.Number2);
            model.Result = result;
            return View("Process", model);
        }

        [HttpPost]
        public IActionResult Multiply(CalcViewModel model)
        {
            CalcService cs = new CalcService();
            int result = cs.MultiplyNumbers(model.Number1, model.Number2);
            model.Result = result;
            return View("Process", model);
        }

        [HttpPost]
        public IActionResult Divide(CalcViewModel model)
        {
            CalcService cs = new CalcService();
            double result = cs.SafeDivide(model.Number1, model.Number2);
            model.Result = result;
            return View("Process", model);
        }
    }
}