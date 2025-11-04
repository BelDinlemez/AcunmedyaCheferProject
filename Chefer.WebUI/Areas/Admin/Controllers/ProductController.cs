using Chefer.WebUI.DTOs.CategoryDtos;
using Chefer.WebUI.DTOs.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Chefer.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly HttpClient _client;

        public ProductController(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7082/api/");
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _client.GetFromJsonAsync<List<ResultProductDto>>("products");
            return View(products);
        }

        public async Task<IActionResult>  CreateProduct()
        {
            var categories = await _client.GetFromJsonAsync<List<ResultCategoryDto>>("categories");

            ViewBag.categories = (from x in categories
                                  select new SelectListItem()
                                  {
                                      Text = x.CategoryName,
                                      Value = x.CategoryId.ToString()
                                  }).ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct( CreateProductDto productDto)

        {
            await _client.PostAsJsonAsync("products", productDto);
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> UpdateProduct(int id)

        {
            var categories = await _client.GetFromJsonAsync<List<ResultCategoryDto>>("categories");
            ViewBag.categories = (from x in categories
                                  select new SelectListItem()
                                  {
                                      Text = x.CategoryName,
                                      Value = x.CategoryId.ToString()
                                  }).ToList();

            var product = await _client.GetFromJsonAsync<UpdateProductDto>("products/" + id);

            return View(product);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto productDto)
        {
            await _client.PutAsJsonAsync("products", productDto);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteProduct(int id)

        {
            var category = await _client.DeleteAsync("products/" + id);

            return RedirectToAction("Index");

        }
    }
}
