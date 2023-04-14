using CoffeeManagement.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CoffeeManagement.Models.DAL.Implement
{
    public class Order_detailDAO : IOrder_detailDAO
    {
        public void delete(int id)
        {
            if (DatabaseAccess.connection == null)
            {
                DatabaseAccess.connect();
            }

            int ret = DatabaseAccess.deleteById("DeleteOrderDetailByProduct", productId);
            if (ret == 0)
            {
                throw new Exception("Not found object!");
            }
        }

        public List<Order_detail> getAll()
        {
            if (DatabaseAccess.connection == null)
            {
                DatabaseAccess.connect();
            }

            SqlDataReader dataReader = DatabaseAccess.getAll("GetAllOrders");
            List<Order_detail> result = new List<Order_detail>();
            while (dataReader.Read())
            {
                int orderId = dataReader.GetInt32(0);
                int productId = dataReader.GetInt32(1);
                int quantity = dataReader.GetInt32(2);
                result.Add(new Order_detail(orderId, productId, quantity));
            }
            return result;
        }

        public Order_detail getById(int id)
        {
            if (DatabaseAccess.connection == null)
            {
                DatabaseAccess.connect();
            }

            SqlDataReader dataReader = DatabaseAccess.getById("GetOrderDetailById", id);
            if (dataReader.Read())
            {
                int orderId = dataReader.GetInt32(0);
                int productId = dataReader.GetInt32(1);
                int quantity = dataReader.GetInt32(2);
                return new Order_detail(orderId, productId, quantity);
            }
            return null;
        }

        public void insert(Order_detail data)
        {
            if (DatabaseAccess.connection == null)
            {
                DatabaseAccess.connect();
            }

            SqlCommand command = DatabaseAccess.connection.CreateCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "InsertOrderDetail";
            command.Connection = DatabaseAccess.connection;

            command.Parameters.Add("@orderId", System.Data.SqlDbType.Int).Value = data.OrderId;
            command.Parameters.Add("@product_Id", System.Data.SqlDbType.Int).Value = data.ProductId;
            command.Parameters.Add("@quantity", System.Data.SqlDbType.DateTime).Value = data.Quantity;
            
            int ret = command.ExecuteNonQuery();
            if (ret == 0)
            {
                throw new Exception("Update fail");
            }
        }

        public void update(Order_detail data)
        {
            if (DatabaseAccess.connection == null)
            {
                DatabaseAccess.connect();
            }

            SqlCommand command = DatabaseAccess.connection.CreateCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "UpdateOrderDetailQuantity";
            command.Connection = DatabaseAccess.connection;

            command.Parameters.Add("@orderId", System.Data.SqlDbType.Int).Value = data.OrderId;
            command.Parameters.Add("@product_Id", System.Data.SqlDbType.Int).Value = data.ProductId;
            command.Parameters.Add("@quantity", System.Data.SqlDbType.DateTime).Value = data.Quantity;


            int ret = command.ExecuteNonQuery();
            if (ret == 0)
            {
                throw new Exception("Update fail");
            }
        }
    }
}