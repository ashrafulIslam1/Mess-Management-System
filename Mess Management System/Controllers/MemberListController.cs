using Microsoft.AspNetCore.Mvc;
using Mess_Management_System.Services;
using Mess_Management_System.ViewModels;

namespace Mess_Management_System.Controllers
{
    public class MemberListController : Controller
    {
        private MemberListService _memberListService;

        public MemberListController(MemberListService memberListService)
        {
            _memberListService = memberListService;
        }

        public IActionResult Index(string searchString)
        {
            var query = _memberListService.GetAll(searchString);

            return View(query);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MemberListViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                _memberListService.Create(viewModel);
                TempData["allertMessage"] = "Member created successfully !";
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if(id == 0 || id == null)
            {
                return NotFound();
            }
            var updateViewModel = _memberListService.GetById((int)id);

            if(updateViewModel == null)
            {
                return NotFound();
            }

            return View(updateViewModel);
        }

        [HttpPost]
        public IActionResult Update(MemberListViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                _memberListService.Update(viewModel);
                TempData["allertMessage"] = "Member updated successfully !";
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if(id==0 || id == null)
            {
                return NotFound();
            }
            var deleteViewModel = _memberListService.GetById((int)id);

            if(deleteViewModel == null)
            {
                return NotFound();
            }
            return View(deleteViewModel);
        }

        [HttpPost]
        public IActionResult DeleteAll(int? id)
        {
            if(id == 0 || id == null)
            {
                return NotFound();
            }
            _memberListService.Delete((int)id);
            TempData["allertMessage"] = "Member deleted successfully !";
            return RedirectToAction("Index");
        }
    }
}
