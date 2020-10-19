using CarSalesMani.Models.DataModels;
using CarSalesMani.Models.Requests;
using CarSalesMani.Models.Responses;
using CarSalesMani.Services.Interfaces;
using Mani.Services.Interfaces;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Mani.Services.Implementations
{
	/// <summary>
	///  Use this class to implement buiness logicc
	/// </summary>
	public class SalesPersonAssignmentService : ISalesPersonAssignmentService
	{
		private readonly ICustomerLanguageService customerLanguageService = null;
		private readonly ICarTypesService carTypesService = null;
		public SalesPersonAssignmentService(ICustomerLanguageService pCustomerLanguageService, ICarTypesService pCarTypesService)
		{
			carTypesService = pCarTypesService;
			customerLanguageService = pCustomerLanguageService;
		}

		public AssignedSalesPerson AssignTheMostSuitableSalesPerson(SalesPersonRequest salesPersonRequest)
		{
			ValidateRequest(salesPersonRequest);
			SalesPersonAndGroup chosenperson = GetChosenSalesPerson(salesPersonRequest);
			// we want to send sepaciality descriptions not just code
			return ParseToAssignedSalesPerson(chosenperson); ;
		}

		private void ValidateRequest(SalesPersonRequest salesPersonRequest)
		{
			// we need to validate the input since api can be called from any client
			// like postman, fiddler
			if (!customerLanguageService.IsValidLanguage(salesPersonRequest.Language))
				throw new Exception("Invalid langauge selection");
			if (!carTypesService.IsValidCarType(salesPersonRequest.CarType))
				throw new Exception("Invalid car type selection");
		}

		private SalesPersonAndGroup GetChosenSalesPerson(SalesPersonRequest salesPersonRequest)
		{
			SalesPersonAndGroup chosenperson = null;
			Random rand = new Random();
			// Linq will get excuted only when accessed. No need to
			List<SalesPersonAndGroup> anySalesPerson = SalesPeopleData.SalesPeopleInfo;
			List<SalesPersonAndGroup> personsSpecialisingInCar =
				SalesPeopleData.SalesPeopleInfo.FindAll(x => x.Groups.Any(x => x == salesPersonRequest.CarType));
			List<SalesPersonAndGroup> personsSpecialisingInLangAndCar =
				SalesPeopleData.SalesPeopleInfo.FindAll(x =>
				x.Groups.Any(x => x == salesPersonRequest.Language) && 
				x.Groups.Any(x => x == salesPersonRequest.CarType));
			

			if (personsSpecialisingInLangAndCar.Count >= 1)
				chosenperson = GetSaleSPersonAtRandom(rand, personsSpecialisingInLangAndCar);
			else if (personsSpecialisingInCar.Count >= 1)
				chosenperson = GetSaleSPersonAtRandom(rand, personsSpecialisingInCar);
			else if (anySalesPerson.Count > 1)
				chosenperson = GetSaleSPersonAtRandom(rand, anySalesPerson);
			else
				throw new Exception("Possibly no sales person DATA INPUT");
			return chosenperson;
		}

		private static SalesPersonAndGroup GetSaleSPersonAtRandom(Random rand, List<SalesPersonAndGroup> personsSpecialisesInLangAndCar)
		{
			SalesPersonAndGroup chosenperson;
			// if more than one found return random perons
			//ex: sales Person p1,p2,p3 both specialises in greak and sports 
			//and if customer shose sports and speaks greek
			// you want to return just anyone at random
			int toSkip = rand.Next(0, personsSpecialisesInLangAndCar.Count);
			chosenperson = personsSpecialisesInLangAndCar.Skip(toSkip).Take(1).First();
			return chosenperson;
		}

		private AssignedSalesPerson ParseToAssignedSalesPerson(SalesPersonAndGroup chosenperson)
		{
			AssignedSalesPerson assignedSalesPerson = new AssignedSalesPerson();
			assignedSalesPerson.SalesPersonName = chosenperson.Name;
			foreach (var g in chosenperson.Groups)
			{
				var f = SalesPersonSpeciality.Groups.FirstOrDefault(x => x.GroupName == g);
				if (f != null)
					assignedSalesPerson.SpecialityList.Add(f.GroupDescription);//
			}

			return assignedSalesPerson;
		}
	}
}
