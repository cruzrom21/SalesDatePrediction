using Api.Gateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Gateway.Proxies.Interfaces
{
	public interface IHRProxy
	{
		Task<List<GetEmployee>?> GetEmployees();
	}
}
