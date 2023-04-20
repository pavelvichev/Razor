using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesLessons.Services;
using RazorPagesLessons.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text;

namespace RazorPagesGeneral.Pages.Employees
{

	public class EditModel : PageModel
	{
		private readonly IEmployeeRepository _employeeRepository;
		private readonly IWebHostEnvironment _webHostEnviroment;

		public EditModel(IEmployeeRepository employeeRepository, IWebHostEnvironment webHostEnviroment) 
		{
			_employeeRepository = employeeRepository;
			_webHostEnviroment = webHostEnviroment;
		}
		[BindProperty]
		public Employee Employee { get; set; }

		[BindProperty]
		public IFormFile? Photo { get; set; }
		[BindProperty]
		public bool Notify { get; set; }
		
		public string Message { get; set; }
		
		public IActionResult OnGet(int? id)
		{
			if (id.HasValue)
				Employee = _employeeRepository.GetEmployee(id.Value);
			else
			{
				Employee = new Employee();
				
			}
			if (Employee == null)
			{
				return RedirectToPage("/NotFound");
			}
			else
			{
				return Page();
			}
		}
		public IActionResult OnPost() { 
		
		if (ModelState.IsValid)
	{ 
		
				if (Photo != null)
				{
					if (Employee.PhotoPath != null)
					{
						string filePath = Path.Combine(_webHostEnviroment.WebRootPath, "images", Employee.PhotoPath);
						if(Employee.PhotoPath != "noimage.png")
						System.IO.File.Delete(filePath);
					}
					Employee.PhotoPath = ProcesUploadedFile();

				}

				if (Employee.Id > 0)
				{
					Employee = _employeeRepository.Update(Employee);

					TempData["SuccesMessage"] = $"Update {Employee.Name} succesful!";
				}
				else
				{
					Employee = _employeeRepository.Add(Employee);
                    TempData["SuccesMessage"] = $"Create {Employee.Name} succesful!";

                }
				return RedirectToPage("Employees");
			}
            if (!ModelState.IsValid)
            {
                StringBuilder errors = new StringBuilder();
                foreach (ModelError error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    errors.Append(error.ErrorMessage).Append("\n");
                }
                string errorsString = errors.ToString();
                // обработка ошибок...
				
            }

            return Page();
        }

		string ProcesUploadedFile()
		{
			string uniqueFileName = null;

			if (Photo != null)
			{
				string uploadsFolder = Path.Combine(_webHostEnviroment.WebRootPath, "images");
				uniqueFileName = Guid.NewGuid().ToString() + "-" + Photo.FileName;
				string filePath = Path.Combine(uploadsFolder, uniqueFileName);

				using (var fs = new FileStream(filePath, FileMode.Create))
				{
					Photo.CopyTo(fs);
				}
			}

			return uniqueFileName;
		}

		public void OnPostUpdateNotifactionPreferences(int id)
		{
			Employee = _employeeRepository.GetEmployee(id);

			if (Notify)
			{
				Message = "Thank you for turning on Notification";
			}
			else
				Message = "You have turned off Notification";
		}
	}
}
