using RazorPagesLessons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPagesLessons.Services
{
	public interface IEmployeeRepository
	{
		IEnumerable<Employee> Search(string searchTerm);
		Employee GetEmployee(int id);
		IEnumerable<Employee> GetAllEmployees();
        Employee Update(Employee updatedEmployee);
        Employee Add(Employee newEmployee);
		Employee Delete(int id);
		IEnumerable<DeptHeadCount> EmployeeCountByDept(Dept? dept);
			 

    }

	

}
