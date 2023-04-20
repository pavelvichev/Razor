using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPagesLessons.Models
{
	public class Employee
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "The name field cannot be null ")]
		[MaxLength(50), MinLength(2)]
		public string Name { get; set; }
		[Required]
		[RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Please, enter a valid Email (format: 'example@exem.com'")]
		[MaxLength(50), MinLength(2)]
		public string Email { get; set; }
		public string PhotoPath { get; set; } = "noimage.png";
		public Dept? Department { get; set; }

	}
}
