using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;


namespace order_project.Utility
{
    public class DbAccess
    {
        private readonly string _connectionString; 
        public static byte[] pImage;

        public DbAccess(IConfiguration configuration)
        {
            // Read the connection string from the configuration file
           _connectionString = configuration.GetConnectionString("db1");
          
        }

        public DataTable GetDataTable(SqlCommand query)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                query.Connection = connection;
                query.CommandType = CommandType.StoredProcedure;
                using (query)
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query))
                    {
                        adapter.Fill(dataTable);
                    }
                    connection.Close();
                }
            }

            return dataTable;
        }
        public int int_Process(string query, string[] parametername, string[] parametervalue)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;

                    for (int i = 0; i < parametername.Length; i++)
                    {
                        cmd.Parameters.AddWithValue(parametername[i], parametervalue[i]);
                    }

                    con.Open();
                    SqlParameter returnParameter = cmd.Parameters.Add("RetVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    cmd.ExecuteNonQuery();
                    int id = (int)returnParameter.Value;
                    return id;
                }
            }
        }
        public int ExecuteNonQuery(string query, string[] parametername, object[] parametervalue)
        {
            //int rowsAffected = 0;
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandTimeout = 0;
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < parametername.Length; i++)
            {
                if (parametername[i] == "@photo")
                {
                    cmd.Parameters.AddWithValue(parametername[i], pImage);
                }
                else
                {
                    cmd.Parameters.AddWithValue(parametername[i], parametervalue[i]);
                }
            }
            con.Open();
            SqlParameter returnParameter = cmd.Parameters.Add("RetVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            cmd.ExecuteNonQuery();
            int id = (int)returnParameter.Value;
            con.Dispose();
            return id;


        }
        public DataSet Ds_Process(String Storp, string[] parametername, string[] parametervalue)
        {

            try
            {

                SqlConnection con = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand(Storp, con);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < parametername.Length; i++)
                {
                    cmd.Parameters.AddWithValue(parametername[i], parametervalue[i]);
                }
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                da.Dispose();
                con.Dispose();
                return ds;
            }
            catch (Exception ex)
            {

                DataSet ds = null;
                return ds;
            }

        }
        
    }
}
