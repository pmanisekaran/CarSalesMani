
using CarSalesMani.Helpers;
using CarSalesMani.Models.DataModels;
using CarSalesMani.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CarSalesMani.Services.Implementations
{
	public class CustomerLanguageService : ICustomerLanguageService
	{



		public List<Group> GetCustomerLanguages()
		{


			List<Group> list =
				SalesPersonSpeciality.Groups.FindAll(
					x => x.GroupDescription.StartsWith(Constants.LanguageIdentifier)
					).ToList();

			// in addition what is returned add two additional items as per requirement
			list.Add(new Group(Constants.DoNotSpeakGreakGroupName, Constants.DoNotSpeakGreak));
			list.Add(new Group(Constants.RegardlessOfLanguageName, Constants.RegardlessOfLanguage));

			return list;
		}

		public bool IsValidLanguage(string groupName)
		{
			return GetCustomerLanguages().Any(x => x.GroupName == groupName);
		}
	}
}
