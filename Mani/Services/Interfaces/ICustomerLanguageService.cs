using CarSalesMani.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSalesMani.Services.Interfaces
{
	public interface ICustomerLanguageService
	{

		List<Group> GetCustomerLanguages();
		bool IsValidLanguage(string groupName);
	}
}
