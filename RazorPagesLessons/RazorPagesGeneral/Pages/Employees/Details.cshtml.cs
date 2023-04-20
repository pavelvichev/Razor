using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesLessons.Models;
using RazorPagesLessons.Services;

namespace RazorPagesGeneral.Pages.Employees
{
    public class DetailsModel : PageModel
    {

        public DetailsModel(IEmployeeRepository employeeRepository)
        {
			EmployeeRepository = employeeRepository;
		}

        public IEmployeeRepository EmployeeRepository;
		public Employee Employee { get; private set; }

		public IActionResult OnGet(int id)
        {
			Employee = EmployeeRepository.GetEmployee(id);

            if(Employee == null)
            {
                return RedirectToPage("/NotFound");
            }

            else
            {
                return Page();
            }
        }
    }
}
