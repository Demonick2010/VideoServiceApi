using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoService.Models.Models;
using VideoService.Services.Interfaces;

namespace VideoService.General.Controllers
{
    [ApiController]
    [Route("api")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryOfWork _categoryOfWork;

        public CategoriesController(ICategoryOfWork categoryOfWork)
        {
            _categoryOfWork = categoryOfWork;
        }

        [HttpGet]
        [Route("categories")]
        public Task<IEnumerable<Category>> GetAll()
        {
            return _categoryOfWork.Categories.GetAll();
        }

        [HttpGet]
        [Route("category/{id}")]
        public Task<Category> GetOne(int id)
        {
            return _categoryOfWork.Categories.Get(id);
        }

        [HttpPut]
        [Route("edit")]
        public Task<int> EditCategory(Category editedCategory)
        {
            return _categoryOfWork.Categories.Update(editedCategory);
        }

        [HttpPost]
        [Route("add")]
        public Task<int> AddCategory(Category addedCategory)
        {
            return _categoryOfWork.Categories.Add(addedCategory);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public Task<int> DeleteCategory(int id)
        {
            return _categoryOfWork.Categories.Delete(id);
        }
    }
}
