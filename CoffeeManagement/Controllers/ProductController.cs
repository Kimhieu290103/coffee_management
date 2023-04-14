using CoffeeManagement.Models.DAL.Implement;
using CoffeeManagement.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeManagement.Controllers
{
    public class ProductController : Controller
    {
        private static ProductDAO productDAO = new ProductDAO();

        [HttpGet]
        public List<Product> getAll()
        {
            return productDAO.getAll();
        }
    }
}