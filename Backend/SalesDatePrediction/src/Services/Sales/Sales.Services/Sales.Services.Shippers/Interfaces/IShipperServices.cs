using Sales.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Services.Shippers.Interfaces
{
	public interface IShipperServices
	{
		List<GetShipper> GetShippers();
	}
}
