using ShopProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProject.Services
{
	
		public interface IProductsRepository
		{
			//IEnumerable<Product> Search(string searchTerm);
			Product GetProduct(int id);
			IEnumerable<Product> GetAllProducts();
			Product Update(Product updatedProduct);
			Product Add(Product newProduct);
			Product Delete(int id);
	
		}
}
