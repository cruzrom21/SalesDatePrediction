using HR.Models.Domain;
using HR.Persistence.Database;
using HR.Services.Employees;
using Microsoft.EntityFrameworkCore;

namespace HR.Testing.Test
{
	public class EmployeesServicesTest
	{
		private readonly StoreSampleContext _dbContext;
		private readonly EmployeesServices _service;

		public EmployeesServicesTest()
		{
			var options = new DbContextOptionsBuilder<StoreSampleContext>()
				.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
				.Options;

			_dbContext = new StoreSampleContext(options);

			// Insertar datos de prueba
			DataDB();

			_service = new EmployeesServices(_dbContext);
		}

		private void DataDB()
		{
			List<GetEmployee> employees = new List<GetEmployee>
			{
				new GetEmployee { Empid = 1, FullName = "Sara Davis" },
				new GetEmployee { Empid = 2, FullName = "Don Funk" },
				new GetEmployee { Empid = 3, FullName = "Judy Lew" }
			};

			_dbContext.GetEmployees.AddRange(employees);
			_dbContext.SaveChanges();
		}


		[Fact]
		public void GetEmployees()
		{
			var result = _service.GetEmployees();

			Assert.NotNull(result);
			Assert.Equal(3, result.Count);
		}
	}
}