using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Threading.Tasks;

namespace CarSalesMani.Models.DataModels
{
	/// <summary>
	/// This class is static becuase data provided is static
	/// This class loads json into sales people ifo property
	/// If additional propeties are added to json ,
	/// make sure it is reflected in this SalesPersonAndGroup class
	/// or you can extended SalesPersonAndGroup class
	/// </summary>
	public static class SalesPeopleData
	{

		public static List<SalesPersonAndGroup> SalesPeopleInfo { get; private set; } = null;
		static SalesPeopleData()
		{
			var assembly = Assembly.GetExecutingAssembly();
			var resourceName = "CarSalesMani.salesperson.json";

			using (Stream stream = assembly.GetManifestResourceStream(resourceName))
			{
				using (StreamReader reader = new StreamReader(stream))
				{
					string result = reader.ReadToEnd();
					SalesPeopleInfo = JsonConvert.DeserializeObject<List<SalesPersonAndGroup>>(result);
				}
			}


		}


	}
}
