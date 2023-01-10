﻿using Mess_Management_System.Services;
using Mess_Management_System.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mess_Management_System.Controllers
{
    public class MonthlyBazarSetupController : Controller
    {
        private MonthlyBazarSetupService _monthlyBazarSetupService;
        public MonthlyBazarSetupController(MonthlyBazarSetupService monthlyBazarSetupService)
        {
            _monthlyBazarSetupService = monthlyBazarSetupService;
        }
        public IActionResult Index()
        {
            var query = _monthlyBazarSetupService.GetAll();
            
            return View(query);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MonthlyBazarSetupViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _monthlyBazarSetupService.Create(viewModel);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var updateBazarSetup = _monthlyBazarSetupService.GetById((int)id);

            if (updateBazarSetup == null)
            {
                return NotFound();
            }

            return View(updateBazarSetup);
        }

        [HttpPost]
        public IActionResult Update(MonthlyBazarSetupViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _monthlyBazarSetupService.Update(viewModel);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

    }
}
