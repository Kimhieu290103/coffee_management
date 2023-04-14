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
        private static OrdersDAO odrersDAO = new OrdersDAO();

        // GET: Orders
        public string Index()
        {
            return "hello";
        }

        public ActionResult GetAll()
        {
            List<Orders> list = odrersDAO.getAll();
            return View(list);

        }


        public int GetTableNameById()
        {
            Orders orders =  odrersDAO.getById(1);
            return orders.GetTableNumber();
        }
    }
}