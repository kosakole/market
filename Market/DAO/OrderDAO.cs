using Market.DTO;
using Market.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DAO
{
    internal interface OrderDAO
    {
        bool create(Order order, Deliverer deliverer);
        List<Order> GetAll();
        List<Article> GetArticlesForOrder(int idOrder);
    }
}
