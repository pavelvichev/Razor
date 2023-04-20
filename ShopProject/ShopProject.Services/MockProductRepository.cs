using Microsoft.EntityFrameworkCore;

using ShopProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProject.Services
{
	public class MockProductRepository : IProductsRepository
	{
		private readonly ShopProjectContext _context;

		public MockProductRepository(ShopProjectContext context)
		{
			_context = context;
		}

		public Product Add(Product newProduct)
		{
			_context.Database.ExecuteSqlRaw("spAddNewProduct {0},{1},{2},{3},{4},{5}", newProduct.Name, newProduct.PhoneNum ,newProduct.PhotoPath,newProduct.ShortDescription, newProduct.qty, newProduct.category );
			return newProduct;
		}

		public Product Delete(int id)
		{
			var productToDelete = _context.Product.Find(id);

			if (productToDelete != null)
			{
				_context.Product.Remove(productToDelete);
				_context.SaveChanges();
			}
			return productToDelete;
		}

		public IEnumerable<Product> GetAllProducts()
		{
			return _context.Product;
		}

		public Product GetProduct(int id)
		{
			return _context.Product.FromSqlRaw(@"Declare @Id int;
												Set @Id = {0};
											SELECT * FROM dbo.Product where @Id = Id", id).ToList().FirstOrDefault();
		}

		public Product Update(Product updatedProduct)
		{
			var product = _context.Product.Attach(updatedProduct);
			product.State = EntityState.Modified;
			_context.SaveChanges();

			return updatedProduct;
		}
	}
}
