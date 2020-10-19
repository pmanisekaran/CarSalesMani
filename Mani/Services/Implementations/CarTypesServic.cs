using CarSalesMani.Helpers;
using CarSalesMani.Models.DataModels;
using CarSalesMani.Services.Interfaces;
using Mani.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mani.Services.Implementations
{
	public class CarTypesService : ICarTypesService
	{
		public List<Group> GetCarTypes()
		{
			List<Group> list =
							SalesPeopleGroups.Groups.FindAll(
								x => !x.GroupDescription.StartsWith(Constants.LanguageIdentifier)
								).ToList();
			return list;
		}
	}
}
