﻿using Microsoft.AspNetCore.Mvc;
using Shopping.Client.Models;
using System.Diagnostics;
using System.Text.Json;

namespace Shopping.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger , IHttpClientFactory _httpClientFactory)
        {
            _httpClient = _httpClientFactory.CreateClient("ShoppingApi");
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("/products");
            var content = await response.Content.ReadAsStringAsync();
            var productList = JsonSerializer.Deserialize<IEnumerable<Product>>(content , new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return View(productList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}