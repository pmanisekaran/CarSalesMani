using CarSalesMani.Models.Requests;
using CarSalesMani.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mani.Services.Interfaces
{
	public interface ISalesPersonAssignmentService
	{
		AssignedSalesPerson AssignTheMostSuitableSalesPerson(SalesPersonRequest salesPersonRequest);
	}
}
