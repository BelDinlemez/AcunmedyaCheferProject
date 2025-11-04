using Chefer.WebUI.DTOs.CategoryDtos;

using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Chefer.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly HttpClient _client;

        public CategoryController(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7082/api/");
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync("Categories");

            var categories = await _client.GetFromJsonAsync<List<ResultCategoryDto>>("categories");
            return View(categories);

        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto categoryDto)

        {
            await _client.PostAsJsonAsync("categories", categoryDto);
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> UpdateCategory(int id)

        {
            var category = await _client.GetFromJsonAsync<UpdateCategoryDto>("categories/" + id);

            return View(category);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto categoryDto)
        {
            await _client.PutAsJsonAsync("categories", categoryDto);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteCategory(int id)

        {
            var category = await _client.DeleteAsync("categories/" + id);

            return RedirectToAction("Index");

        }
    }
}
