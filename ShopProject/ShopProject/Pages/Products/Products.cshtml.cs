using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopProject.Models;
using ShopProject.Services;

namespace ShopProject.Pages.Products
{
	public class ProductsModel : PageModel
	{
		private readonly IProductsRepository _productsRepository;

		public ProductsModel(IProductsRepository productsRepository)
		{
			_productsRepository = productsRepository;
		}
		public Product product { get; set; }
		public IEnumerable<Product> Products { get; set; }

		public void OnGet()
		{ 
			Products = _productsRepository.GetAllProducts();
			
       }
    }
}
