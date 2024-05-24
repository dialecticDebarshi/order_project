using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using order_project.Models;
using order_project.Repositories;
using System.Diagnostics;
using order_project.Repositories;

namespace order_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IOrderRepository _orderRepository;

        private readonly TenantCompanyProfileController _tenantCompanyProfile;
        private readonly string BaseUrlAuth;

        private readonly string BaseUrl;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration= configuration;
        }

        public async Task<IActionResult> Index()
        {
            var CustomerList = await GetCustomerNames();
            ViewBag.CustomerList = new SelectList(CustomerList, "Value", "Text");
            return View();
        }

        public async Task<List<SelectListItem>> GetCustomerNames()
        {
            try
            {
                var obj = await Task.Run(() => _orderRepository.GetCustomerNames());

                // Convert the list of objects to a list of SelectListItem
                var customerList = obj.Select(x => new SelectListItem
                {
                    Text = x.GetType().GetProperty("text").GetValue(x, null).ToString(),
                    Value = x.GetType().GetProperty("value").GetValue(x, null).ToString()
                }).ToList();

                // Insert the default select item at the beginning of the list
                customerList.Insert(0, new SelectListItem { Text = "-- Select --", Value = "" });

                return customerList;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as required
                throw;
            }
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
