using Production.Models.Domain;
using Production.Persistence.Database;
using Production.Services.Products.Interfaces;

namespace Production.Services.Products
{
	public class ProductServices : IProductServices
	{
		private StoreSampleContext _db;

		public ProductServices(StoreSampleContext dbContext)
		{
			_db = dbContext;
		}

		public List<GetProduct> GetProducts()
		{
			try
			{
				List<GetProduct> getProducts = _db.GetProducts.ToList();
				return getProducts;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
