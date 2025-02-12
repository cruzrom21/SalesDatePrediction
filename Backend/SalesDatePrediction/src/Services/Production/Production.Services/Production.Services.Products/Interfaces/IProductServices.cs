using Production.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Production.Services.Products.Interfaces
{
	public interface IProductServices
	{
		List<GetProduct> GetProducts();
	}
}
