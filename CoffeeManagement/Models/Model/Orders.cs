using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeManagement.Models.Model
{
    public class Orders
    {
        private int id { get; set; }
        private int tableNumber;
        private DateTime time { get; set; }
        private byte state { get; set; }

        public Orders(int id, int tableNumber, DateTime time, byte state)
        {
            this.id = id;
            this.tableNumber = tableNumber;
            this.time = time;
            this.state = state;
        }

        public void SetTableNumber(int tableNumber)
        {
            this.tableNumber = tableNumber;
        }
        public int GetTableNumber()
        {
            return this.tableNumber;
        }
    }
}