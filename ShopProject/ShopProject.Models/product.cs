using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProject.Models
{
	public class Product
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required(ErrorMessage = "Field can`t be null")]
		public string Name { get; set; }
		public string ShortDescription { get; set; }
		public string PhotoPath { get; set; } = "jeni11.jpg";
		[Required(ErrorMessage = "Field can`t be null")]
		public string PhoneNum { get; set; }
		[Required(ErrorMessage = "Field can`t be null")]
		public int qty { get; set; }

		public Categories category { get; set; }

	}
}
