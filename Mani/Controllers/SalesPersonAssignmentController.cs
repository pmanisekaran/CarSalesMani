using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSalesMani.Models.DataModels;
using CarSalesMani.Models.Requests;
using CarSalesMani.Models.Responses;
using CarSalesMani.Services.Interfaces;
using Mani.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace CarSalesMani.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class SalesPersonAssignmentController : ControllerBase
	{
		private readonly ISalesPersonAssignmentService salesPersonAssignmentService;

		public SalesPersonAssignmentController(ISalesPersonAssignmentService pSalesPersonAssignmentService)
		{
			salesPersonAssignmentService = pSalesPersonAssignmentService;
		}

		[HttpPost]
		public AssignedSalesPerson Post([FromBody] SalesPersonRequest salesPersonRequest)
		{
			try
			{
				AssignedSalesPerson assignedSalesPerson = salesPersonAssignmentService
					.AssignTheMostSuitableSalesPerson(salesPersonRequest);

				return assignedSalesPerson;
			}
			catch (Exception ex)
			{
				Response.StatusCode = 500;
				HttpContext.Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = ex.Message;
				return null;
			}
		}

	}
}
