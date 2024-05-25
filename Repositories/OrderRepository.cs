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
}
		//public List<Order> GetAdvanceHrd(int EMPLOYEE_MASTER_KEY , int REPORTING_BOSS_KEY)
         

             
  //      {
  //          try
  //          {
  //              string[] parameterNames = { "@EMPLOYEE_MASTER_KEY" , "@REPORTING_BOSS_KEY" };
  //              string[] parameterValues = { EMPLOYEE_MASTER_KEY.ToString() , REPORTING_BOSS_KEY.ToString()};
  //              DataSet dataSet = _DbAccess.Ds_Process("SP_GET_NEW_MAST_HRD_ADVANCE_APPLICATION", parameterNames, parameterValues);
  //              List<AdvanceHrdUIModel> lst = new List<AdvanceHrdUIModel>();

  //              if (dataSet.Tables.Count > 0)
  //              {
  //                  DataTable dt = dataSet.Tables[0];
  //                  if (dt.Rows.Count > 0)
  //                  {
              
  //                      foreach (DataRow row in dt.Rows)
  //                      {
  //                          var mdl = new AdvanceHrdUIModel();

  //                          mdl.EMPLOYEE_MASTER_KEY = Convert.ToInt32(row["EMPLOYEE_MASTER_KEY"]);
  //                          mdl.SERIAL_NO = Convert.ToInt32(row["SERIAL_NO"]);
                          
  //                          mdl.EMPLOYEE_NAME = Convert.ToString(row["Employee_Name"]);
  //                          mdl.ADVANCE_APPLICATION_REQUIRED_AMOUNT = Convert.ToDecimal(row["ADVANCE_APPLICATION_REQUIRED_AMOUNT"]);
  //                          mdl.ADVANCE_REFUND_STARTDATE = Convert.ToString(row["ADVANCE_REFUND_STARTDATE"]);
  //                          mdl.ADVANCE_REFUND_ENDDATE = Convert.ToString(row["ADVANCE_REFUND_ENDDATE"]);
  //                          mdl.APPROVED_INSTALLMENT_AMOUNT = Convert.ToDecimal(row["APPROVED_INSTALLMENT_AMOUNT"]);

  //                          mdl.PROPOSED_STARTING_DATE = Convert.ToString(row["PROPOSED_STARTING_DATE"]);
  //                          mdl.PROPOSED_ENDING_DATE = Convert.ToString(row["PROPOSED_ENDING_DATE"]);
  //                          mdl.REMARKS = Convert.ToString(row["REMARKS"]);
  //                          mdl.EXTENDED_FLAG = Convert.ToInt32(row["EXTENDED_FLAG"]);
  //                          mdl.EXTEND_INSTALLMENT_NO = Convert.ToInt32(row["EXTEND_INSTALLMENT_NO"]);
  //                          lst.Add(mdl);
  //                      }
  //                  }
  //              }
  //              return lst;

  //          }

  //          catch
  //          {
  //              throw;
  //          }
  //      }


  //      public List<AdvanceHrdUIModel> ExtendAdvHrdApplication(int id)
  //      {
  //          try
  //          {
  //              string[] parameterNames = { "@EMPLOYEE_MASTER_KEY"};
  //              string[] parameterValues = { id.ToString()};
  //              DataSet dataSet = _DbAccess.Ds_Process("SP_UPDATE_NEW_MAST_HRD_ADVANCE_APPLICATION", parameterNames, parameterValues);
  //              List<AdvanceHrdUIModel> lst = new List<AdvanceHrdUIModel>();

  //              if (dataSet.Tables.Count > 0)
  //              {
  //                  DataTable dt = dataSet.Tables[0];
  //                  if (dt.Rows.Count > 0)
  //                  {
        
  //                      foreach (DataRow row in dt.Rows)
  //                      {
  //                          var mdl = new AdvanceHrdUIModel();

  //                          mdl.EMPLOYEE_MASTER_KEY = Convert.ToInt32(row["EMPLOYEE_MASTER_KEY"]);
  //                          mdl.SERIAL_NO = Convert.ToInt32(row["SERIAL_NO"]);
  //                          mdl.EXTENDED_FLAG = Convert.ToInt32(row["EXTENDED_FLAG"]);
  //                          mdl.EMPLOYEE_NAME = Convert.ToString(row["Employee_Name"]);
  //                          mdl.ADVANCE_APPLICATION_REQUIRED_AMOUNT = Convert.ToDecimal(row["ADVANCE_APPLICATION_REQUIRED_AMOUNT"]);
  //                          mdl.ADVANCE_REFUND_STARTDATE = Convert.ToString(row["ADVANCE_REFUND_STARTDATE"]);
  //                          mdl.ADVANCE_REFUND_ENDDATE = Convert.ToString(row["ADVANCE_REFUND_ENDDATE"]);
  //                          mdl.APPROVED_INSTALLMENT_AMOUNT = Convert.ToDecimal(row["APPROVED_INSTALLMENT_AMOUNT"]);

  //                          mdl.PROPOSED_STARTING_DATE = Convert.ToString(row["PROPOSED_STARTING_DATE"]);
  //                          mdl.PROPOSED_ENDING_DATE = Convert.ToString(row["PROPOSED_ENDING_DATE"]);
  //                          mdl.REMARKS = Convert.ToString(row["REMARKS"]);
  //                          mdl.EXTEND_INSTALLMENT_NO = Convert.ToInt32(row["EXTEND_INSTALLMENT_NO"]);
  //                          lst.Add(mdl);
  //                      }
                      
  //                  }
  //              }
  //              return lst;

  //          }

  //          catch
  //          {
  //              throw;
  //          }

  //      }

  //      public int SaveAdvHrdApplication(AdvanceHrdUIModel model,string REC_TYPE)
  //      {
  //          try
  //          {
  //              string[] parameterNames = { "@REC_TYPE","@EMPLOYEE_MASTER_KEY", "@PROPOSED_STARTING_DATE ", "@PROPOSED_ENDING_DATE", "@REMARKS", "@EXTENDED_FLAG", "@EXTEND_INSTALLMENT_NO" };
  //              string[] parameterValues = { REC_TYPE, model.EMPLOYEE_MASTER_KEY.ToString(),model.PROPOSED_STARTING_DATE,model.PROPOSED_ENDING_DATE,model.REMARKS,model.EXTENDED_FLAG.ToString(), model.EXTEND_INSTALLMENT_NO.ToString() };
         
  //              return _DbAccess.int_Process("SP_UPDATE_NEW_MAST_HRD_ADVANCE_APPLICATION", parameterNames, parameterValues);
               

  //          }

  //          catch
  //          {
  //              throw;
  //          }


  //      }


  //  }
}

