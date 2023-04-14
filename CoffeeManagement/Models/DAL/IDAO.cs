using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManagement.Models.DAL
{
    interface IDAO<T>
    {
        List<T> getAll();
        T getById(int id);
        void insert(T data);
        void update(T data);
        void delete(int id);
    }
}
