using HR.Models.Domain;
using HR.Services.Employees.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Controllers
{
	[ApiController]
	[Route("hr")]
	public class EmployeesController : ControllerBase
	{
		private IEmployeesServices _employeesServices;

		public EmployeesController(IEmployeesServices employeesServices)
		{
			_employeesServices = employeesServices;
		}

		[HttpGet("GetEmployees")]
		public ActionResult<List<GetEmployee>?> GetEmployees()
		{
			try
			{
				return _employeesServices.GetEmployees();
			}
			catch (Exception ex)
			{
				return new BadRequestObjectResult(new { message = ex.Message });
			}
		}
	}
}
