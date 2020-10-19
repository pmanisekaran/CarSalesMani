using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSalesMani.Models.Responses
{
	public class AssignedSalesPerson
	{
		public string SalesPersonName { get; set; }
		public List<string> SpecialityList { get; } = new List<string>();
	}
}
