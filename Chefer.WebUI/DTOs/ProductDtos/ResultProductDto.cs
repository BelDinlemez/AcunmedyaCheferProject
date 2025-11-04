using Chefer.WebUI.DTOs.CategoryDtos;

namespace Chefer.WebUI.DTOs.ProductDtos
{
    public class ResultProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }


        public int CategoryId { get; set; }

        public ResultCategoryDto Category { get; set; }
    }
}
