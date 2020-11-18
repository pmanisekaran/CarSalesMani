using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CarSalesMani.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace CarSalesMani.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class ServerIpController : ControllerBase
	{

		[HttpGet]
		public WebServerDetails Get()
		{
			try
			{
				string hostName = Dns.GetHostName(); // Retrive the Name of HOST  
				Console.WriteLine(hostName);
				// Get the IP  
				string myIP = Dns.GetHostEntry(hostName).AddressList[1].ToString();
				return new WebServerDetails() { HostName=hostName,ServerIp=myIP};
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
