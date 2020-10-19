using CarSalesMani.Helpers;
using CarSalesMani.Models.DataModels;
using CarSalesMani.Services.Interfaces;
using Mani.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Mani.Services.Implementations
{
	public class CarTypesService : ICarTypesService
	{
		public List<Group> GetCarTypes()
		{
			List<Group> list =
			SalesPersonSpeciality.Groups.FindAll(
			x => !x.GroupDescription.StartsWith(Constants.LanguageIdentifier)
			).ToList();
			list.Add(new Group(Constants.NotSpecifyCarTypeGroupDescName,
				Constants.NotSpecifyCarTypeGroupDesc));

			return list;
		}

		public bool IsValidCarType(string groupName)
		{
			return GetCarTypes().Any(x => x.GroupName == groupName);
		}
	}
}
