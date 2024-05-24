using Microsoft.AspNetCore.Mvc;
using order_project.Models;

namespace order_project.Repositories
{
    public interface IOrderRepository
    {

		public List<object> GetCustomerNames();

		//public List<object> GetProduct();

		//public List<Order> GetAdvanceHrd(int EMPLOYEE_MASTER_KEY, int REPORTING_BOSS_KEY);
  //      public List<Order> ExtendAdvHrdApplication(int id);

  //      public int SaveAdvHrdApplication(Order model, string REC_TYPE);
    }
}
