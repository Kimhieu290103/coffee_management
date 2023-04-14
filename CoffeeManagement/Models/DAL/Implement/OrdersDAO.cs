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

            int rowChanged = DatabaseAccess.deleteById("DeleteOrderById", id);
            if (rowChanged == 0)
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
            
        }

        public void update(Orders data)
        {
            throw new NotImplementedException();
        }
    }
}