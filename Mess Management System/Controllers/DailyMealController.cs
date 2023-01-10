using Microsoft.AspNetCore.Mvc;
using Mess_Management_System.Services;
using Mess_Management_System.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mess_Management_System.Controllers
{
    public class DailyMealController : Controller
    {
        private DailyMealService _dailyMealService;
        private MemberListService _memberService;

        public DailyMealController(DailyMealService dailyMealService, MemberListService memberService)
        {
            _dailyMealService = dailyMealService;
            _memberService = memberService; 
        }

        public IActionResult Index(DateTime? fromDate, DateTime? toDate, int? MemberId)
        {
            ViewData["fromDate"] = fromDate;
            ViewData["toDate"] = toDate;

            ViewBag.memberlist = new SelectList(_memberService.GetDropDown(), "Value", "Text");

            var query = _dailyMealService.GetAll(fromDate, toDate, MemberId);
            return View(query);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.memberlist = new SelectList(_memberService.GetDropDown(), "Value", "Text");
            return View();
        }

        [HttpPost]
        public IActionResult Create(DailyMealViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _dailyMealService.Create(viewModel);
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

            var updateAttendance = _dailyMealService.GetById((int)id);

            if (updateAttendance == null)
            {
                return NotFound();
            }
            ViewBag.memberlist = new SelectList(_memberService.GetDropDown(), "Value", "Text");

            return View(updateAttendance);
        }

        [HttpPost]
        public IActionResult Update(DailyMealViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                _dailyMealService.Update(viewModel);
                return RedirectToAction("Index");
            }
            return View(viewModel) ;
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var deleteAttendance = _dailyMealService.GetById((int)id);

            if(deleteAttendance == null)
            {
                return NotFound();
            }

            return View(deleteAttendance);
        }

        [HttpPost]
        public IActionResult DeleteAll(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            _dailyMealService.Delete((int)id);

            return RedirectToAction("Index");
        }
    }
}
