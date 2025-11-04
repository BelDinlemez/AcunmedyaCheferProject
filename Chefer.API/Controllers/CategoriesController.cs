using Chefer.API.Context;
using Chefer.API.DTOs.CategoryDtos;
using Chefer.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chefer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CheferContext _context;

        public CategoriesController(CheferContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var categories = _context.Categories.ToList() ;
            return Ok(categories);
        
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var category = _context.Categories.Find(id);

            if(category ==null)
            {
                return BadRequest("Kategori Bulunamadı.");
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryDto createCategoryDto) 
        {
            var category = new Category
            {
                CategoryName = createCategoryDto.CategoryName,
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok(category);

        }
        [HttpPut]
        public IActionResult Update(UpdateCategoryDto updateCategoryDto) 
        {
            var category = _context.Categories.Find(updateCategoryDto.CategoryId);
            if (category == null)
            {
                return BadRequest("Kategori Bulunamadı.");
            }

           category.CategoryName = updateCategoryDto.CategoryName;

            _context.Categories.Update(category);
            _context.SaveChanges();
            return Ok("Kategori Başarıyla Güncellendi.");
        }


        //api/categories/4
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return BadRequest("Kategori Bulunamadı.");
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return Ok("Kategori Başarıyla Silindi.");
        }

    }

}
