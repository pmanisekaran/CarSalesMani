using System;
using System.Collections.Generic;
using CarSalesMani.Models.DataModels;
using CarSalesMani.Services.Interfaces;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarSalesMani.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class CustomerLanguageController : ControllerBase
	{

		private readonly ICustomerLanguageService customerLanguageService;
		public CustomerLanguageController( ICustomerLanguageService pCustomerLanguageService)
		{
			customerLanguageService = pCustomerLanguageService;
		}

		[HttpGet]
		public List<Group> Get()
		{
			try
			{
				return customerLanguageService.GetCustomerLanguages();
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
