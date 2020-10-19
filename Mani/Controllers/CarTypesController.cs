using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSalesMani.Models.DataModels;
using CarSalesMani.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace CarSalesMani.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class CarTypesController : ControllerBase
	{
		private readonly ICarTypesService carTypesService = null;
		public CarTypesController(ICarTypesService pCarTypesService)
		{
			this.carTypesService = pCarTypesService;
		}

		[HttpGet]
		public List<Group> Get()
		{
			try
			{
				return carTypesService.GetCarTypes();
			}
			catch (Exception ex)
			{
				Response.StatusCode = 500;
				HttpContext.Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = ex.Message;
				return new List<Group>();
			}
		}
	}
}
