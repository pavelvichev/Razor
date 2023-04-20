using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesLessons.Models;
using RazorPagesLessons.Services;

namespace RazorPagesGeneral.Pages.Employees
{
    public class EmployeesModel : PageModel
    {
        private readonly IEmployeeRepository _DB;
        public EmployeesModel(IEmployeeRepository DB)
        {
            _DB= DB;
        }

       public IEnumerable<Employee> Employees { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public void OnGet()
        {
            Employees = _DB.Search(SearchTerm);
        }


    }
}
