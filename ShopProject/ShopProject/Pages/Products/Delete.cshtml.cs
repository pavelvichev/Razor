using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopProject.Models;
using ShopProject.Services;

namespace ShopProject.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly IProductsRepository _productsRepository;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public DeleteModel(IProductsRepository productsRepository , IWebHostEnvironment webHostEnvironment)
        {
            _productsRepository = productsRepository;
			_webHostEnvironment = webHostEnvironment;
		}
        [BindProperty]
        public Product product { get; set; }
        public IActionResult OnGet(int id)
        {
            product = _productsRepository.GetProduct(id);
            return Page();
        }

        public IActionResult OnPost()
        {
            Product deletedProduct = _productsRepository.Delete(product.Id);

			if (deletedProduct.PhotoPath != null)
            {
				string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", deletedProduct.PhotoPath);
				if (deletedProduct.PhotoPath != "jeni11.jpg")
					System.IO.File.Delete(filePath);
			}


			return RedirectToPage("Products");
        }
    }
    
}
