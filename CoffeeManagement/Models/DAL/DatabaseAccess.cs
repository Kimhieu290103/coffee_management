using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace CoffeeManagement.Models.DAL
{
    public class DatabaseAccess
    {
        private const string URL = @"Data Source = PTVINH-73; Initial Catalog = CoffeeManagement; Integrated Security=True";
        public static SqlConnection connection = null;

        public static void connect()
        {
            try
            {
                if (connection == null)
                {
                    connection = new SqlConnection(URL);
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                /*Console.WriteLine("error");*/
            }

        }
        public static void close()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
        public static SqlDataReader getAll(string procName)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = procName;
            command.Connection = connection;
            return command.ExecuteReader();
        }
        public static SqlDataReader getById(string proName, int id)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = proName;
            command.Connection = connection;

            SqlParameter para = new SqlParameter("@id", System.Data.SqlDbType.Int);
            para.Value = id;
            command.Parameters.Add(para);
            return command.ExecuteReader();
        }
        public static int deleteById(string proName, int id)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = proName;
            command.Connection = connection;

            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            return command.ExecuteNonQuery();
        }
        
    }
}