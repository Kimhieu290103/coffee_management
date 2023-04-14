using CoffeeManagement.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManagement.Models.DAL
{
    interface IOrdersDAO : IDAO<Orders, int>
    {
        void updateOrderState(int id, byte state);
        void updateOrderTableNumber(int id, int tableNumber);
    }
}
