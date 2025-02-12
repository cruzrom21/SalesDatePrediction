using HR.Models.Domain;
using HR.Persistence.Database;
using HR.Services.Employees.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Services.Employees
{
	public class EmployeesServices : IEmployeesServices
	{
		private StoreSampleContext _db;

		public EmployeesServices(StoreSampleContext dbContext)
		{
			_db = dbContext;
		}

		public List<GetEmployee> GetEmployees()
		{
			try
			{
				List<GetEmployee> getEmployees = _db.GetEmployees.ToList();
				return getEmployees;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
