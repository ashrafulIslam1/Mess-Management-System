using Microsoft.AspNetCore.Mvc;
using Mess_Management_System.Services;
using Mess_Management_System.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mess_Management_System.Controllers
{
    public class BazarController : Controller
    {
        private readonly BazarService _bazarService;
        private MemberListService _memberService;
        public BazarController(BazarService bazarService, MemberListService memberService)
        {
            _bazarService = bazarService;
            _memberService = memberService;
        }

        public IActionResult Index(int? MemberId, DateTime? fromDate, DateTime? toDate)
        {
            ViewData["fromDate"] = fromDate;
            ViewData["toDate"] = toDate;

            ViewBag.memberlist = new SelectList(_memberService.GetDropDown(), "Value", "Text");

            var query = _bazarService.GetAll(MemberId, fromDate, toDate);

            return View(query);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.memberlist = new SelectList(_memberService.GetDropDown(), "Value", "Text");
            return View();
        }

        [HttpPost]
        public IActionResult Create(BazarViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _bazarService.Create(viewModel);
                TempData["allertMessage"] = "Bazar created successfully !";
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var updateViewModel = _bazarService.GetById(id);

            if (updateViewModel == null)
                return NotFound();

            ViewBag.memberlist = new SelectList(_memberService.GetDropDown(), "Value", "Text");

            return View(updateViewModel);
        }

        [HttpPost]
        public IActionResult Update(BazarViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _bazarService.Update(viewModel);
                TempData["allertMessage"] = "Bazar updated successfully !";
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            var deleteViewModel = _bazarService.GetById(id);

            if (deleteViewModel == null)
                return NotFound();

            return View(deleteViewModel);
        }

        [HttpPost]
        public IActionResult DeleteAll(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            _bazarService.Delete((int)id);

            return RedirectToAction("Index") ;
        }
    }
}
