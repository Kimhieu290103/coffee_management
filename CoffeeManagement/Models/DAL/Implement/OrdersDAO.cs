using CoffeeManagement.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CoffeeManagement.Models.DAL.Implement
{
    public class OrdersDAO : IOrdersDAO
    {
        public void delete(int id)
        {
            if (DatabaseAccess.connection == null)
            {
                DatabaseAccess.connect();
            }

            int ret = DatabaseAccess.deleteById("DeleteOrderById", id);
            if (ret == 0)
            {
                throw new Exception("Not found object!");
            }
        }

        public List<Orders> getAll()
        {
            if (DatabaseAccess.connection == null)
            {
                DatabaseAccess.connect();
            }

            SqlDataReader dataReader = DatabaseAccess.getAll("GetAllOrders");
            List<Orders> result = new List<Orders>(); 
            while(dataReader.Read())
            {
                int id = dataReader.GetInt32(0);
                int tableNumber = dataReader.GetInt32(1);
                DateTime time = dataReader.GetDateTime(2);
                byte state = dataReader.GetByte(3);
                result.Add(new Orders(id, tableNumber, time, state));
            }
            return result;
        }


        public Orders getById(int id)
        {
            if (DatabaseAccess.connection == null)
            {
                DatabaseAccess.connect();
            }

            SqlDataReader dataReader = DatabaseAccess.getById("GetOrdersById", id);
            if (dataReader.Read())
            { 
                int idd = dataReader.GetInt32(0);
                int tableNumber = dataReader.GetInt32(1);
                DateTime time = dataReader.GetDateTime(2);
                byte state = dataReader.GetByte(3);
                return new Orders(idd, tableNumber, time, state);
            }
            return null;
        }


        public void insert(Orders data)
        {
            if (DatabaseAccess.connection == null)
            {
                DatabaseAccess.connect();
            }

            SqlCommand command = DatabaseAccess.connection.CreateCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "InsertOrder";
            command.Connection = DatabaseAccess.connection;

            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = data.Id;
            command.Parameters.Add("@tableNumber", System.Data.SqlDbType.Int).Value = data.TableNumber;
            command.Parameters.Add("@time", System.Data.SqlDbType.DateTime).Value = data.Time;
            command.Parameters.Add("@state", System.Data.SqlDbType.TinyInt).Value = data.State;

            int ret = command.ExecuteNonQuery();
            if (ret == 0)
            {
                throw new Exception("Update fail");
            }
        }

        public void update(Orders data)
        {
            if (DatabaseAccess.connection ==  null)
            {
                DatabaseAccess.connect();
            }

            SqlCommand command = DatabaseAccess.connection.CreateCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "UpdateOrder";
            command.Connection = DatabaseAccess.connection;

            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = data.Id;
            command.Parameters.Add("@tableNumber", System.Data.SqlDbType.Int).Value = data.TableNumber;
            command.Parameters.Add("@time", System.Data.SqlDbType.DateTime).Value = data.Time;
            command.Parameters.Add("@state", System.Data.SqlDbType.TinyInt).Value = data.State;

            int ret = command.ExecuteNonQuery();
            if (ret == 0)
            {
                throw new Exception("Update fail");
            }
        }

        public void updateOrderState(int id, byte state)
        {
            if (DatabaseAccess.connection == null)
            {
                DatabaseAccess.connect();
            }

            SqlCommand command = DatabaseAccess.connection.CreateCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "UpdateOrderState";
            command.Connection = DatabaseAccess.connection;

            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            command.Parameters.Add("@state", System.Data.SqlDbType.TinyInt).Value = state;

            int ret = command.ExecuteNonQuery();
            if (ret == 0)
            {
                throw new Exception("Update fail");
            }
        }

        public void updateOrderTableNumber(int id, int tableNumber)
        {
            if (DatabaseAccess.connection == null)
            {
                DatabaseAccess.connect();
            }

            SqlCommand command = DatabaseAccess.connection.CreateCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "UpdateOrderTableNumber";
            command.Connection = DatabaseAccess.connection;

            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            command.Parameters.Add("@tableNumber", System.Data.SqlDbType.Int).Value = tableNumber;

            int ret = command.ExecuteNonQuery();
            if (ret == 0)
            {
                throw new Exception("Update fail");
            }
        }
    }
}