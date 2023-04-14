using CoffeeManagement.Models.DAL;
using CoffeeManagement.Models.DAL.Implement;
using CoffeeManagement.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeManagement.Controllers
{
    public class OrdersController : Controller
    {
        private static OrdersDAO ordersDAO = new OrdersDAO();

        // GET: Orders
        public string Index()
        {
            return "hello";
        }   
        
    }
}