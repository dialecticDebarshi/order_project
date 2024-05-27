using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using order_project.Models;
using order_project.Repositories;
using System.Diagnostics;
using System.Collections.Generic;

namespace order_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        private readonly string BaseUrlAuth;

        private readonly string BaseUrl;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,IOrderRepository iOrderRepository)
        {
            _logger = logger;
           // _configuration= configuration;
			_orderRepository= iOrderRepository;

		}

        public async Task<IActionResult> Index()
        {

            List<object> customerList = _orderRepository.GetCustomerNames();
            customerList.Insert(0, new { CustomerId = 0, NAME = "-- Select --" });
            ViewBag.CustomerList = new SelectList(customerList, "CustomerId", "NAME");

            // Retrieve product list
            List<object> productList = _orderRepository.GetProduct();
            productList.Insert(0, new { ProductId = 0, NAME = "-- Select --" });
            ViewBag.ProductList = new SelectList(productList, "ProductId", "NAME");

            List<object> orderDetailsObjectList = _orderRepository.GetOrderDetails();
                        
            List<Order> orderDetails = orderDetailsObjectList.Cast<Order>().ToList();

            ViewBag.OrderDetails = orderDetails;

            return View();

        }

       
        [HttpPost]
        public IActionResult Save(int customerId, int productId, int quantity)
        {
           
            int selectedCustomerId = customerId;
            int selectedProductId = productId;
            int enteredQuantity = quantity;

            Order model = new Order
            {
                CustomerId = selectedCustomerId,
                ProductId = selectedProductId,
                Quantity = enteredQuantity
            };

            int r = _orderRepository.SaveOrder(model);

            if (r > 0)
            {
                TempData["Message"] = "Order saved successfully!";
                TempData["MessageType"] = "success";
            }
            else
            {
                TempData["Message"] = "Error saving order. Please try again.";
                TempData["MessageType"] = "error";
            }

            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
