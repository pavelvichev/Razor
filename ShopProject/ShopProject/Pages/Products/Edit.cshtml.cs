using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopProject.Models;
using ShopProject.Services;

namespace ShopProject.Pages.Products
{
    public class EditModel : PageModel
    {
		private readonly IProductsRepository _productsRepository;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public EditModel(IProductsRepository productsRepository, IWebHostEnvironment webHostEnvironment)
        {
			_productsRepository = productsRepository;
			_webHostEnvironment = webHostEnvironment;
		}
        [BindProperty]
            public  Product product { get; set; }
		[BindProperty]
		public IFormFile? Photo { get; set; }
        
		public IActionResult OnGet(int id)
		{
			
				product = _productsRepository.GetProduct(id);
			
			if (product == null)
			{
				return RedirectToPage("/NotFound");
			}
			else
			{
				return Page();
			}
		}

		public IActionResult OnPost() 
        {
			if (Photo != null)
			{
				if (product.PhotoPath != null)
				{
					string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", product.PhotoPath);
					if (product.PhotoPath != "jeni11.jpg")
						System.IO.File.Delete(filePath);
				}
				product.PhotoPath = UploadFile();

			}

			product = _productsRepository.Update(product);

			return RedirectToPage("Products");
		}

		string UploadFile()
		{
			string uniqueFileName = null;

			if (Photo != null)
			{
				string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
				uniqueFileName = Guid.NewGuid().ToString() + "-" + Photo.FileName;

				string filePath = Path.Combine(uploadsFolder, uniqueFileName);

				using (var fs = new FileStream(filePath, FileMode.Create))
				{
					Photo.CopyTo(fs);
				}

				
			}
			return uniqueFileName;
		}
    }
}
