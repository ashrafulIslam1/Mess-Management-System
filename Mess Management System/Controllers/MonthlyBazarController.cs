using Mess_Management_System.Services;
using Mess_Management_System.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mess_Management_System.Controllers
{
    public class MonthlyBazarController : Controller
    {
        private MemberListService _memberService;
        private MonthlyBazarService _monthlyBazarService;
        public MonthlyBazarController(MonthlyBazarService monthlyBazarService, MemberListService memberListService)
        {
            _memberService = memberListService;
            _monthlyBazarService = monthlyBazarService;
        }
        public IActionResult Index(string? searchString, DateTime? monthYear)
        {
            int? _month = monthYear == null ? null : monthYear.Value.Month;
            int? _year = monthYear == null ? null : monthYear.Value.Year;

            ViewBag.memberlist = new SelectList(_memberService.GetDropDown(), "Value", "Text");
            var query = _monthlyBazarService.GetAll(searchString, _month, _year);
            
            return View(query);
        }

        [HttpGet]
        public IActionResult Generate()
        {
            ViewBag.memberlist = new SelectList(_memberService.GetDropDown(), "Value", "Text");
            return View();
        }


        [HttpPost]
        public IActionResult Generate(MonthlyBazarViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _monthlyBazarService.Generate(vm);

                return RedirectToAction("Index");
            }
            return View(vm);
        }

    }
}
