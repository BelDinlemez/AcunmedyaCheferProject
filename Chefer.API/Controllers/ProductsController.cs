using AutoMapper;
using Chefer.API.Context;
using Chefer.API.DTOs.CategoryDtos;
using Chefer.API.DTOs.ProductDtos;
using Chefer.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Chefer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly CheferContext _context;
        private readonly IMapper _mapper;

        public ProductsController(CheferContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetAll()   
        {
            var products = _context.Products.Include(x => x.Category).ToList();
            return Ok(products);
        }

        [HttpPost]
        public IActionResult Create(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);
            _context.Add(product);
            _context.SaveChanges();
            return Ok(product);

        }

            [HttpPut]
        public IActionResult Update(UpdateProductDto updateProductDto )
        {
            var product = _context.Products.Find(updateProductDto.ProductId);
            if (product == null)
            {
                return BadRequest("Güncellenecek Ürün Bulunamadı.");
            }
            product =_mapper.Map(updateProductDto,product);
           

            _context.Update(product);
            _context.SaveChanges();
            return Ok("Ürün Başarıyla Güncellendi.");
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var products = _context.Products.Find(id);
            if (products == null)
            {
                return BadRequest("Ürün bulunamadı.");
            }

            return Ok(products);

        }
        //api/products/4
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return BadRequest("Ürün Bulunamadı.");
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok("Ürün Başarıyla Silindi.");
        }
    }
}
