using Microsoft.EntityFrameworkCore;
using Sales.Models.Domain;
using Sales.Persistence.Database;
using Sales.Services.Shippers.Interfaces;

namespace Sales.Services.Shippers
{
	public class ShipperServices : IShipperServices
	{
		private StoreSampleContext _db;

		public ShipperServices(StoreSampleContext dbContext)
		{
			_db = dbContext;
		}

		public List<GetShipper> GetShippers()
		{

			List<GetShipper> shippers = _db.GetShippers.ToList();

			return shippers;
		}
	}
}
