using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSalesMani.Models.DataModels
{
	/// <summary>
	/// represents sales person and his/her association to groups
	/// </summary>
	public class SalesPersonAndGroup
	{

		public string Name { get; set; }
		public List<string> Groups { get; set; }

	}
}
