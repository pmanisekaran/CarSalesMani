using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSalesMani.Models.DataModels
{
	public class Group
	{
		public Group(string name, string desc)
		{
			GroupName = name;
			GroupDescription = desc;
		}

		public string GroupName { get; set; }
		public string GroupDescription { get; set; }
	}
}
