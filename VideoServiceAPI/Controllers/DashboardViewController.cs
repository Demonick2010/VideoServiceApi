using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using VideoService.Models.Models;

namespace VideoService.General.Controllers
{
    [Route("dashboard")]
    public class DashboardViewController : Controller
    {
        [HttpGet]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("showall")]
        public async Task<IActionResult> ShowAllCategories()
        {
            var categories = await GenericGetDataClass<List<Category>>.GetCategoryData("api/categories");

            return View(categories);
        }

        [Route("showone/{id}")]
        public async Task<IActionResult> ShowOneCategory(int id)
        {
            var category = await GenericGetDataClass<Category>.GetCategoryData($"api/category/{id}");
            return View(category);
        }

        [HttpGet]
        [Route("edit/{id}")]
        public async Task<IActionResult> EditCategory(int id)
        {
            var category = await GenericGetDataClass<Category>.GetCategoryData($"api/category/{id}");
            return View(category);
        }

        [HttpPost]
        [Route("edit")]
        public async Task<IActionResult> EditCategory(Category editedCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(editedCategory);
            }

            var response = await GenericGetDataClass<Category>.EditCategoryData($"api/edit", editedCategory);

            if (response)
            {
                TempData["SM"] = "Selected category edit successful!";
                return RedirectToAction(nameof(ShowAllCategories));
            }
            else
            {
                return View(editedCategory);
            }
        }

        [HttpGet]
        [Route("add")]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddCategory(Category addedCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(addedCategory);
            }

            var response = await GenericGetDataClass<Category>.AddCategoryData($"api/add", addedCategory);

            if (response)
            {
                TempData["SM"] = $"Add category {addedCategory.Name} successful!";
                return RedirectToAction(nameof(ShowAllCategories));
            }
            else
            {
                return View(addedCategory);
            }
        }

        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var response = await GenericGetDataClass<Category>.DeleteCategory($"api/delete/{id}");

            if (response)
            {
                TempData["SM"] = "Category deleting successful!";
                return RedirectToAction(nameof(ShowAllCategories));
            }

            TempData["SM"] = "Something wrong";
            return RedirectToAction(nameof(ShowAllCategories));
        }
    }
}
