using Microsoft.AspNetCore.Mvc;
//using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Xml;
using order_project.Models;
using order_project.Utility;

namespace order_project.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        IConfiguration _configuration;
        Utility.DbAccess _DbAccess;
        public OrderRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _DbAccess = new DbAccess(_configuration);
        }
        //	#region IncrementSetup
        public List<object> GetCustomerNames()
        {
            try
            {

                string[] pname = { "@ID ", "@REC_TYPE ", "@CATEGORY" };
                string[] pvalue = { "0", "GET_ALL", "CUSTOMER" };
                DataSet ds = _DbAccess.Ds_Process("SP_GET_ENTITIES", pname, pvalue);
                List<object> types = new List<object>();

                foreach (DataRow item in ds.Tables[0].Rows)
                {

                    types.Add(
                        new { CustomerId = Convert.ToInt32(item["Id"]), NAME = item["NAME"].ToString() }
                        );

                }

                return types;
            }
            catch (Exception ex)
            {

                throw;
            }

        }


        public List<object> GetProduct()
        {
            try
            {

                string[] pname = { "@ID ", "@REC_TYPE ", "@CATEGORY" };
                string[] pvalue = { "0", "GET_ALL", "PRODUCT" };
                DataSet ds = _DbAccess.Ds_Process("SP_GET_ENTITIES", pname, pvalue);
                List<object> types = new List<object>();

                foreach (DataRow item in ds.Tables[0].Rows)
                {

                    types.Add(
                        new { ProductId = Convert.ToInt32(item["Id"]), NAME = item["NAME"].ToString() }
                        );

                }

                return types;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public List<object> GetOrderDetails()
        {
            try
            {
                string[] pname = { "@ID ", "@REC_TYPE ", "@CATEGORY" };
                string[] pvalue = { "0", "GET_ALL", "ORDER" };
                DataSet DS = _DbAccess.Ds_Process("SP_GET_ENTITIES", pname, pvalue);
                List<object> dataList = new List<object>();
                if (DS.Tables.Count > 0)
                {
                    foreach (DataRow item in DS.Tables[0].Rows)
                    {
                        dataList.Add(
                            new Order
                            {
                                Sl = Convert.ToInt32(item["Sl"]),
                                Id = Convert.ToInt32(item["Id"]),
                                CustomerName = item["CustomerName"].ToString(),
                                ProductName = item["ProductName"].ToString(),
                                OrderAmount =Convert.ToDecimal( item["Amount"]),
                                Quantity = Convert.ToInt32(item["Quantity"]),
                                OrderDesc = item["Order_Desc"].ToString()
                               
                            }
                            );


                    }
                }
              

                return dataList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int SaveOrder(Order model)
        {

            try
            {
                
  
                string[] pname = {"@ID","@CUST_ID","@PROD_ID", "@QUANTITY" };
                
                object[] pvalue = { 0,model.CustomerId,model.ProductId,model.Quantity };


                int result = _DbAccess.ExecuteNonQuery("[SP_SAVE_ORDERS]", pname, pvalue);
                if (result > 0)
                {

                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }

}