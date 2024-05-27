using Microsoft.AspNetCore.Mvc;
using order_project.Models;

namespace order_project.Repositories
{
    public interface IOrderRepository
    {

		public List<object> GetCustomerNames();

		public List<object> GetProduct();

		public List<object> GetOrderDetails();

        public int SaveOrder(Order model);


    }
}
