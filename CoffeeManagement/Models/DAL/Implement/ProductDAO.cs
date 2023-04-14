using CoffeeManagement.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CoffeeManagement.Models.DAL.Implement
{
    public class ProductDAO : IProductDAO
    {
        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> getAll()
        {
            if (DatabaseAccess.connection == null)
            {
                DatabaseAccess.connect();
            }

            List<Product> result = new List<Product>();
            SqlDataReader sqlDataReader = DatabaseAccess.getAll("GetAllProduct");
            while (sqlDataReader.Read()) 
            {
                int id = sqlDataReader.GetInt32(0);
                string name = sqlDataReader.GetString(1);
                double cost = sqlDataReader.GetDouble(2);
                result.Add(new Product(id, name, cost));
            }
            return result;
        }

        public Product getById(int id)
        {
            throw new NotImplementedException();
        }

        public void insert(Product data)
        {
            throw new NotImplementedException();
        }

        public void update(Product data)
        {
            throw new NotImplementedException();
        }
    }
}