using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
	public class ProductController : Controller
	{
		private readonly HttpClient client = null;

		public ProductController()
		{
			client = new HttpClient();
			var contentType = new MediaTypeWithQualityHeaderValue("application/json");
			client.DefaultRequestHeaders.Accept.Add(contentType);
			client.BaseAddress = new Uri("https://localhost:44387/api");
		}

		public async Task<IActionResult> Index()
		{
			HttpResponseMessage response = await client.GetAsync(client.BaseAddress 
																+ "/Products/GetProducts");
			string data = await response.Content.ReadAsStringAsync();

			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true,
			};
			
			return View(System.Text.Json.JsonSerializer.Deserialize<List<Product>>(data, options));
		}

		//public ActionResult Details(int id)
		//{
			
		//}

		//public ActionResult Create()
		//{

		//}

		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> Create(Product product)
		//{
		//	HttpResponseMessage response = await client.GetAsync(ProductApiUrl);
		//	string data = await response.Content.ReadAsStringAsync();


		//}

		//public ActionResult Edit(int id)
		//{

		//}

		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult Edit(int id, IFormCollection collection)
		//{

		//}

		//public ActionResult Delete(int id)
		//{

		//}

		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult Delete(int id, IFormCollection collection)
		//{

		//}
	}
}
