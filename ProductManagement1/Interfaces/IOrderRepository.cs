using ProductManagement1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement1.Interfaces
{
    internal interface IOrderRepository <T> where T : class
    {
        public void createOrder(string customerName, string address);
        public void updateOrder(string customerName, string address, int orderId);
        public void updateOrderPrice(int orderId);
        public void updateOrderStatus(int orderId,int status);
        public void deleteOrder(int id);
        public List<Order> searchOrderByCustomerName(string customerName);

    }
}
