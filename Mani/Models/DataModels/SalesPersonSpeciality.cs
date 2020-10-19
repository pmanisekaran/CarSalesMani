using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarSalesMani.Models.DataModels
{
	/// <summary>
	/// This is a static class because data is provided as static.
	/// It exposes groups object which is extendable
	/// </summary>
	public static class SalesPersonSpeciality
	{
		public static List<Group> Groups { get; } = new List<Group>();
		static SalesPersonSpeciality()
		{
			Groups.Add(new Group("A", "Speak Greak"));
			Groups.Add(new Group("B", "Sports car specialist"));
			Groups.Add(new Group("C", "Family car specialist"));
			Groups.Add(new Group("D", "Tradie vehicle specialist"));

		}


	}
}
